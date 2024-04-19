namespace MYPEDIA
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            panel1 = new Panel();
            label4 = new Label();
            BtnSignup = new Button();
            label3 = new Label();
            BtnLogin = new Button();
            ChkCheck = new CheckBox();
            TxtPassword = new TextBox();
            TxtUserId = new TextBox();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label4);
            panel1.Controls.Add(BtnSignup);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(BtnLogin);
            panel1.Controls.Add(ChkCheck);
            panel1.Controls.Add(TxtPassword);
            panel1.Controls.Add(TxtUserId);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(23, 63);
            panel1.Name = "panel1";
            panel1.Size = new Size(234, 332);
            panel1.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label4.Location = new Point(38, 290);
            label4.Name = "label4";
            label4.Size = new Size(92, 15);
            label4.TabIndex = 8;
            label4.Text = "Not a Member?";
            // 
            // BtnSignup
            // 
            BtnSignup.Location = new Point(136, 282);
            BtnSignup.Name = "BtnSignup";
            BtnSignup.Size = new Size(80, 30);
            BtnSignup.TabIndex = 7;
            BtnSignup.Text = "Sign UP";
            BtnSignup.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label3.Location = new Point(141, 150);
            label3.Name = "label3";
            label3.Size = new Size(75, 12);
            label3.TabIndex = 6;
            label3.Text = "Forget Password?";
            // 
            // BtnLogin
            // 
            BtnLogin.Location = new Point(20, 212);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(196, 30);
            BtnLogin.TabIndex = 5;
            BtnLogin.Text = "Login";
            BtnLogin.UseVisualStyleBackColor = true;
            BtnLogin.Click += BtnLogin_Click;
            // 
            // ChkCheck
            // 
            ChkCheck.AutoSize = true;
            ChkCheck.Font = new Font("맑은 고딕", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            ChkCheck.Location = new Point(20, 165);
            ChkCheck.Name = "ChkCheck";
            ChkCheck.Size = new Size(129, 17);
            ChkCheck.TabIndex = 4;
            ChkCheck.Text = "Check the password";
            ChkCheck.UseVisualStyleBackColor = true;
            ChkCheck.CheckedChanged += ChkCheck_CheckedChanged;
            // 
            // TxtPassword
            // 
            TxtPassword.Location = new Point(20, 124);
            TxtPassword.Name = "TxtPassword";
            TxtPassword.PasswordChar = '*';
            TxtPassword.Size = new Size(196, 23);
            TxtPassword.TabIndex = 3;
            TxtPassword.KeyPress += TxtPassword_KeyPress;
            // 
            // TxtUserId
            // 
            TxtUserId.Location = new Point(20, 67);
            TxtUserId.Name = "TxtUserId";
            TxtUserId.Size = new Size(196, 23);
            TxtUserId.TabIndex = 2;
            TxtUserId.KeyPress += TxtUserId_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 106);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 1;
            label2.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 49);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 0;
            label1.Text = "User ID";
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(280, 427);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmLogin";
            Resizable = false;
            Style = MetroFramework.MetroColorStyle.Silver;
            Text = "Login";
            TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            FormClosing += FrmLogin_FormClosing;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox TxtPassword;
        private TextBox TxtUserId;
        private Label label2;
        private Label label1;
        private Label label3;
        private Button BtnLogin;
        private CheckBox ChkCheck;
        private Button BtnSignup;
        private Label label4;
    }
}