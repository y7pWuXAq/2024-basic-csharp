﻿namespace _22_NewBookRentalShopApp
{
    partial class FrmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.관리MToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuLoginUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuBookDivision = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuBookInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuMembers = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuBookRental = new System.Windows.Forms.ToolStripMenuItem();
            this.도움말HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.LblLoginId = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Honeydew;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일FToolStripMenuItem,
            this.관리MToolStripMenuItem,
            this.도움말HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 70);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(795, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일FToolStripMenuItem
            // 
            this.파일FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuExit});
            this.파일FToolStripMenuItem.Name = "파일FToolStripMenuItem";
            this.파일FToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.파일FToolStripMenuItem.Text = "파일(&F)";
            // 
            // MnuExit
            // 
            this.MnuExit.Name = "MnuExit";
            this.MnuExit.Size = new System.Drawing.Size(180, 22);
            this.MnuExit.Text = "끝내기(&X)";
            // 
            // 관리MToolStripMenuItem
            // 
            this.관리MToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuLoginUsers,
            this.toolStripSeparator1,
            this.MnuBookDivision,
            this.MnuBookInfo,
            this.MnuMembers,
            this.toolStripSeparator2,
            this.MnuBookRental});
            this.관리MToolStripMenuItem.Name = "관리MToolStripMenuItem";
            this.관리MToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.관리MToolStripMenuItem.Text = "관리(&M)";
            // 
            // MnuLoginUsers
            // 
            this.MnuLoginUsers.Image = global::_22_NewBookRentalShopApp.Properties.Resources.Login;
            this.MnuLoginUsers.Name = "MnuLoginUsers";
            this.MnuLoginUsers.Size = new System.Drawing.Size(180, 22);
            this.MnuLoginUsers.Text = "로그인 사용자 관리";
            this.MnuLoginUsers.Click += new System.EventHandler(this.MnuLoginUsers_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // MnuBookDivision
            // 
            this.MnuBookDivision.Image = global::_22_NewBookRentalShopApp.Properties.Resources.division;
            this.MnuBookDivision.Name = "MnuBookDivision";
            this.MnuBookDivision.Size = new System.Drawing.Size(180, 22);
            this.MnuBookDivision.Text = "도서 장르 관리";
            this.MnuBookDivision.Click += new System.EventHandler(this.MnuBookDivision_Click);
            // 
            // MnuBookInfo
            // 
            this.MnuBookInfo.Image = global::_22_NewBookRentalShopApp.Properties.Resources.book;
            this.MnuBookInfo.Name = "MnuBookInfo";
            this.MnuBookInfo.Size = new System.Drawing.Size(180, 22);
            this.MnuBookInfo.Text = "도서 정보 관리";
            this.MnuBookInfo.Click += new System.EventHandler(this.MnuBookInfo_Click);
            // 
            // MnuMembers
            // 
            this.MnuMembers.Image = global::_22_NewBookRentalShopApp.Properties.Resources.member;
            this.MnuMembers.Name = "MnuMembers";
            this.MnuMembers.Size = new System.Drawing.Size(180, 22);
            this.MnuMembers.Text = "도서 회원 관리";
            this.MnuMembers.Click += new System.EventHandler(this.MnuMembers_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // MnuBookRental
            // 
            this.MnuBookRental.Image = global::_22_NewBookRentalShopApp.Properties.Resources.rental;
            this.MnuBookRental.Name = "MnuBookRental";
            this.MnuBookRental.Size = new System.Drawing.Size(180, 22);
            this.MnuBookRental.Text = "대출 관리";
            this.MnuBookRental.Click += new System.EventHandler(this.MnuBookRental_Click);
            // 
            // 도움말HToolStripMenuItem
            // 
            this.도움말HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuAbout});
            this.도움말HToolStripMenuItem.Name = "도움말HToolStripMenuItem";
            this.도움말HToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.도움말HToolStripMenuItem.Text = "도움말(&H)";
            // 
            // MnuAbout
            // 
            this.MnuAbout.Name = "MnuAbout";
            this.MnuAbout.Size = new System.Drawing.Size(126, 22);
            this.MnuAbout.Text = "도움말(&A)";
            this.MnuAbout.Click += new System.EventHandler(this.MnuAbout_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Honeydew;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.LblLoginId});
            this.statusStrip1.Location = new System.Drawing.Point(20, 500);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(795, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(83, 17);
            this.toolStripStatusLabel1.Text = "로그인 아이디";
            // 
            // LblLoginId
            // 
            this.LblLoginId.Name = "LblLoginId";
            this.LblLoginId.Size = new System.Drawing.Size(10, 17);
            this.LblLoginId.Text = ".";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 545);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMain";
            this.Padding = new System.Windows.Forms.Padding(20, 70, 20, 23);
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.Text = "책 대여점 v2";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 관리MToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 도움말HToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem MnuExit;
        private System.Windows.Forms.ToolStripMenuItem MnuLoginUsers;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MnuBookDivision;
        private System.Windows.Forms.ToolStripMenuItem MnuBookInfo;
        private System.Windows.Forms.ToolStripMenuItem MnuMembers;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MnuBookRental;
        private System.Windows.Forms.ToolStripMenuItem MnuAbout;
        private System.Windows.Forms.ToolStripStatusLabel LblLoginId;
    }
}

