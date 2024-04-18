namespace _20_MyExplorer
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            panel1 = new Panel();
            BtnOpen = new Button();
            TxtPath = new TextBox();
            label1 = new Label();
            SpcExplorer = new SplitContainer();
            TrvFolder = new TreeView();
            ImgSmallIcon = new ImageList(components);
            LsvFile = new ListView();
            ClhTitle = new ColumnHeader();
            ClhModifideDate = new ColumnHeader();
            ClhType = new ColumnHeader();
            ClhSize = new ColumnHeader();
            CmsFiles = new ContextMenuStrip(components);
            보기ToolStripMenuItem = new ToolStripMenuItem();
            toolStripTextBox1 = new ToolStripTextBox();
            toolStripTextBox2 = new ToolStripTextBox();
            toolStripTextBox3 = new ToolStripTextBox();
            toolStripTextBox4 = new ToolStripTextBox();
            toolStripTextBox5 = new ToolStripTextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SpcExplorer).BeginInit();
            SpcExplorer.Panel1.SuspendLayout();
            SpcExplorer.Panel2.SuspendLayout();
            SpcExplorer.SuspendLayout();
            CmsFiles.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.MistyRose;
            panel1.Controls.Add(BtnOpen);
            panel1.Controls.Add(TxtPath);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(839, 38);
            panel1.TabIndex = 0;
            // 
            // BtnOpen
            // 
            BtnOpen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnOpen.Font = new Font("나눔바른펜", 9F);
            BtnOpen.Location = new Point(777, 6);
            BtnOpen.Name = "BtnOpen";
            BtnOpen.Size = new Size(50, 25);
            BtnOpen.TabIndex = 2;
            BtnOpen.Text = "열기";
            BtnOpen.UseVisualStyleBackColor = true;
            BtnOpen.Click += BtnOpen_Click;
            // 
            // TxtPath
            // 
            TxtPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TxtPath.Location = new Point(47, 8);
            TxtPath.Name = "TxtPath";
            TxtPath.ReadOnly = true;
            TxtPath.Size = new Size(724, 21);
            TxtPath.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("나눔고딕", 9F, FontStyle.Bold);
            label1.Location = new Point(12, 11);
            label1.Name = "label1";
            label1.Size = new Size(29, 14);
            label1.TabIndex = 0;
            label1.Text = "경로";
            // 
            // SpcExplorer
            // 
            SpcExplorer.Dock = DockStyle.Fill;
            SpcExplorer.Location = new Point(0, 38);
            SpcExplorer.Name = "SpcExplorer";
            // 
            // SpcExplorer.Panel1
            // 
            SpcExplorer.Panel1.Controls.Add(TrvFolder);
            // 
            // SpcExplorer.Panel2
            // 
            SpcExplorer.Panel2.Controls.Add(LsvFile);
            SpcExplorer.Size = new Size(839, 518);
            SpcExplorer.SplitterDistance = 244;
            SpcExplorer.TabIndex = 1;
            // 
            // TrvFolder
            // 
            TrvFolder.BorderStyle = BorderStyle.None;
            TrvFolder.Dock = DockStyle.Fill;
            TrvFolder.ImageIndex = 0;
            TrvFolder.ImageList = ImgSmallIcon;
            TrvFolder.Location = new Point(0, 0);
            TrvFolder.Name = "TrvFolder";
            TrvFolder.SelectedImageIndex = 0;
            TrvFolder.Size = new Size(244, 518);
            TrvFolder.TabIndex = 0;
            TrvFolder.BeforeExpand += TrvFolder_BeforeExpand;
            TrvFolder.AfterSelect += TrvFolder_AfterSelect;
            // 
            // ImgSmallIcon
            // 
            ImgSmallIcon.ColorDepth = ColorDepth.Depth32Bit;
            ImgSmallIcon.ImageStream = (ImageListStreamer)resources.GetObject("ImgSmallIcon.ImageStream");
            ImgSmallIcon.TransparentColor = Color.Transparent;
            ImgSmallIcon.Images.SetKeyName(0, "hard-drive.png");
            ImgSmallIcon.Images.SetKeyName(1, "folder-normal.png");
            ImgSmallIcon.Images.SetKeyName(2, "folder-open.png");
            ImgSmallIcon.Images.SetKeyName(3, "file-exe.png");
            ImgSmallIcon.Images.SetKeyName(4, "file-normal.png");
            ImgSmallIcon.Images.SetKeyName(5, "txt.png");
            // 
            // LsvFile
            // 
            LsvFile.BorderStyle = BorderStyle.None;
            LsvFile.Columns.AddRange(new ColumnHeader[] { ClhTitle, ClhModifideDate, ClhType, ClhSize });
            LsvFile.Dock = DockStyle.Fill;
            LsvFile.Location = new Point(0, 0);
            LsvFile.Name = "LsvFile";
            LsvFile.Size = new Size(591, 518);
            LsvFile.SmallImageList = ImgSmallIcon;
            LsvFile.TabIndex = 0;
            LsvFile.UseCompatibleStateImageBehavior = false;
            LsvFile.View = View.Details;
            LsvFile.MouseDown += LsvFile_MouseDown;
            // 
            // ClhTitle
            // 
            ClhTitle.Text = "이름";
            ClhTitle.Width = 200;
            // 
            // ClhModifideDate
            // 
            ClhModifideDate.Text = "수정한 날짜";
            ClhModifideDate.Width = 150;
            // 
            // ClhType
            // 
            ClhType.Text = "유형";
            ClhType.Width = 100;
            // 
            // ClhSize
            // 
            ClhSize.Text = "크기";
            ClhSize.TextAlign = HorizontalAlignment.Right;
            ClhSize.Width = 80;
            // 
            // CmsFiles
            // 
            CmsFiles.Items.AddRange(new ToolStripItem[] { 보기ToolStripMenuItem });
            CmsFiles.Name = "CmsFiles";
            CmsFiles.Size = new Size(97, 26);
            // 
            // 보기ToolStripMenuItem
            // 
            보기ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripTextBox1, toolStripTextBox2, toolStripTextBox3, toolStripTextBox4, toolStripTextBox5 });
            보기ToolStripMenuItem.Font = new Font("나눔고딕", 9F);
            보기ToolStripMenuItem.Name = "보기ToolStripMenuItem";
            보기ToolStripMenuItem.Size = new Size(96, 22);
            보기ToolStripMenuItem.Text = "보기";
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.Font = new Font("나눔고딕", 9F);
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(100, 21);
            toolStripTextBox1.Text = "큰 아이콘";
            // 
            // toolStripTextBox2
            // 
            toolStripTextBox2.Font = new Font("나눔고딕", 9F);
            toolStripTextBox2.Name = "toolStripTextBox2";
            toolStripTextBox2.Size = new Size(100, 21);
            toolStripTextBox2.Text = "작은 아이콘";
            // 
            // toolStripTextBox3
            // 
            toolStripTextBox3.Font = new Font("나눔고딕", 9F);
            toolStripTextBox3.Name = "toolStripTextBox3";
            toolStripTextBox3.Size = new Size(100, 21);
            toolStripTextBox3.Text = "목록";
            // 
            // toolStripTextBox4
            // 
            toolStripTextBox4.Font = new Font("나눔고딕", 9F);
            toolStripTextBox4.Name = "toolStripTextBox4";
            toolStripTextBox4.Size = new Size(100, 21);
            toolStripTextBox4.Text = "자세히";
            // 
            // toolStripTextBox5
            // 
            toolStripTextBox5.Font = new Font("나눔고딕", 9F);
            toolStripTextBox5.Name = "toolStripTextBox5";
            toolStripTextBox5.Size = new Size(100, 21);
            toolStripTextBox5.Text = "타일";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(839, 556);
            Controls.Add(SpcExplorer);
            Controls.Add(panel1);
            Font = new Font("나눔고딕", 9F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "내 탐색기! v1.0";
            Load += FrmMain_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            SpcExplorer.Panel1.ResumeLayout(false);
            SpcExplorer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SpcExplorer).EndInit();
            SpcExplorer.ResumeLayout(false);
            CmsFiles.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button BtnOpen;
        private TextBox TxtPath;
        private Label label1;
        private SplitContainer SpcExplorer;
        private TreeView TrvFolder;
        private ListView LsvFile;
        private ColumnHeader ClhTitle;
        private ColumnHeader ClhModifideDate;
        private ColumnHeader ClhType;
        private ColumnHeader ClhSize;
        private ImageList ImgSmallIcon;
        private ContextMenuStrip CmsFiles;
        private ToolStripMenuItem 보기ToolStripMenuItem;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripTextBox toolStripTextBox2;
        private ToolStripTextBox toolStripTextBox3;
        private ToolStripTextBox toolStripTextBox4;
        private ToolStripTextBox toolStripTextBox5;
    }
}
