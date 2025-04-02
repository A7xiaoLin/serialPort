using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace serialPort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);

            // 定时器的Tick事件处理程序
            Update_Timer();
            timer1.Tick += new EventHandler(Timer_Tick);
            // 每当用户改变了numericUpDown1的值，请做某些事情（执行NumericUpDown1_ValueChanged方法）
            numericUpDown1.ValueChanged += new EventHandler(NumericUpDown1_ValueChanged);

            groupBox6.Visible = false;
            this.Load += new EventHandler(btnHideorShow_Click);     // 启动前直接点击
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ExpandData();   // 初始化拓展数据

            textBoxSend.Text = Properties.Settings.Default.textSend.ToString();

            cobxPort.Text = Properties.Settings.Default.PortName;
            string[] ports = SerialPort.GetPortNames();
            cobxPort.Items.AddRange(ports);
            cobxPort.SelectedIndex = cobxPort.Items.IndexOf(Properties.Settings.Default.PortName) != -1 ? cobxPort.Items.IndexOf(Properties.Settings.Default.PortName) : -1;

            string[] Bauds = new string[] { "自定义", "4800", "9600", "12800", "19200", "38400", "56000" };
            cobxBaudrate.DataSource = Bauds;
            if (Bauds.Contains(Properties.Settings.Default.BaudRate.ToString()))    // 检查保存的波特率设置是否存在于选项中
            {
                cobxBaudrate.SelectedItem = Properties.Settings.Default.BaudRate.ToString();
            }
            else
            {
                cobxBaudrate.SelectedIndex = 2; // 默认选中"9600"
            }

            int[] datas = new int[] { 5, 6, 7, 8 };
            cobxDataBits.DataSource = datas;
            cobxDataBits.SelectedIndex = 3;

            string[] stopBits = new string[] { "1", "1.5", "2" };
            cobxStopbit.DataSource = stopBits;
            cobxStopbit.SelectedIndex = 0;

            string[] paritys = new string[] { "无", "奇校验", "偶校验" };
            cobxCheck.DataSource = paritys;
            cobxCheck.SelectedIndex = 0;
        }

        /// <summary>
        /// 数据接收器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int len = serialPort1.BytesToRead;
            byte[] buffer = new byte[len];
            serialPort1.Read(buffer, 0, len);

            // 将新接收到的数据添加到缓存中
            receiveBuffer.AddRange(buffer);

            ProcessReceivedData();
        }

        /// <summary>
        /// 放置缓存区域
        /// </summary>
        private List<byte> receiveBuffer = new List<byte>();

        /// <summary>
        /// 缓冲 - 数据处理
        /// </summary>
        private void ProcessReceivedData()
        {
            while (receiveBuffer.Count >= 20) // 确保有足够的数据进行处理
            {
                byte[] dataPacket = receiveBuffer.Take(20).ToArray(); // 获取前20个字节作为一包完整数据

                int sum = 0;    // 算出获取到的数据总和（十六进制）
                foreach (byte b in dataPacket)
                {
                    sum += b;
                }

                // 验证第一个字节是否为0x41，最后一个字节是否为0x0D
                if (dataPacket[0] != 0x41 || dataPacket[19] != 0x0D)
                {
                    Invoke((new Action(() => {
                        string prefix = "";
                        if (checkBoxTimeShow.Checked)
                        {
                            prefix = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff ") + " - ";
                        }
                        textBoxRecv.AppendText($"{prefix}数据包格式错误: 应以41开头并以0D结尾 {Environment.NewLine}");
                    })));
                    receiveBuffer.RemoveRange(0, 20); // 移除已验证的数据
                    continue;
                }

                // 校验和检查
                if (!CheckHexSumIsValid(dataPacket))
                {
                    Invoke((new Action(() => {
                        string prefix = "";
                        string hexString = BitConverter.ToString(dataPacket).Replace("-", " ");
                        if (checkBoxTimeShow.Checked)
                        {
                            prefix = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff ") + " - ";
                        }
                        textBoxRecv.AppendText($"{prefix}校验和错误，数据无效，请检查，数据不符合要求，接收到的数据为：{hexString} -- {sum} {Environment.NewLine}");
                    })));
                    receiveBuffer.RemoveRange(0, 20); // 移除已验证的数据
                    continue;
                }

                string formattedValue = ExtractAndFormatBytes(dataPacket);      // 提取对应的数据

                Invoke((new Action(() => {
                    string prefix = "";
                    if (checkBoxTimeShow.Checked)   // 显示时间
                    {
                        prefix = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss :");
                    }

                    if (checkBoxHexShow.Checked)    // 十六进制接收
                    {
                        string hexStr = byteToHexStr(dataPacket);
                        textBoxRecv.AppendText($"收<<<：{prefix} {hexStr} {Environment.NewLine}");
                        textBoxExtract.AppendText($"收<<<：{prefix} {formattedValue} {Environment.NewLine}");
                    }
                    else
                    {
                        string str = Encoding.Default.GetString(dataPacket);
                        textBoxRecv.AppendText($"收<<<：{prefix} {str} {Environment.NewLine}");
                    }
                })));

                // 在完成所有处理后移除已处理的数据
                receiveBuffer.RemoveRange(0, 20);
            }
        }

        /// <summary>
        /// 从buff数组中提取第4、5、6个字节，并将其格式化为"XX.XX"的形式
        /// </summary>
        /// <param name="buff">包含接收数据的字节数组</param>
        /// <returns>格式化后的字符串</returns>
        private string ExtractAndFormatBytes(byte[] buff)
        {
            // 确保有足够的数据可供提取
            if (buff.Length < 20)
            {
                return "数据不足";
            }

            byte b4 = buff[4];
            byte b5 = buff[5];
            byte b6 = buff[6];

            // 将字节转换为两位十六进制字符串
            string strB4 = b4.ToString("X2");
            string strB5 = b5.ToString("X2");
            string strB6 = b6.ToString("X2");

            // 格式化输出，中间加小数点
            return $"{strB4}{strB5}.{strB6}";
        }

        /// <summary>
        /// 转换十六进制
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private string byteToHexStr(byte[] bytes)
        {
            string hexStr = "";
            try
            {
                if (bytes != null)
                {
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        hexStr += bytes[i].ToString("X2");
                        hexStr += " ";
                    }
                }
                return hexStr;
            }
            catch (Exception)
            {
                return hexStr;
            }
        }

        /// <summary>
        /// 校验和 十六进制相加 === 100
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private bool CheckHexSumIsValid(byte[] bytes)
        {
            int sum = 0;
            foreach (byte b in bytes)
            {
                sum += b;
            }
            // 校验和需要是0x100，这里通过取模操作确认
            return (sum & 0xFF) == 0x00; // 直接比较sum==0x100可能会错过一些情况，所以用这种方式
        }

        /// <summary>
        /// 打开串口连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPortOnOff_Click(object sender, EventArgs e)
        {
            isOpenSerialport();
        }

        /// <summary>
        /// 打开串口方法
        /// </summary>
        private void isOpenSerialport()
        {
            if (serialPort1.IsOpen)
            {
                // 如果串口是打开的，则关闭它
                serialPort1.Close();
                btnPortOnOff.Text = "打开串口";

                // 重置自动发送模式的标志位
                isNormalAutoSend = false;
                isIncrementAutoSend = false;

                // 重新启用两个自动发送按钮
                autoSend.Enabled = true;
                btnIncrement.Enabled = true;
                UpdateButtonStates();
            }
            else
            {
                try
                {
                    serialPort1.PortName = cobxPort.Text;   // 端口
                    string serialPortName = cobxPort.Text;
                    serialPort1.BaudRate = int.Parse(cobxBaudrate.Text);    // 波特率
                    serialPort1.DataBits = int.Parse(cobxDataBits.Text);    // 数据位

                    if (cobxStopbit.Text == "1") { serialPort1.StopBits = StopBits.One; }   // 停止位
                    else if (cobxStopbit.Text == "1.5") { serialPort1.StopBits = StopBits.OnePointFive; }
                    else if (cobxStopbit.Text == "2") { serialPort1.StopBits = StopBits.Two; }

                    if (cobxCheck.Text == "无") { serialPort1.Parity = Parity.None; }    // 校验位
                    else if (cobxCheck.Text == "偶校验") { serialPort1.Parity = Parity.Even; }
                    else if (cobxCheck.Text == "奇校验") { serialPort1.Parity = Parity.Odd; }
                    serialPort1.Open();
                    btnPortOnOff.Text = "关闭串口";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("串口打开失败" + ex.ToString(), "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 清除接收信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCleanAccept_Click(object sender, EventArgs e)
        {
            textBoxRecv.Clear();    // 接收框
            textBoxExtract.Clear(); // 提取框
        }

        /// <summary>
        /// 判断是否有弹窗
        /// </summary>
        private bool isShow = false;

        /// <summary>
        /// 发送数据的方法
        /// </summary>
        /// <param name="str">文本框内的值</param>
        private void SendData(string str)
        {
            try
            {
                if (!string.IsNullOrEmpty(str))
                {
                    byte[] bytesToSend;
                    // 勾选使用十六进制发送数据
                    if (comboBoxEncoding.Checked)
                    {
                        str = str.Replace(" ", ""); // 移除所有空格
                        if (str.Length % 2 != 0)    // 确保是偶数长度
                        {
                            if (!isShow)
                            {
                                isShow = true;
                                MessageBox.Show("十六进制字符串长度应为偶数，请检查输入", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                timer1.Stop();
                                btnIncrement.Enabled = true;
                                autoSend.Text = "开始正常自动发送";
                                isShow = false;
                            }
                            return;
                        }
                        int numberChars = str.Length;
                        bytesToSend = new byte[numberChars / 2];    // 40÷2
                        for (int i = 0; i < numberChars; i += 2)    // 循环遍历数据做后续处理
                        {
                            bytesToSend[i / 2] = Convert.ToByte(str.Substring(i, 2), 16);
                        }

                        if (bytesToSend.Length != 20)       // 验证数据长度是否为20字节
                        {
                            if(!isShow)
                            {
                                isShow = true;
                                MessageBox.Show("发送的数据长度必须为20字节", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                timer1.Stop();
                                btnIncrement.Enabled = true;
                                autoSend.Text = "开始正常自动发送";
                                isShow = false;
                            }
                            return;
                        }

                        bool isValid = CheckHexSumIsValid(bytesToSend);   // 检查校验和（十六进制相加的结果必须为0x100）
                        if (!isValid)
                        {
                            if (!isShow)
                            {
                                isShow = true;
                                MessageBox.Show("校验和错误，数据无效，请检查", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                timer1.Stop();
                                btnIncrement.Enabled = true;
                                autoSend.Text = "开始正常自动发送";
                                isShow = false;
                            }
                            return;
                        }
                    }
                    else // 使用ASCII发送
                    {
                        bytesToSend = Encoding.ASCII.GetBytes(str);
                    }

                    // 发送数据
                    serialPort1.Write(bytesToSend, 0, bytesToSend.Length);

                    string formattedStr = BitConverter.ToString(bytesToSend).Replace("-", " ");
                    textBoxExtract.AppendText("\r\n");
                    textBoxRecv.AppendText($"发>>>： {formattedStr} {Environment.NewLine}");
                }
            }
            catch (Exception ex)
            {
                if (!isShow)
                {
                    isShow = true;
                    MessageBox.Show($"发送数据失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isShow = false;
                }
            }
        }

        /// <summary>
        /// 执行实际的数据发送操作
        /// </summary>
        /// <param name="str">要发送的数据</param>
        private void PerformSendData(string str)
        {
            // 检查串口是否已打开，如果没有打开则尝试打开
            if (!serialPort1.IsOpen)
            {
                isOpenSerialport(); // 调用打开串口的方法
                if (!serialPort1.IsOpen) 
                {
                    MessageBox.Show("无法发送数据：串口未能成功打开", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            var Proper = Properties.Settings.Default;

            if (str == "")
            {
                // 从应用程序设置中获取上次发送的数据（如果有）
                string lastSentData = Proper.textSend?.ToString();

                if (lastSentData == "")
                {
                    MessageBox.Show("请输入要发送的数据", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // 如果存储的上次发送的数据存在且当前文本框内容与之不同，则恢复上次发送的数据到文本框
                if (!string.IsNullOrEmpty(lastSentData) && textBoxSend.Text.Trim() != lastSentData)
                {
                    textBoxSend.Text = lastSentData;
                }
                SendData(str);

                // 自动更新保存的发送数据为当前发送的数据
                Proper.textSend = str;
                Proper.Save();
            }
            else
            {
                // 如果发送的数据不为空,则直接使用当前文本框中的数据发送
                if (!string.IsNullOrEmpty(str) && textBoxSend.Text.Trim() != str)
                {
                    textBoxSend.Text = str;
                }
                SendData(str);

                Proper.textSend = str;
                Proper.Save();
            }
            
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendData_Click(object sender, EventArgs e)
        {
            if (CheckAutoSend()) return;    // 检查自动发送是否正在运行

            string str = textBoxSend.Text.Trim();
            //IsNullTextShow();   // 检查发送框是否有数据
            PerformSendData(str);
        }

        private bool isNormalAutoSend = false;      // 正常 自动发送按钮
        private bool isIncrementAutoSend = false;   // 递增 自动发送按钮

        /// <summary>
        /// 更新按钮状态和文本的方法
        /// </summary>
        private void UpdateButtonStates()
        {
            // 更新按钮状态和文本
            autoSend.Enabled = !isIncrementAutoSend;    // 如果当前是递增自动发送模式，则禁用普通自动发送按钮；否则启用它。
            btnIncrement.Enabled = !isNormalAutoSend;

            if (timer1.Enabled)  // 检查定时器是否已启动
            {
                if (isIncrementAutoSend)    // 如果当前是递增自动发送模式
                {
                    btnIncrement.Text = "停止递增自动发送";
                    autoSend.Enabled = false;   // 则禁用正常按钮
                }
                else if (isNormalAutoSend)
                {
                    autoSend.Text = "停止正常自动发送";
                    btnIncrement.Enabled = false;
                }
            }
            else        // 如果定时器未启动，重置按钮文本为初始状态
            {
                autoSend.Text = "开始正常自动发送";
                btnIncrement.Text = "开始递增自动发送";
            }
        }

        /// <summary>
        /// 正常自动发送按钮点击事件处理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void autoSend_Click(object sender, EventArgs e)
        {
            if (IsNullTextShow())
            {
                timer1.Stop();
                autoSend.Text = "开始正常自动发送";

                // 重置自动发送模式的标志位
                isNormalAutoSend = false;
                isIncrementAutoSend = false;

                // 重新启用两个自动发送按钮
                autoSend.Enabled = true;
                btnIncrement.Enabled = true;
                return;
            }

            if (timer1.Enabled && isNormalAutoSend)
            {
                timer1.Stop();      // 停止定时器
                isNormalAutoSend = false;    // 关闭正常自动发送模式
            }
            else
            {
                if (!serialPort1.IsOpen)
                {
                    MessageBox.Show("请先打开串口", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                isIncrementAutoSend = false;    // 确保递增自动发送模式关闭
                isNormalAutoSend = true;
                timer1.Start();
            }
            UpdateButtonStates();   // 更新按钮状态
        }

        #region 自动递增发送数据功能
        /// <summary>
        /// 自动递增发送数据按钮点击事件处理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIncrement_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled && isIncrementAutoSend)  // 判断按钮和计时器的状态
            {
                timer1.Stop();
                
                isIncrementAutoSend = false;
            }
            else
            {
                if (!serialPort1.IsOpen)
                {
                    MessageBox.Show("请先打开串口", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                isIncrementAutoSend = true;     // 开启递增自动发送模式
                isNormalAutoSend = false;       // 关闭正常按钮
                timer1.Start();
            }
            UpdateButtonStates();
        }

        /// <summary>
        /// 检查发送框是否有数据
        /// </summary>
        /// <returns></returns>
        private bool IsNullTextShow()
        {
            string str = textBoxSend.Text.Trim();
            if (string.IsNullOrEmpty(str))
            {
                if (!isShow)
                {
                    isShow = true;
                    MessageBox.Show("请输入要发送的数据", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isShow = false;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 执行递增自动发送数据的逻辑
        /// </summary>
        private void SendIncrementData()
        {
            string str = textBoxSend.Text.Trim();
            if (IsNullTextShow())   // 检查发送框是否有数据
            {
                timer1.Stop();
                btnIncrement.Text = "开始递增自动发送";

                // 重置自动发送模式的标志位
                isNormalAutoSend = false;
                isIncrementAutoSend = false;

                // 重新启用两个自动发送按钮
                autoSend.Enabled = true;
                btnIncrement.Enabled = true;
                return;
            }
            int increment = (int)numeric_Increment.Value - 1; // 转换为0索引

            try
            {
                // 将字符串转换为字节数组
                byte[] data = HexStringToByteArray(str);

                // 检查递增位置是否有效
                if (increment < 0 || increment >= data.Length)
                {
                    if (!isShow)
                    {
                        isShow = true;  // 设置标志位避免重复弹窗
                        MessageBox.Show("无效的递增位置", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isShow = false;
                        timer1.Stop();  // 停止定时器
                        autoSend.Enabled = true;
                        btnIncrement.Text = "开始递增自动发送";
                        return;
                    }
                }

                int originalSum = data.Sum(b => (int)b) & 0xFF;     // 计算原始数据总和
                data[increment]++;      // 对指定位置进行加一操作
                int newSum = data.Sum(b => (int)b) & 0xFF;   // 计算新的总和确定到达恰好值 - 100

                // 更新倒数第二位以确保总和达到0x100
                data[data.Length - 2] = (byte)((data[data.Length - 2] + (0x100 - newSum)) & 0xFF);  // data[18] = (byte)((0x30 + 0x10) & 0xFF);

                string updatedStr = ByteArrayToHexString(data);     // 将更新后的数据转换回十六进制字符串
                textBoxSend.Text = updatedStr;

                SendData(updatedStr);
            }
            catch (Exception ex)
            {
                if (!isShow)
                {
                    isShow = true;
                    MessageBox.Show($"发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    timer1.Stop();
                    autoSend.Enabled = true;
                    btnIncrement.Text = "开始递增自动发送";
                    isShow = false;
                }
            }
        }

        /// <summary>
        /// 将十六进制字符串转换为字节数组
        /// </summary>
        /// <param name="hex">十六进制字符串</param>
        /// <exception cref="ArgumentException">如果处理后的字符串长度不是偶数，则抛出异常</exception>
        private byte[] HexStringToByteArray(string hex)
        {
            // 移除输入字符串中的所有非十六进制字符（如空格）
            hex = System.Text.RegularExpressions.Regex.Replace(hex, "[^0-9A-Fa-f]", "");

            // 确保清理后的字符串长度是偶数，因为每两个字符代表一个字节
            if (hex.Length % 2 != 0)
            {
                throw new ArgumentException("十六进制字符串长度应为偶数，请检查输入");
            }
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2]; // 计算字节数组的大小

            // 循环遍历清理后的字符串，每次取两个字符转换为一个字节
            for (int i = 0; i < NumberChars; i += 2)
            {
                // 将每对字符转换为字节
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }

        /// <summary>
        /// 将字节数组转换为带空格分隔的十六进制字符串表示形式
        /// </summary>
        /// <param name="bytes">要转换的字节数组</param>
        private string ByteArrayToHexString(byte[] bytes)
        {
            // 初始化StringBuilder，每个字节需要3个字符的空间（2个数字+1个空格）
            StringBuilder sb = new StringBuilder(bytes.Length * 3);
            // 遍历每个字节，并将其转换为两位的十六进制字符串，后面加上一个空格
            foreach (byte b in bytes)
            {
                sb.AppendFormat("{0:X2} ", b); // 在每个字节后添加一个空格
            }
            return sb.ToString().Trim();    // 使用Trim()移除最后多余的空格
        }
        #endregion

        /// <summary>
        /// 清空发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearSend_Click(object sender, EventArgs e)
        {
            textBoxSend.Clear();
        }

        /// <summary>
        /// 检测端口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetect_Click(object sender, EventArgs e)
        {
            try
            {
                string[] Ports = SerialPort.GetPortNames();
                cobxPort.Items.Clear();
                if (Ports.Length > 0)
                {
                    cobxPort.Items.AddRange(Ports);
                    cobxPort.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("没有找到可用的串口端口", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("检测串口失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region 定时器事件 - 用于正常自动发送
        /// <summary>
        /// 定时器Tick事件处理程序每次定时器触发时调用此方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (isIncrementAutoSend)
                {
                    // 执行递增自动发送逻辑
                    SendIncrementData();
                }
                else if (isNormalAutoSend)
                {
                    // 正常发送数据
                    string str = textBoxSend.Text.Trim();
                    PerformSendData(str);
                }
            }
            else
            {
                timer1.Stop();
                UpdateButtonStates();   // 更新按钮状态
            }
        }

        /// <summary>
        /// 更新定时器的时间间隔
        /// </summary>
        private void Update_Timer()
        {
            timer1.Interval = (int)numericUpDown1.Value;
        }

        /// <summary>
        /// 控件值改变时的事件处理程序当用户更改NumericUpDown(上下选框)控件的值时调用此方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                UpdateButtonStates();
                if (!timer1.Enabled)
                {
                    autoSend.Enabled = true;
                    btnIncrement.Enabled = true;
                }
                Update_Timer();
            }
            else
            {
                Update_Timer();
            }
        }
        #endregion

        /// <summary>
        /// 显示 || 隐藏 - 拓展
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHideorShow_Click(object sender, EventArgs e)
        {
            if (btnHideorShow.Text == "显示")
            {
                groupBox6.Visible = true;
                btnHideorShow.Text = "隐藏";
            }
            else
            {
                groupBox6.Visible = false;
                btnHideorShow.Text = "显示";
            }
        }

        /// <summary>
        /// 拓展数据设置
        /// </summary>
        private void ExpandData()
        {
            string t = "备注...";
            var textBoxs = new Dictionary<TextBox, Tuple<string, string>>
            {
                { textBox1, new Tuple<string, string>("41 33 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 7F 0D", "DatatextBox1") },
                { textBox2, new Tuple<string, string>("41 71 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 41 0D", "DatatextBox2") },
                { textBox3, new Tuple<string, string>("41 46 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 6C 0D", "DatatextBox3") },
                { textBox4, new Tuple<string, string>("41 34 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 7E 0D", "DatatextBox4") },
                { t1, new Tuple<string, string>(t, "t1") },
                { t2, new Tuple<string, string>(t, "t2") },
                { t3, new Tuple<string, string>(t, "t3") },
                { t4, new Tuple<string, string>(t, "t4") }
            };
            foreach (var entry in textBoxs)
            {
                TextBox textBox = entry.Key;    // 控件
                string defaultValue = entry.Value.Item1;    // 默认值
                string settingsKey = entry.Value.Item2;     // 获取加载数据的用户名称读取

                // 如果当前文本不包含保存的数据，则加载保存的数据；否则，恢复默认值
                if (!textBox.Text.Contains(Properties.Settings.Default[settingsKey]?.ToString()))
                {
                    // ?.是一个Null条件运算符，??是一个Null合并运算符，?.ToString()确保为空，也不会导致错误，?? defaultValue则是在为空时使用你的默认值
                    textBox.Text = Properties.Settings.Default[settingsKey]?.ToString() ?? defaultValue;
                }
                else
                {
                    textBox.Text = defaultValue;
                }
            }
        }

        /// <summary>
        /// 检查是否正在进行自动发送
        /// </summary>
        /// <returns>如果正在进行自动发送返回true，否则返回false</returns>
        private bool IsAutoSending()
        {
            return timer1.Enabled && (isNormalAutoSend || isIncrementAutoSend);
        }

        /// <summary>
        /// 检查自动发送是否在运行
        /// </summary>
        /// <returns></returns>
        private bool CheckAutoSend()
        {
            if (IsAutoSending())
            {
                MessageBox.Show("当前正在自动发送数据，请先停止自动发送再尝试手动发送", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;
        }

        #region 拓展数据发送按钮
        private void btn_send1_Click(object sender, EventArgs e)
        {
            if (CheckAutoSend()) return;

            string str = textBox1.Text.Trim();
            SendData(str);
        }

        private void btn_send2_Click(object sender, EventArgs e)
        {
            if (CheckAutoSend()) return;

            string str = textBox2.Text.Trim();
            SendData(str);
        }

        private void btn_send3_Click(object sender, EventArgs e)
        {
            if (CheckAutoSend()) return;

            string str = textBox3.Text.Trim();
            SendData(str);
        }

        private void btn_send4_Click(object sender, EventArgs e)
        {
            if (CheckAutoSend()) return;

            string str = textBox4.Text.Trim();
            SendData(str);
        }
        #endregion

        /// <summary>
        /// 保存窗口配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var proper = Properties.Settings.Default;

                // 端口设置
                proper.PortName = cobxPort.Text;
                proper.BaudRate = int.Parse(cobxBaudrate.Text);

                // 拓展数据
                proper.DatatextBox1 = textBox1.Text;
                proper.DatatextBox2 = textBox2.Text;
                proper.DatatextBox3 = textBox3.Text;
                proper.DatatextBox4 = textBox4.Text;

                // 拓展数据备注
                proper.t1 = t1.Text;
                proper.t2 = t2.Text;
                proper.t3 = t3.Text;
                proper.t4 = t4.Text;

                // 默认发送数据上一次的值
                proper.textSend = textBoxSend.Text;

                proper.Save();
                MessageBox.Show("保存成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存失败{ex}", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
