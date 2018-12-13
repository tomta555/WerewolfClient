namespace WerewolfClient
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnAction = new System.Windows.Forms.Button();
            this.BtnVote = new System.Windows.Forms.Button();
            this.TbChatInput = new System.Windows.Forms.TextBox();
            this.TbChatBox = new System.Windows.Forms.TextBox();
            this.LBPeriod = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LBTime = new System.Windows.Forms.Label();
            this.LBDay = new System.Windows.Forms.Label();
            this.ChatPanel = new System.Windows.Forms.Panel();
            this.SystemOutBox = new System.Windows.Forms.TextBox();
            this.ButtonBG = new System.Windows.Forms.Button();
            this.BtnJoin = new System.Windows.Forms.Button();
            this.BtnPlayer7 = new System.Windows.Forms.Button();
            this.BtnPlayer6 = new System.Windows.Forms.Button();
            this.BtnPlayer5 = new System.Windows.Forms.Button();
            this.BtnPlayer4 = new System.Windows.Forms.Button();
            this.BtnPlayer2 = new System.Windows.Forms.Button();
            this.BtnPlayer3 = new System.Windows.Forms.Button();
            this.BtnPlayer1 = new System.Windows.Forms.Button();
            this.BtnPlayer0 = new System.Windows.Forms.Button();
            this.BtnPlayer15 = new System.Windows.Forms.Button();
            this.BtnPlayer14 = new System.Windows.Forms.Button();
            this.BtnPlayer13 = new System.Windows.Forms.Button();
            this.BtnPlayer12 = new System.Windows.Forms.Button();
            this.BtnPlayer11 = new System.Windows.Forms.Button();
            this.BtnPlayer10 = new System.Windows.Forms.Button();
            this.BtnPlayer9 = new System.Windows.Forms.Button();
            this.BtnPlayer8 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.ChatPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnAction);
            this.panel1.Controls.Add(this.BtnVote);
            this.panel1.Controls.Add(this.BtnJoin);
            this.panel1.Controls.Add(this.BtnPlayer7);
            this.panel1.Controls.Add(this.BtnPlayer6);
            this.panel1.Controls.Add(this.BtnPlayer5);
            this.panel1.Controls.Add(this.BtnPlayer4);
            this.panel1.Controls.Add(this.BtnPlayer2);
            this.panel1.Controls.Add(this.BtnPlayer3);
            this.panel1.Controls.Add(this.BtnPlayer1);
            this.panel1.Controls.Add(this.BtnPlayer0);
            this.panel1.Controls.Add(this.BtnPlayer15);
            this.panel1.Controls.Add(this.BtnPlayer14);
            this.panel1.Controls.Add(this.BtnPlayer13);
            this.panel1.Controls.Add(this.BtnPlayer12);
            this.panel1.Controls.Add(this.BtnPlayer11);
            this.panel1.Controls.Add(this.BtnPlayer10);
            this.panel1.Controls.Add(this.BtnPlayer9);
            this.panel1.Controls.Add(this.BtnPlayer8);
            this.panel1.Location = new System.Drawing.Point(-64, 209);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1924, 690);
            this.panel1.TabIndex = 0;
            // 
            // BtnAction
            // 
            this.BtnAction.Location = new System.Drawing.Point(214, 44);
            this.BtnAction.Margin = new System.Windows.Forms.Padding(4);
            this.BtnAction.Name = "BtnAction";
            this.BtnAction.Size = new System.Drawing.Size(100, 57);
            this.BtnAction.TabIndex = 18;
            this.BtnAction.Text = "Action";
            this.BtnAction.UseVisualStyleBackColor = true;
            this.BtnAction.Click += new System.EventHandler(this.BtnAction_Click);
            // 
            // BtnVote
            // 
            this.BtnVote.Location = new System.Drawing.Point(106, 44);
            this.BtnVote.Margin = new System.Windows.Forms.Padding(4);
            this.BtnVote.Name = "BtnVote";
            this.BtnVote.Size = new System.Drawing.Size(100, 57);
            this.BtnVote.TabIndex = 17;
            this.BtnVote.Text = "Vote";
            this.BtnVote.UseVisualStyleBackColor = true;
            this.BtnVote.Click += new System.EventHandler(this.BtnVote_Click);
            // 
            // TbChatInput
            // 
            this.TbChatInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbChatInput.Location = new System.Drawing.Point(17, 828);
            this.TbChatInput.Margin = new System.Windows.Forms.Padding(4);
            this.TbChatInput.Name = "TbChatInput";
            this.TbChatInput.Size = new System.Drawing.Size(471, 30);
            this.TbChatInput.TabIndex = 16;
            this.TbChatInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbChatInput_Enter);
            // 
            // TbChatBox
            // 
            this.TbChatBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbChatBox.Location = new System.Drawing.Point(17, 366);
            this.TbChatBox.Margin = new System.Windows.Forms.Padding(4);
            this.TbChatBox.Multiline = true;
            this.TbChatBox.Name = "TbChatBox";
            this.TbChatBox.ReadOnly = true;
            this.TbChatBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TbChatBox.Size = new System.Drawing.Size(471, 449);
            this.TbChatBox.TabIndex = 1;
            // 
            // LBPeriod
            // 
            this.LBPeriod.AutoSize = true;
            this.LBPeriod.Location = new System.Drawing.Point(28, 28);
            this.LBPeriod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBPeriod.Name = "LBPeriod";
            this.LBPeriod.Size = new System.Drawing.Size(57, 17);
            this.LBPeriod.TabIndex = 21;
            this.LBPeriod.Text = "Night of";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(416, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "Day #";
            // 
            // LBTime
            // 
            this.LBTime.AutoSize = true;
            this.LBTime.Location = new System.Drawing.Point(463, 28);
            this.LBTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBTime.Name = "LBTime";
            this.LBTime.Size = new System.Drawing.Size(16, 17);
            this.LBTime.TabIndex = 23;
            this.LBTime.Text = "0";
            // 
            // LBDay
            // 
            this.LBDay.AutoSize = true;
            this.LBDay.Location = new System.Drawing.Point(260, 27);
            this.LBDay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBDay.Name = "LBDay";
            this.LBDay.Size = new System.Drawing.Size(16, 17);
            this.LBDay.TabIndex = 22;
            this.LBDay.Text = "0";
            // 
            // ChatPanel
            // 
            this.ChatPanel.Controls.Add(this.SystemOutBox);
            this.ChatPanel.Controls.Add(this.LBTime);
            this.ChatPanel.Controls.Add(this.TbChatBox);
            this.ChatPanel.Controls.Add(this.LBDay);
            this.ChatPanel.Controls.Add(this.TbChatInput);
            this.ChatPanel.Controls.Add(this.LBPeriod);
            this.ChatPanel.Controls.Add(this.label2);
            this.ChatPanel.Controls.Add(this.label1);
            this.ChatPanel.Location = new System.Drawing.Point(1359, 3);
            this.ChatPanel.Name = "ChatPanel";
            this.ChatPanel.Size = new System.Drawing.Size(504, 906);
            this.ChatPanel.TabIndex = 24;
            // 
            // SystemOutBox
            // 
            this.SystemOutBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SystemOutBox.Location = new System.Drawing.Point(17, 94);
            this.SystemOutBox.Margin = new System.Windows.Forms.Padding(4);
            this.SystemOutBox.Multiline = true;
            this.SystemOutBox.Name = "SystemOutBox";
            this.SystemOutBox.ReadOnly = true;
            this.SystemOutBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SystemOutBox.Size = new System.Drawing.Size(471, 235);
            this.SystemOutBox.TabIndex = 17;
            // 
            // ButtonBG
            // 
            this.ButtonBG.Location = new System.Drawing.Point(-1, -7);
            this.ButtonBG.Name = "ButtonBG";
            this.ButtonBG.Size = new System.Drawing.Size(1866, 887);
            this.ButtonBG.TabIndex = 25;
            this.ButtonBG.Text = "button1";
            this.ButtonBG.UseVisualStyleBackColor = true;
            // 
            // BtnJoin
            // 
            this.BtnJoin.BackgroundImage = global::WerewolfClient.Properties.Resources.Btn_join;
            this.BtnJoin.Location = new System.Drawing.Point(882, 16);
            this.BtnJoin.Name = "BtnJoin";
            this.BtnJoin.Size = new System.Drawing.Size(335, 113);
            this.BtnJoin.TabIndex = 15;
            this.BtnJoin.Text = "Join Game";
            this.BtnJoin.UseVisualStyleBackColor = true;
            this.BtnJoin.Click += new System.EventHandler(this.BtnJoin_Click);
            // 
            // BtnPlayer7
            // 
            this.BtnPlayer7.BackColor = System.Drawing.Color.Transparent;
            this.BtnPlayer7.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPlayer7.ForeColor = System.Drawing.Color.Black;
            this.BtnPlayer7.Image = ((System.Drawing.Image)(resources.GetObject("BtnPlayer7.Image")));
            this.BtnPlayer7.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnPlayer7.Location = new System.Drawing.Point(1289, 454);
            this.BtnPlayer7.Name = "BtnPlayer7";
            this.BtnPlayer7.Size = new System.Drawing.Size(101, 174);
            this.BtnPlayer7.TabIndex = 6;
            this.BtnPlayer7.Text = "8";
            this.BtnPlayer7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnPlayer7.UseVisualStyleBackColor = false;
            // 
            // BtnPlayer6
            // 
            this.BtnPlayer6.BackColor = System.Drawing.Color.Transparent;
            this.BtnPlayer6.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPlayer6.ForeColor = System.Drawing.Color.Black;
            this.BtnPlayer6.Image = ((System.Drawing.Image)(resources.GetObject("BtnPlayer6.Image")));
            this.BtnPlayer6.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnPlayer6.Location = new System.Drawing.Point(1122, 454);
            this.BtnPlayer6.Name = "BtnPlayer6";
            this.BtnPlayer6.Size = new System.Drawing.Size(101, 174);
            this.BtnPlayer6.TabIndex = 5;
            this.BtnPlayer6.Text = "7";
            this.BtnPlayer6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnPlayer6.UseVisualStyleBackColor = false;
            // 
            // BtnPlayer5
            // 
            this.BtnPlayer5.BackColor = System.Drawing.Color.Transparent;
            this.BtnPlayer5.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPlayer5.ForeColor = System.Drawing.Color.Black;
            this.BtnPlayer5.Image = ((System.Drawing.Image)(resources.GetObject("BtnPlayer5.Image")));
            this.BtnPlayer5.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnPlayer5.Location = new System.Drawing.Point(952, 455);
            this.BtnPlayer5.Name = "BtnPlayer5";
            this.BtnPlayer5.Size = new System.Drawing.Size(101, 174);
            this.BtnPlayer5.TabIndex = 4;
            this.BtnPlayer5.Text = "6";
            this.BtnPlayer5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnPlayer5.UseVisualStyleBackColor = false;
            // 
            // BtnPlayer4
            // 
            this.BtnPlayer4.BackColor = System.Drawing.Color.Transparent;
            this.BtnPlayer4.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPlayer4.ForeColor = System.Drawing.Color.Black;
            this.BtnPlayer4.Image = ((System.Drawing.Image)(resources.GetObject("BtnPlayer4.Image")));
            this.BtnPlayer4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnPlayer4.Location = new System.Drawing.Point(783, 454);
            this.BtnPlayer4.Name = "BtnPlayer4";
            this.BtnPlayer4.Size = new System.Drawing.Size(101, 174);
            this.BtnPlayer4.TabIndex = 3;
            this.BtnPlayer4.Text = "5";
            this.BtnPlayer4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnPlayer4.UseVisualStyleBackColor = false;
            // 
            // BtnPlayer2
            // 
            this.BtnPlayer2.BackColor = System.Drawing.Color.Transparent;
            this.BtnPlayer2.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPlayer2.ForeColor = System.Drawing.Color.Black;
            this.BtnPlayer2.Image = ((System.Drawing.Image)(resources.GetObject("BtnPlayer2.Image")));
            this.BtnPlayer2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnPlayer2.Location = new System.Drawing.Point(442, 454);
            this.BtnPlayer2.Name = "BtnPlayer2";
            this.BtnPlayer2.Size = new System.Drawing.Size(101, 174);
            this.BtnPlayer2.TabIndex = 2;
            this.BtnPlayer2.Text = "3";
            this.BtnPlayer2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnPlayer2.UseVisualStyleBackColor = false;
            // 
            // BtnPlayer3
            // 
            this.BtnPlayer3.BackColor = System.Drawing.Color.Transparent;
            this.BtnPlayer3.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPlayer3.ForeColor = System.Drawing.Color.Black;
            this.BtnPlayer3.Image = ((System.Drawing.Image)(resources.GetObject("BtnPlayer3.Image")));
            this.BtnPlayer3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnPlayer3.Location = new System.Drawing.Point(610, 454);
            this.BtnPlayer3.Name = "BtnPlayer3";
            this.BtnPlayer3.Size = new System.Drawing.Size(101, 174);
            this.BtnPlayer3.TabIndex = 2;
            this.BtnPlayer3.Text = "4";
            this.BtnPlayer3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnPlayer3.UseVisualStyleBackColor = false;
            // 
            // BtnPlayer1
            // 
            this.BtnPlayer1.BackColor = System.Drawing.Color.Transparent;
            this.BtnPlayer1.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPlayer1.ForeColor = System.Drawing.Color.Black;
            this.BtnPlayer1.Image = ((System.Drawing.Image)(resources.GetObject("BtnPlayer1.Image")));
            this.BtnPlayer1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnPlayer1.Location = new System.Drawing.Point(272, 454);
            this.BtnPlayer1.Name = "BtnPlayer1";
            this.BtnPlayer1.Size = new System.Drawing.Size(101, 174);
            this.BtnPlayer1.TabIndex = 1;
            this.BtnPlayer1.Text = "2";
            this.BtnPlayer1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnPlayer1.UseVisualStyleBackColor = false;
            // 
            // BtnPlayer0
            // 
            this.BtnPlayer0.BackColor = System.Drawing.Color.Transparent;
            this.BtnPlayer0.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPlayer0.ForeColor = System.Drawing.Color.Black;
            this.BtnPlayer0.Image = ((System.Drawing.Image)(resources.GetObject("BtnPlayer0.Image")));
            this.BtnPlayer0.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnPlayer0.Location = new System.Drawing.Point(106, 454);
            this.BtnPlayer0.Name = "BtnPlayer0";
            this.BtnPlayer0.Size = new System.Drawing.Size(97, 174);
            this.BtnPlayer0.TabIndex = 0;
            this.BtnPlayer0.Text = "1";
            this.BtnPlayer0.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnPlayer0.UseVisualStyleBackColor = false;
            // 
            // BtnPlayer15
            // 
            this.BtnPlayer15.BackColor = System.Drawing.Color.Transparent;
            this.BtnPlayer15.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPlayer15.ForeColor = System.Drawing.Color.Black;
            this.BtnPlayer15.Image = ((System.Drawing.Image)(resources.GetObject("BtnPlayer15.Image")));
            this.BtnPlayer15.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnPlayer15.Location = new System.Drawing.Point(1173, 247);
            this.BtnPlayer15.Name = "BtnPlayer15";
            this.BtnPlayer15.Size = new System.Drawing.Size(83, 164);
            this.BtnPlayer15.TabIndex = 14;
            this.BtnPlayer15.Text = "16";
            this.BtnPlayer15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnPlayer15.UseVisualStyleBackColor = false;
            // 
            // BtnPlayer14
            // 
            this.BtnPlayer14.BackColor = System.Drawing.Color.Transparent;
            this.BtnPlayer14.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPlayer14.ForeColor = System.Drawing.Color.Black;
            this.BtnPlayer14.Image = ((System.Drawing.Image)(resources.GetObject("BtnPlayer14.Image")));
            this.BtnPlayer14.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnPlayer14.Location = new System.Drawing.Point(1044, 247);
            this.BtnPlayer14.Name = "BtnPlayer14";
            this.BtnPlayer14.Size = new System.Drawing.Size(83, 164);
            this.BtnPlayer14.TabIndex = 13;
            this.BtnPlayer14.Text = "15";
            this.BtnPlayer14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnPlayer14.UseVisualStyleBackColor = false;
            // 
            // BtnPlayer13
            // 
            this.BtnPlayer13.BackColor = System.Drawing.Color.Transparent;
            this.BtnPlayer13.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPlayer13.ForeColor = System.Drawing.Color.Black;
            this.BtnPlayer13.Image = global::WerewolfClient.Properties.Resources.char_someone_resize;
            this.BtnPlayer13.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnPlayer13.Location = new System.Drawing.Point(910, 247);
            this.BtnPlayer13.Name = "BtnPlayer13";
            this.BtnPlayer13.Size = new System.Drawing.Size(83, 164);
            this.BtnPlayer13.TabIndex = 12;
            this.BtnPlayer13.Text = "14";
            this.BtnPlayer13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnPlayer13.UseVisualStyleBackColor = false;
            // 
            // BtnPlayer12
            // 
            this.BtnPlayer12.BackColor = System.Drawing.Color.Transparent;
            this.BtnPlayer12.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPlayer12.ForeColor = System.Drawing.Color.Black;
            this.BtnPlayer12.Image = ((System.Drawing.Image)(resources.GetObject("BtnPlayer12.Image")));
            this.BtnPlayer12.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnPlayer12.Location = new System.Drawing.Point(771, 247);
            this.BtnPlayer12.Name = "BtnPlayer12";
            this.BtnPlayer12.Size = new System.Drawing.Size(83, 164);
            this.BtnPlayer12.TabIndex = 11;
            this.BtnPlayer12.Text = "13";
            this.BtnPlayer12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnPlayer12.UseVisualStyleBackColor = false;
            // 
            // BtnPlayer11
            // 
            this.BtnPlayer11.BackColor = System.Drawing.Color.Transparent;
            this.BtnPlayer11.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPlayer11.ForeColor = System.Drawing.Color.Black;
            this.BtnPlayer11.Image = ((System.Drawing.Image)(resources.GetObject("BtnPlayer11.Image")));
            this.BtnPlayer11.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnPlayer11.Location = new System.Drawing.Point(637, 247);
            this.BtnPlayer11.Name = "BtnPlayer11";
            this.BtnPlayer11.Size = new System.Drawing.Size(83, 164);
            this.BtnPlayer11.TabIndex = 10;
            this.BtnPlayer11.Text = "12";
            this.BtnPlayer11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnPlayer11.UseVisualStyleBackColor = false;
            // 
            // BtnPlayer10
            // 
            this.BtnPlayer10.BackColor = System.Drawing.Color.Transparent;
            this.BtnPlayer10.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPlayer10.ForeColor = System.Drawing.Color.Black;
            this.BtnPlayer10.Image = ((System.Drawing.Image)(resources.GetObject("BtnPlayer10.Image")));
            this.BtnPlayer10.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnPlayer10.Location = new System.Drawing.Point(511, 247);
            this.BtnPlayer10.Name = "BtnPlayer10";
            this.BtnPlayer10.Size = new System.Drawing.Size(83, 164);
            this.BtnPlayer10.TabIndex = 9;
            this.BtnPlayer10.Text = "11";
            this.BtnPlayer10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnPlayer10.UseVisualStyleBackColor = false;
            // 
            // BtnPlayer9
            // 
            this.BtnPlayer9.BackColor = System.Drawing.Color.Transparent;
            this.BtnPlayer9.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPlayer9.ForeColor = System.Drawing.Color.Black;
            this.BtnPlayer9.Image = ((System.Drawing.Image)(resources.GetObject("BtnPlayer9.Image")));
            this.BtnPlayer9.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnPlayer9.Location = new System.Drawing.Point(383, 247);
            this.BtnPlayer9.Name = "BtnPlayer9";
            this.BtnPlayer9.Size = new System.Drawing.Size(83, 164);
            this.BtnPlayer9.TabIndex = 8;
            this.BtnPlayer9.Text = "10";
            this.BtnPlayer9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnPlayer9.UseVisualStyleBackColor = false;
            // 
            // BtnPlayer8
            // 
            this.BtnPlayer8.BackColor = System.Drawing.Color.Transparent;
            this.BtnPlayer8.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPlayer8.ForeColor = System.Drawing.Color.Black;
            this.BtnPlayer8.Image = ((System.Drawing.Image)(resources.GetObject("BtnPlayer8.Image")));
            this.BtnPlayer8.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnPlayer8.Location = new System.Drawing.Point(252, 247);
            this.BtnPlayer8.Name = "BtnPlayer8";
            this.BtnPlayer8.Size = new System.Drawing.Size(83, 164);
            this.BtnPlayer8.TabIndex = 7;
            this.BtnPlayer8.Text = "9";
            this.BtnPlayer8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnPlayer8.UseVisualStyleBackColor = false;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1861, 880);
            this.Controls.Add(this.ChatPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ButtonBG);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameForm_FormClosed);
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.panel1.ResumeLayout(false);
            this.ChatPanel.ResumeLayout(false);
            this.ChatPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnPlayer0;
        private System.Windows.Forms.Button BtnPlayer1;
        private System.Windows.Forms.Button BtnPlayer3;
        private System.Windows.Forms.Button BtnPlayer4;
        private System.Windows.Forms.Button BtnPlayer5;
        private System.Windows.Forms.Button BtnPlayer6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnPlayer7;
        private System.Windows.Forms.Button BtnPlayer8;
        private System.Windows.Forms.Button BtnPlayer15;
        private System.Windows.Forms.Button BtnPlayer14;
        private System.Windows.Forms.Button BtnPlayer13;
        private System.Windows.Forms.Button BtnPlayer11;
        private System.Windows.Forms.Button BtnPlayer10;
        private System.Windows.Forms.Button BtnPlayer9;
        private System.Windows.Forms.Button BtnPlayer12;
        private System.Windows.Forms.Button BtnPlayer2;
        private System.Windows.Forms.Button BtnJoin;
        private System.Windows.Forms.TextBox TbChatBox;
        private System.Windows.Forms.TextBox TbChatInput;
        private System.Windows.Forms.Button BtnAction;
        private System.Windows.Forms.Button BtnVote;
        private System.Windows.Forms.Label LBPeriod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LBTime;
        private System.Windows.Forms.Label LBDay;
        private System.Windows.Forms.Panel ChatPanel;
        private System.Windows.Forms.TextBox SystemOutBox;
        private System.Windows.Forms.Button ButtonBG;
    }
}