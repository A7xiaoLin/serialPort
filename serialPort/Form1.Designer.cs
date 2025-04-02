namespace serialPort
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numeric_Increment = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnIncrement = new System.Windows.Forms.Button();
            this.autoSend = new System.Windows.Forms.Button();
            this.btnSendData = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxEncoding = new System.Windows.Forms.CheckBox();
            this.btnClearSend = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.textBoxRecv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSend = new System.Windows.Forms.TextBox();
            this.checkBoxHexShow = new System.Windows.Forms.CheckBox();
            this.cobxStopbit = new System.Windows.Forms.ComboBox();
            this.btnDetect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCleanAccept = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPortOnOff = new System.Windows.Forms.Button();
            this.cobxDataBits = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cobxCheck = new System.Windows.Forms.ComboBox();
            this.cobxPort = new System.Windows.Forms.ComboBox();
            this.cobxBaudrate = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxTimeShow = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxExtract = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnHideorShow = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.t4 = new System.Windows.Forms.TextBox();
            this.t3 = new System.Windows.Forms.TextBox();
            this.t2 = new System.Windows.Forms.TextBox();
            this.t1 = new System.Windows.Forms.TextBox();
            this.btn_send4 = new System.Windows.Forms.Button();
            this.btn_send2 = new System.Windows.Forms.Button();
            this.btn_send3 = new System.Windows.Forms.Button();
            this.btn_send1 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Increment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.numeric_Increment);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.btnIncrement);
            this.groupBox2.Controls.Add(this.autoSend);
            this.groupBox2.Controls.Add(this.btnSendData);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.comboBoxEncoding);
            this.groupBox2.Controls.Add(this.btnClearSend);
            this.groupBox2.Location = new System.Drawing.Point(596, 368);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(330, 119);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "发送设置";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(259, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "byte";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(193, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "在第";
            // 
            // numeric_Increment
            // 
            this.numeric_Increment.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.numeric_Increment.Location = new System.Drawing.Point(224, 30);
            this.numeric_Increment.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numeric_Increment.Name = "numeric_Increment";
            this.numeric_Increment.Size = new System.Drawing.Size(34, 21);
            this.numeric_Increment.TabIndex = 18;
            this.numeric_Increment.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.numericUpDown1.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(194, 79);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(66, 21);
            this.numericUpDown1.TabIndex = 18;
            this.numericUpDown1.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // btnIncrement
            // 
            this.btnIncrement.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnIncrement.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnIncrement.Location = new System.Drawing.Point(97, 18);
            this.btnIncrement.Margin = new System.Windows.Forms.Padding(4);
            this.btnIncrement.Name = "btnIncrement";
            this.btnIncrement.Size = new System.Drawing.Size(88, 41);
            this.btnIncrement.TabIndex = 9;
            this.btnIncrement.Text = "递增自动发送";
            this.btnIncrement.UseVisualStyleBackColor = false;
            this.btnIncrement.Click += new System.EventHandler(this.btnIncrement_Click);
            // 
            // autoSend
            // 
            this.autoSend.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.autoSend.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.autoSend.Location = new System.Drawing.Point(97, 67);
            this.autoSend.Margin = new System.Windows.Forms.Padding(4);
            this.autoSend.Name = "autoSend";
            this.autoSend.Size = new System.Drawing.Size(88, 41);
            this.autoSend.TabIndex = 9;
            this.autoSend.Text = "正常自动发送";
            this.autoSend.UseVisualStyleBackColor = false;
            this.autoSend.Click += new System.EventHandler(this.autoSend_Click);
            // 
            // btnSendData
            // 
            this.btnSendData.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnSendData.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSendData.Location = new System.Drawing.Point(12, 18);
            this.btnSendData.Margin = new System.Windows.Forms.Padding(4);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(77, 41);
            this.btnSendData.TabIndex = 9;
            this.btnSendData.Text = "发送数据";
            this.btnSendData.UseVisualStyleBackColor = false;
            this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10F);
            this.label7.Location = new System.Drawing.Point(260, 81);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 14);
            this.label7.TabIndex = 4;
            this.label7.Text = "ms";
            // 
            // comboBoxEncoding
            // 
            this.comboBoxEncoding.AutoSize = true;
            this.comboBoxEncoding.Checked = true;
            this.comboBoxEncoding.CheckState = System.Windows.Forms.CheckState.Checked;
            this.comboBoxEncoding.Location = new System.Drawing.Point(192, 11);
            this.comboBoxEncoding.Name = "comboBoxEncoding";
            this.comboBoxEncoding.Size = new System.Drawing.Size(42, 16);
            this.comboBoxEncoding.TabIndex = 15;
            this.comboBoxEncoding.Text = "Hex";
            this.comboBoxEncoding.UseVisualStyleBackColor = true;
            // 
            // btnClearSend
            // 
            this.btnClearSend.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnClearSend.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnClearSend.Location = new System.Drawing.Point(12, 67);
            this.btnClearSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearSend.Name = "btnClearSend";
            this.btnClearSend.Size = new System.Drawing.Size(77, 41);
            this.btnClearSend.TabIndex = 9;
            this.btnClearSend.Text = "清空发送";
            this.btnClearSend.UseVisualStyleBackColor = false;
            this.btnClearSend.Click += new System.EventHandler(this.btnClearSend_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F);
            this.label5.Location = new System.Drawing.Point(8, 219);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "停止位:";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(81, 17);
            this.toolStripStatusLabel1.Text = "串口通信V2.0";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 576);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1011, 22);
            this.statusStrip1.TabIndex = 23;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // textBoxRecv
            // 
            this.textBoxRecv.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxRecv.Location = new System.Drawing.Point(6, 20);
            this.textBoxRecv.Multiline = true;
            this.textBoxRecv.Name = "textBoxRecv";
            this.textBoxRecv.ReadOnly = true;
            this.textBoxRecv.Size = new System.Drawing.Size(559, 277);
            this.textBoxRecv.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.Location = new System.Drawing.Point(10, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "端口号:\n";
            // 
            // textBoxSend
            // 
            this.textBoxSend.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxSend.Location = new System.Drawing.Point(13, 20);
            this.textBoxSend.Multiline = true;
            this.textBoxSend.Name = "textBoxSend";
            this.textBoxSend.Size = new System.Drawing.Size(558, 40);
            this.textBoxSend.TabIndex = 22;
            // 
            // checkBoxHexShow
            // 
            this.checkBoxHexShow.AutoSize = true;
            this.checkBoxHexShow.Checked = true;
            this.checkBoxHexShow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHexShow.Font = new System.Drawing.Font("宋体", 9F);
            this.checkBoxHexShow.Location = new System.Drawing.Point(12, 325);
            this.checkBoxHexShow.Name = "checkBoxHexShow";
            this.checkBoxHexShow.Size = new System.Drawing.Size(42, 16);
            this.checkBoxHexShow.TabIndex = 15;
            this.checkBoxHexShow.Text = "Hex";
            this.checkBoxHexShow.UseVisualStyleBackColor = true;
            // 
            // cobxStopbit
            // 
            this.cobxStopbit.Font = new System.Drawing.Font("宋体", 9F);
            this.cobxStopbit.FormattingEnabled = true;
            this.cobxStopbit.Location = new System.Drawing.Point(63, 216);
            this.cobxStopbit.Margin = new System.Windows.Forms.Padding(4);
            this.cobxStopbit.Name = "cobxStopbit";
            this.cobxStopbit.Size = new System.Drawing.Size(112, 20);
            this.cobxStopbit.TabIndex = 10;
            // 
            // btnDetect
            // 
            this.btnDetect.BackColor = System.Drawing.SystemColors.Info;
            this.btnDetect.Font = new System.Drawing.Font("宋体", 9F);
            this.btnDetect.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnDetect.Location = new System.Drawing.Point(8, 22);
            this.btnDetect.Margin = new System.Windows.Forms.Padding(4);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.Size = new System.Drawing.Size(46, 30);
            this.btnDetect.TabIndex = 9;
            this.btnDetect.Text = "检测";
            this.btnDetect.UseVisualStyleBackColor = false;
            this.btnDetect.Click += new System.EventHandler(this.btnDetect_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F);
            this.label4.Location = new System.Drawing.Point(10, 177);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "数据位:\n";
            // 
            // btnCleanAccept
            // 
            this.btnCleanAccept.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnCleanAccept.Font = new System.Drawing.Font("宋体", 9F);
            this.btnCleanAccept.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCleanAccept.Location = new System.Drawing.Point(12, 285);
            this.btnCleanAccept.Margin = new System.Windows.Forms.Padding(4);
            this.btnCleanAccept.Name = "btnCleanAccept";
            this.btnCleanAccept.Size = new System.Drawing.Size(71, 23);
            this.btnCleanAccept.TabIndex = 9;
            this.btnCleanAccept.Text = "清除接收";
            this.btnCleanAccept.UseVisualStyleBackColor = false;
            this.btnCleanAccept.Click += new System.EventHandler(this.btnCleanAccept_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.Location = new System.Drawing.Point(10, 132);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "校验位:\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.Location = new System.Drawing.Point(10, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "波特率:\n";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnSave.Font = new System.Drawing.Font("宋体", 9F);
            this.btnSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSave.Location = new System.Drawing.Point(104, 285);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(71, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "保存窗口";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPortOnOff
            // 
            this.btnPortOnOff.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnPortOnOff.Font = new System.Drawing.Font("宋体", 9F);
            this.btnPortOnOff.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPortOnOff.Location = new System.Drawing.Point(74, 254);
            this.btnPortOnOff.Margin = new System.Windows.Forms.Padding(4);
            this.btnPortOnOff.Name = "btnPortOnOff";
            this.btnPortOnOff.Size = new System.Drawing.Size(71, 23);
            this.btnPortOnOff.TabIndex = 9;
            this.btnPortOnOff.Text = "打开串口";
            this.btnPortOnOff.UseVisualStyleBackColor = false;
            this.btnPortOnOff.Click += new System.EventHandler(this.btnPortOnOff_Click);
            // 
            // cobxDataBits
            // 
            this.cobxDataBits.Font = new System.Drawing.Font("宋体", 9F);
            this.cobxDataBits.FormattingEnabled = true;
            this.cobxDataBits.Location = new System.Drawing.Point(65, 174);
            this.cobxDataBits.Margin = new System.Windows.Forms.Padding(4);
            this.cobxDataBits.Name = "cobxDataBits";
            this.cobxDataBits.Size = new System.Drawing.Size(112, 20);
            this.cobxDataBits.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F);
            this.label6.Location = new System.Drawing.Point(7, 259);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "串口操作:";
            // 
            // cobxCheck
            // 
            this.cobxCheck.Font = new System.Drawing.Font("宋体", 9F);
            this.cobxCheck.FormattingEnabled = true;
            this.cobxCheck.Location = new System.Drawing.Point(65, 129);
            this.cobxCheck.Margin = new System.Windows.Forms.Padding(4);
            this.cobxCheck.Name = "cobxCheck";
            this.cobxCheck.Size = new System.Drawing.Size(112, 20);
            this.cobxCheck.TabIndex = 12;
            // 
            // cobxPort
            // 
            this.cobxPort.Font = new System.Drawing.Font("宋体", 9F);
            this.cobxPort.FormattingEnabled = true;
            this.cobxPort.Location = new System.Drawing.Point(65, 53);
            this.cobxPort.Margin = new System.Windows.Forms.Padding(4);
            this.cobxPort.Name = "cobxPort";
            this.cobxPort.Size = new System.Drawing.Size(112, 20);
            this.cobxPort.TabIndex = 14;
            // 
            // cobxBaudrate
            // 
            this.cobxBaudrate.Font = new System.Drawing.Font("宋体", 9F);
            this.cobxBaudrate.FormattingEnabled = true;
            this.cobxBaudrate.Location = new System.Drawing.Point(65, 91);
            this.cobxBaudrate.Margin = new System.Windows.Forms.Padding(4);
            this.cobxBaudrate.Name = "cobxBaudrate";
            this.cobxBaudrate.Size = new System.Drawing.Size(112, 20);
            this.cobxBaudrate.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkBoxHexShow);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cobxStopbit);
            this.groupBox1.Controls.Add(this.btnDetect);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnCleanAccept);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnPortOnOff);
            this.groupBox1.Controls.Add(this.cobxDataBits);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cobxCheck);
            this.groupBox1.Controls.Add(this.cobxPort);
            this.groupBox1.Controls.Add(this.cobxBaudrate);
            this.groupBox1.Controls.Add(this.checkBoxTimeShow);
            this.groupBox1.Font = new System.Drawing.Font("华文行楷", 10.5F);
            this.groupBox1.Location = new System.Drawing.Point(791, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(195, 355);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "端口设置";
            // 
            // checkBoxTimeShow
            // 
            this.checkBoxTimeShow.AutoSize = true;
            this.checkBoxTimeShow.Font = new System.Drawing.Font("宋体", 9F);
            this.checkBoxTimeShow.Location = new System.Drawing.Point(77, 325);
            this.checkBoxTimeShow.Name = "checkBoxTimeShow";
            this.checkBoxTimeShow.Size = new System.Drawing.Size(60, 16);
            this.checkBoxTimeShow.TabIndex = 15;
            this.checkBoxTimeShow.Text = "时间戳";
            this.checkBoxTimeShow.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxRecv);
            this.groupBox3.Font = new System.Drawing.Font("华文行楷", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(12, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(571, 308);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "接收信息框";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Controls.Add(this.textBoxSend);
            this.groupBox4.Font = new System.Drawing.Font("华文行楷", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(12, 327);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(577, 71);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "发送信息框";
            // 
            // textBoxExtract
            // 
            this.textBoxExtract.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxExtract.Location = new System.Drawing.Point(6, 20);
            this.textBoxExtract.Multiline = true;
            this.textBoxExtract.Name = "textBoxExtract";
            this.textBoxExtract.ReadOnly = true;
            this.textBoxExtract.Size = new System.Drawing.Size(170, 277);
            this.textBoxExtract.TabIndex = 23;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBoxExtract);
            this.groupBox5.Font = new System.Drawing.Font("华文行楷", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox5.Location = new System.Drawing.Point(590, 7);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(182, 307);
            this.groupBox5.TabIndex = 27;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "提取框";
            // 
            // btnHideorShow
            // 
            this.btnHideorShow.BackColor = System.Drawing.SystemColors.Info;
            this.btnHideorShow.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHideorShow.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnHideorShow.Location = new System.Drawing.Point(532, 405);
            this.btnHideorShow.Margin = new System.Windows.Forms.Padding(4);
            this.btnHideorShow.Name = "btnHideorShow";
            this.btnHideorShow.Size = new System.Drawing.Size(51, 29);
            this.btnHideorShow.TabIndex = 9;
            this.btnHideorShow.Text = "显示";
            this.btnHideorShow.UseVisualStyleBackColor = false;
            this.btnHideorShow.Click += new System.EventHandler(this.btnHideorShow_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(13, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(479, 21);
            this.textBox1.TabIndex = 22;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.t4);
            this.groupBox6.Controls.Add(this.t3);
            this.groupBox6.Controls.Add(this.t2);
            this.groupBox6.Controls.Add(this.t1);
            this.groupBox6.Controls.Add(this.btn_send4);
            this.groupBox6.Controls.Add(this.btn_send2);
            this.groupBox6.Controls.Add(this.btn_send3);
            this.groupBox6.Controls.Add(this.btn_send1);
            this.groupBox6.Controls.Add(this.textBox4);
            this.groupBox6.Controls.Add(this.textBox3);
            this.groupBox6.Controls.Add(this.textBox2);
            this.groupBox6.Controls.Add(this.textBox1);
            this.groupBox6.Font = new System.Drawing.Font("华文行楷", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox6.Location = new System.Drawing.Point(12, 434);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(577, 130);
            this.groupBox6.TabIndex = 27;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "拓展数据";
            // 
            // t4
            // 
            this.t4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.t4.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t4.Location = new System.Drawing.Point(416, 98);
            this.t4.Name = "t4";
            this.t4.Size = new System.Drawing.Size(76, 23);
            this.t4.TabIndex = 25;
            // 
            // t3
            // 
            this.t3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.t3.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t3.Location = new System.Drawing.Point(416, 72);
            this.t3.Name = "t3";
            this.t3.Size = new System.Drawing.Size(76, 23);
            this.t3.TabIndex = 25;
            // 
            // t2
            // 
            this.t2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.t2.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t2.Location = new System.Drawing.Point(416, 47);
            this.t2.Name = "t2";
            this.t2.Size = new System.Drawing.Size(76, 23);
            this.t2.TabIndex = 25;
            // 
            // t1
            // 
            this.t1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.t1.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t1.Location = new System.Drawing.Point(416, 18);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(76, 23);
            this.t1.TabIndex = 25;
            // 
            // btn_send4
            // 
            this.btn_send4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_send4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_send4.Location = new System.Drawing.Point(499, 98);
            this.btn_send4.Margin = new System.Windows.Forms.Padding(4);
            this.btn_send4.Name = "btn_send4";
            this.btn_send4.Size = new System.Drawing.Size(66, 23);
            this.btn_send4.TabIndex = 24;
            this.btn_send4.Text = "发送";
            this.btn_send4.UseVisualStyleBackColor = false;
            this.btn_send4.Click += new System.EventHandler(this.btn_send4_Click);
            // 
            // btn_send2
            // 
            this.btn_send2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_send2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_send2.Location = new System.Drawing.Point(499, 47);
            this.btn_send2.Margin = new System.Windows.Forms.Padding(4);
            this.btn_send2.Name = "btn_send2";
            this.btn_send2.Size = new System.Drawing.Size(66, 23);
            this.btn_send2.TabIndex = 24;
            this.btn_send2.Text = "发送";
            this.btn_send2.UseVisualStyleBackColor = false;
            this.btn_send2.Click += new System.EventHandler(this.btn_send2_Click);
            // 
            // btn_send3
            // 
            this.btn_send3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_send3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_send3.Location = new System.Drawing.Point(499, 72);
            this.btn_send3.Margin = new System.Windows.Forms.Padding(4);
            this.btn_send3.Name = "btn_send3";
            this.btn_send3.Size = new System.Drawing.Size(66, 23);
            this.btn_send3.TabIndex = 24;
            this.btn_send3.Text = "发送";
            this.btn_send3.UseVisualStyleBackColor = false;
            this.btn_send3.Click += new System.EventHandler(this.btn_send3_Click);
            // 
            // btn_send1
            // 
            this.btn_send1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_send1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_send1.Location = new System.Drawing.Point(499, 18);
            this.btn_send1.Margin = new System.Windows.Forms.Padding(4);
            this.btn_send1.Name = "btn_send1";
            this.btn_send1.Size = new System.Drawing.Size(66, 24);
            this.btn_send1.TabIndex = 24;
            this.btn_send1.Text = "发送";
            this.btn_send1.UseVisualStyleBackColor = false;
            this.btn_send1.Click += new System.EventHandler(this.btn_send1_Click);
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox4.Location = new System.Drawing.Point(13, 99);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(479, 21);
            this.textBox4.TabIndex = 23;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox3.Location = new System.Drawing.Point(13, 72);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(479, 21);
            this.textBox3.TabIndex = 22;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(13, 47);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(479, 21);
            this.textBox2.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1011, 598);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btnHideorShow);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Increment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button autoSend;
        private System.Windows.Forms.Button btnSendData;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox comboBoxEncoding;
        private System.Windows.Forms.Button btnClearSend;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSend;
        private System.Windows.Forms.CheckBox checkBoxHexShow;
        private System.Windows.Forms.ComboBox cobxStopbit;
        private System.Windows.Forms.Button btnDetect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCleanAccept;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPortOnOff;
        private System.Windows.Forms.ComboBox cobxDataBits;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cobxCheck;
        private System.Windows.Forms.ComboBox cobxPort;
        private System.Windows.Forms.ComboBox cobxBaudrate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxTimeShow;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxExtract;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBoxRecv;
        private System.Windows.Forms.Button btnHideorShow;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btn_send1;
        private System.Windows.Forms.Button btn_send2;
        private System.Windows.Forms.Button btn_send4;
        private System.Windows.Forms.Button btn_send3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox t1;
        private System.Windows.Forms.TextBox t4;
        private System.Windows.Forms.TextBox t3;
        private System.Windows.Forms.TextBox t2;
        private System.Windows.Forms.Button btnIncrement;
        private System.Windows.Forms.NumericUpDown numeric_Increment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

