﻿namespace _21_BookRentalShopApp
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            MnsBookRental = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            StsBookRental = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            MnsBookRental.SuspendLayout();
            StsBookRental.SuspendLayout();
            SuspendLayout();
            // 
            // MnsBookRental
            // 
            MnsBookRental.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2, toolStripMenuItem3 });
            MnsBookRental.Location = new Point(20, 60);
            MnsBookRental.Name = "MnsBookRental";
            MnsBookRental.Size = new Size(672, 24);
            MnsBookRental.TabIndex = 1;
            MnsBookRental.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(57, 20);
            toolStripMenuItem1.Text = "파일(&F)";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(62, 20);
            toolStripMenuItem2.Text = "관리(&M)";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(72, 20);
            toolStripMenuItem3.Text = "도움말(&H)";
            // 
            // StsBookRental
            // 
            StsBookRental.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2, toolStripStatusLabel3 });
            StsBookRental.Location = new Point(20, 442);
            StsBookRental.Name = "StsBookRental";
            StsBookRental.Size = new Size(672, 22);
            StsBookRental.TabIndex = 2;
            StsBookRental.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(83, 17);
            toolStripStatusLabel1.Text = "로그인 아이디";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(44, 17);
            toolStripStatusLabel2.Text = "User Id";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(117, 17);
            toolStripStatusLabel3.Text = "Last Login DateTime";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(712, 484);
            Controls.Add(StsBookRental);
            Controls.Add(MnsBookRental);
            Font = new Font("나눔스퀘어", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            Location = new Point(0, 0);
            MainMenuStrip = MnsBookRental;
            Name = "FrmMain";
            Text = "책 대여점 v1";
            Load += FrmMain_Load;
            MnsBookRental.ResumeLayout(false);
            MnsBookRental.PerformLayout();
            StsBookRental.ResumeLayout(false);
            StsBookRental.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip MnsBookRental;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private StatusStrip StsBookRental;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel toolStripStatusLabel3;
    }
}
