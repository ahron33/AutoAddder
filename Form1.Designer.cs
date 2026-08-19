namespace AutoAddder
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button3 = new System.Windows.Forms.Button();
            this.point_timer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.attempts_x = new System.Windows.Forms.TextBox();
            this.attempts_y = new System.Windows.Forms.TextBox();
            this.telegramkitx = new System.Windows.Forms.TextBox();
            this.telegramkity = new System.Windows.Forms.TextBox();
            this.vpnx = new System.Windows.Forms.TextBox();
            this.vpny = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.interupty = new System.Windows.Forms.TextBox();
            this.interuptx = new System.Windows.Forms.TextBox();
            this.searchPath = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.accountstextbox = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.update_btn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.WorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.StatusAcc = new System.Windows.Forms.Label();
            this.newSms = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.pathbtn = new System.Windows.Forms.Button();
            this.numbtn = new System.Windows.Forms.Button();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.stopsms = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.eachUserbox = new System.Windows.Forms.TextBox();
            this.averageMath = new System.Windows.Forms.Label();
            this.attemptsBox = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.ModeBox = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.playBack = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.usernamebox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkB = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.vpnBox = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(151, 106);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(61, 19);
            this.button3.TabIndex = 2;
            this.button3.Text = "X_&_Y";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // point_timer
            // 
            this.point_timer.Interval = 1;
            this.point_timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 596);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Waiting...";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(115, 107);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(94, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "Start";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(84, 106);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(61, 19);
            this.button7.TabIndex = 7;
            this.button7.Text = "Set-Points";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // attempts_x
            // 
            this.attempts_x.Location = new System.Drawing.Point(29, 0);
            this.attempts_x.Name = "attempts_x";
            this.attempts_x.Size = new System.Drawing.Size(46, 20);
            this.attempts_x.TabIndex = 8;
            // 
            // attempts_y
            // 
            this.attempts_y.Location = new System.Drawing.Point(101, 1);
            this.attempts_y.Name = "attempts_y";
            this.attempts_y.Size = new System.Drawing.Size(46, 20);
            this.attempts_y.TabIndex = 9;
            // 
            // telegramkitx
            // 
            this.telegramkitx.Location = new System.Drawing.Point(29, 28);
            this.telegramkitx.Name = "telegramkitx";
            this.telegramkitx.Size = new System.Drawing.Size(46, 20);
            this.telegramkitx.TabIndex = 10;
            // 
            // telegramkity
            // 
            this.telegramkity.Location = new System.Drawing.Point(101, 28);
            this.telegramkity.Name = "telegramkity";
            this.telegramkity.Size = new System.Drawing.Size(46, 20);
            this.telegramkity.TabIndex = 11;
            // 
            // vpnx
            // 
            this.vpnx.Location = new System.Drawing.Point(29, 54);
            this.vpnx.Name = "vpnx";
            this.vpnx.Size = new System.Drawing.Size(46, 20);
            this.vpnx.TabIndex = 12;
            // 
            // vpny
            // 
            this.vpny.Location = new System.Drawing.Point(101, 54);
            this.vpny.Name = "vpny";
            this.vpny.Size = new System.Drawing.Size(46, 20);
            this.vpny.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "X=";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "X=";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "X=";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(79, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Y=";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(79, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Y=";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(79, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Y=";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(149, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "‏‏Attempts";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(149, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "TelegramKit";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(148, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "‏‏VyperVpn";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(148, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Interupt";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(79, 85);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Y=";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 82);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "X=";
            // 
            // interupty
            // 
            this.interupty.Location = new System.Drawing.Point(101, 80);
            this.interupty.Name = "interupty";
            this.interupty.Size = new System.Drawing.Size(46, 20);
            this.interupty.TabIndex = 24;
            // 
            // interuptx
            // 
            this.interuptx.Location = new System.Drawing.Point(29, 80);
            this.interuptx.Name = "interuptx";
            this.interuptx.Size = new System.Drawing.Size(46, 20);
            this.interuptx.TabIndex = 23;
            // 
            // searchPath
            // 
            this.searchPath.Enabled = false;
            this.searchPath.Location = new System.Drawing.Point(408, 122);
            this.searchPath.Name = "searchPath";
            this.searchPath.Size = new System.Drawing.Size(38, 21);
            this.searchPath.TabIndex = 11;
            this.searchPath.Text = "Search";
            this.searchPath.UseVisualStyleBackColor = true;
            this.searchPath.Click += new System.EventHandler(this.searchPath_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(5, 103);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 10;
            this.label15.Text = "Acounts:";
            // 
            // accountstextbox
            // 
            this.accountstextbox.Location = new System.Drawing.Point(58, 100);
            this.accountstextbox.Name = "accountstextbox";
            this.accountstextbox.Size = new System.Drawing.Size(26, 20);
            this.accountstextbox.TabIndex = 9;
            this.accountstextbox.Text = "0";
            this.accountstextbox.TextChanged += new System.EventHandler(this.accountstextbox_TextChanged);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(96, 33);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(28, 23);
            this.button8.TabIndex = 8;
            this.button8.Text = "Sms-Activate";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Visible = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.update_btn);
            this.panel2.Controls.Add(this.attempts_x);
            this.panel2.Controls.Add(this.attempts_y);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.telegramkitx);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.telegramkity);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.vpnx);
            this.panel2.Controls.Add(this.interupty);
            this.panel2.Controls.Add(this.vpny);
            this.panel2.Controls.Add(this.interuptx);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(15, 418);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(218, 128);
            this.panel2.TabIndex = 31;
            this.panel2.Tag = "";
            // 
            // update_btn
            // 
            this.update_btn.Location = new System.Drawing.Point(19, 106);
            this.update_btn.Name = "update_btn";
            this.update_btn.Size = new System.Drawing.Size(59, 20);
            this.update_btn.TabIndex = 28;
            this.update_btn.Text = "Update";
            this.update_btn.UseVisualStyleBackColor = true;
            this.update_btn.Click += new System.EventHandler(this.update_btn_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(404, 115);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(22, 15);
            this.button2.TabIndex = 8;
            this.button2.Text = "Disable";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(284, 117);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "Anti-virus";
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(340, 115);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(58, 12);
            this.button6.TabIndex = 32;
            this.button6.Text = "Enable";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // WorkerSearch
            // 
            this.WorkerSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.WorkerSearch_DoWork);
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.comboBox.Items.AddRange(new object[] {
            "France",
            "Russian",
            "Usa",
            "Usa (Virtual)",
            "Brazil",
            "Poland",
            "England",
            "Israel"});
            this.comboBox.Location = new System.Drawing.Point(3, 4);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(121, 21);
            this.comboBox.TabIndex = 33;
            this.comboBox.Text = "Select Country";
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 402);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(33, 13);
            this.label16.TabIndex = 34;
            this.label16.Text = "Data:";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.StatusAcc);
            this.panel3.Controls.Add(this.newSms);
            this.panel3.Controls.Add(this.webBrowser1);
            this.panel3.Controls.Add(this.pathbtn);
            this.panel3.Controls.Add(this.numbtn);
            this.panel3.Controls.Add(this.checkBox);
            this.panel3.Controls.Add(this.stopsms);
            this.panel3.Controls.Add(this.comboBox);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.button8);
            this.panel3.Controls.Add(this.accountstextbox);
            this.panel3.Location = new System.Drawing.Point(15, 274);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(213, 125);
            this.panel3.TabIndex = 35;
            // 
            // StatusAcc
            // 
            this.StatusAcc.AutoSize = true;
            this.StatusAcc.Location = new System.Drawing.Point(152, 83);
            this.StatusAcc.Name = "StatusAcc";
            this.StatusAcc.Size = new System.Drawing.Size(56, 13);
            this.StatusAcc.TabIndex = 47;
            this.StatusAcc.Text = "StatusAcc";
            this.StatusAcc.MouseHover += new System.EventHandler(this.StatusAcc_MouseHover);
            // 
            // newSms
            // 
            this.newSms.Location = new System.Drawing.Point(133, 99);
            this.newSms.Name = "newSms";
            this.newSms.Size = new System.Drawing.Size(75, 23);
            this.newSms.TabIndex = 42;
            this.newSms.Text = "New";
            this.newSms.UseVisualStyleBackColor = true;
            this.newSms.Click += new System.EventHandler(this.newSms_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(3, 31);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(47, 20);
            this.webBrowser1.TabIndex = 41;
            this.webBrowser1.TabStop = false;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // pathbtn
            // 
            this.pathbtn.Location = new System.Drawing.Point(129, 4);
            this.pathbtn.Name = "pathbtn";
            this.pathbtn.Size = new System.Drawing.Size(81, 23);
            this.pathbtn.TabIndex = 37;
            this.pathbtn.Text = "Path";
            this.pathbtn.UseVisualStyleBackColor = true;
            this.pathbtn.Click += new System.EventHandler(this.pathbtn_Click);
            // 
            // numbtn
            // 
            this.numbtn.Location = new System.Drawing.Point(129, 33);
            this.numbtn.Name = "numbtn";
            this.numbtn.Size = new System.Drawing.Size(81, 23);
            this.numbtn.TabIndex = 36;
            this.numbtn.Text = "Numbers";
            this.numbtn.UseVisualStyleBackColor = true;
            this.numbtn.Click += new System.EventHandler(this.numbtn_Click);
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(8, 77);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(50, 17);
            this.checkBox.TabIndex = 35;
            this.checkBox.Text = "Loop";
            this.checkBox.UseVisualStyleBackColor = true;
            // 
            // stopsms
            // 
            this.stopsms.ForeColor = System.Drawing.Color.Red;
            this.stopsms.Location = new System.Drawing.Point(98, 100);
            this.stopsms.Name = "stopsms";
            this.stopsms.Size = new System.Drawing.Size(27, 22);
            this.stopsms.TabIndex = 34;
            this.stopsms.Text = "X";
            this.stopsms.UseVisualStyleBackColor = true;
            this.stopsms.Visible = false;
            this.stopsms.Click += new System.EventHandler(this.stopsms_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(15, 258);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 13);
            this.label17.TabIndex = 36;
            this.label17.Text = "Accounts:";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label24);
            this.panel4.Controls.Add(this.eachUserbox);
            this.panel4.Controls.Add(this.averageMath);
            this.panel4.Controls.Add(this.attemptsBox);
            this.panel4.Controls.Add(this.label23);
            this.panel4.Controls.Add(this.label21);
            this.panel4.Controls.Add(this.ModeBox);
            this.panel4.Controls.Add(this.label19);
            this.panel4.Controls.Add(this.playBack);
            this.panel4.Controls.Add(this.button5);
            this.panel4.Location = new System.Drawing.Point(16, 121);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(212, 133);
            this.panel4.TabIndex = 37;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(7, 32);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(72, 13);
            this.label24.TabIndex = 50;
            this.label24.Text = "ForEachUser:";
            // 
            // eachUserbox
            // 
            this.eachUserbox.Location = new System.Drawing.Point(85, 29);
            this.eachUserbox.Name = "eachUserbox";
            this.eachUserbox.Size = new System.Drawing.Size(31, 20);
            this.eachUserbox.TabIndex = 49;
            this.eachUserbox.Text = "0";
            this.eachUserbox.TextChanged += new System.EventHandler(this.eachUserbox_TextChanged);
            // 
            // averageMath
            // 
            this.averageMath.AutoSize = true;
            this.averageMath.Location = new System.Drawing.Point(6, 115);
            this.averageMath.Name = "averageMath";
            this.averageMath.Size = new System.Drawing.Size(55, 13);
            this.averageMath.TabIndex = 48;
            this.averageMath.Text = "average...";
            // 
            // attemptsBox
            // 
            this.attemptsBox.Location = new System.Drawing.Point(67, 52);
            this.attemptsBox.Name = "attemptsBox";
            this.attemptsBox.Size = new System.Drawing.Size(31, 20);
            this.attemptsBox.TabIndex = 47;
            this.attemptsBox.Text = "0";
            this.attemptsBox.TextChanged += new System.EventHandler(this.attemptsBox_TextChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(7, 55);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(51, 13);
            this.label23.TabIndex = 45;
            this.label23.Text = "‏‏Attempts:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 8);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(37, 13);
            this.label21.TabIndex = 43;
            this.label21.Text = "Mode:";
            // 
            // ModeBox
            // 
            this.ModeBox.FormattingEnabled = true;
            this.ModeBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.ModeBox.Items.AddRange(new object[] {
            "Adding",
            "Authorizing",
            "Leave"});
            this.ModeBox.Location = new System.Drawing.Point(50, 5);
            this.ModeBox.Name = "ModeBox";
            this.ModeBox.Size = new System.Drawing.Size(121, 21);
            this.ModeBox.TabIndex = 42;
            this.ModeBox.Text = "Select a Mode";
            this.ModeBox.SelectedIndexChanged += new System.EventHandler(this.ModeBox_SelectedIndexChanged);
            this.ModeBox.SelectionChangeCommitted += new System.EventHandler(this.ModeBox_SelectionChangeCommitted);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(7, 78);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(55, 13);
            this.label19.TabIndex = 39;
            this.label19.Text = "PlayBack:";
            // 
            // playBack
            // 
            this.playBack.Location = new System.Drawing.Point(67, 75);
            this.playBack.Name = "playBack";
            this.playBack.Size = new System.Drawing.Size(31, 20);
            this.playBack.TabIndex = 38;
            this.playBack.Text = "0";
            this.playBack.TextChanged += new System.EventHandler(this.playBack_TextChanged);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(283, 130);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(78, 13);
            this.label.TabIndex = 33;
            this.label.Text = "SearchForPath";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 106);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(188, 13);
            this.label18.TabIndex = 38;
            this.label18.Text = "Add/Update Profiles/Leave all Groups";
            this.label18.Click += new System.EventHandler(this.label18_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.usernamebox);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(15, 568);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(218, 25);
            this.panel1.TabIndex = 39;
            // 
            // usernamebox
            // 
            this.usernamebox.FormattingEnabled = true;
            this.usernamebox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.usernamebox.Items.AddRange(new object[] {
            "@candy1231",
            "@lilbabeweed",
            "@dobby420_isr",
            "@monalisa077"});
            this.usernamebox.Location = new System.Drawing.Point(1, 0);
            this.usernamebox.Name = "usernamebox";
            this.usernamebox.Size = new System.Drawing.Size(121, 21);
            this.usernamebox.TabIndex = 34;
            this.usernamebox.Text = "Select Username";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(148, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 21);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(13, 550);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(43, 13);
            this.label20.TabIndex = 40;
            this.label20.Text = "Bikorot:";
            this.label20.Click += new System.EventHandler(this.label20_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // checkB
            // 
            this.checkB.AutoSize = true;
            this.checkB.Location = new System.Drawing.Point(164, 597);
            this.checkB.Name = "checkB";
            this.checkB.Size = new System.Drawing.Size(68, 17);
            this.checkB.TabIndex = 41;
            this.checkB.Text = "TopMost";
            this.checkB.UseVisualStyleBackColor = true;
            this.checkB.CheckedChanged += new System.EventHandler(this.checkB_CheckedChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(12, 9);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(29, 13);
            this.label22.TabIndex = 42;
            this.label22.Text = "VPN";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.vpnBox);
            this.panel5.Location = new System.Drawing.Point(15, 25);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(218, 78);
            this.panel5.TabIndex = 40;
            // 
            // vpnBox
            // 
            this.vpnBox.FormattingEnabled = true;
            this.vpnBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.vpnBox.Items.AddRange(new object[] {
            "‏‏VyprVPN",
            "CyberVpn"});
            this.vpnBox.Location = new System.Drawing.Point(4, 3);
            this.vpnBox.Name = "vpnBox";
            this.vpnBox.Size = new System.Drawing.Size(121, 21);
            this.vpnBox.TabIndex = 34;
            this.vpnBox.Text = "Select Vpn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 612);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.checkB);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.searchPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer point_timer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox attempts_x;
        private System.Windows.Forms.TextBox attempts_y;
        private System.Windows.Forms.TextBox telegramkitx;
        private System.Windows.Forms.TextBox telegramkity;
        private System.Windows.Forms.TextBox vpnx;
        private System.Windows.Forms.TextBox vpny;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox interupty;
        private System.Windows.Forms.TextBox interuptx;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox accountstextbox;
        private System.ComponentModel.BackgroundWorker WorkerSearch;
        private System.Windows.Forms.Button searchPath;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button stopsms;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.Button numbtn;
        private System.Windows.Forms.Button pathbtn;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox playBack;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox usernamebox;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox ModeBox;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox attemptsBox;
        private System.Windows.Forms.Label averageMath;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox eachUserbox;
        public System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Button newSms;
        private System.Windows.Forms.Button update_btn;
        private System.Windows.Forms.Label StatusAcc;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox checkB;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox vpnBox;
    }
}

