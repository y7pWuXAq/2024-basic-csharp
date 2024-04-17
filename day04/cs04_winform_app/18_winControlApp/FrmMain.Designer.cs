namespace _18_winControlApp
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
            groupBox1 = new GroupBox();
            TxtSampleText = new TextBox();
            ChkBold = new CheckBox();
            ChkItalic = new CheckBox();
            CboFonts = new ComboBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            PrgDummy = new ProgressBar();
            TrbDummy = new TrackBar();
            groupBox3 = new GroupBox();
            BtnQuestion = new Button();
            BtnMsgBox = new Button();
            BtnModaless = new Button();
            BtnModal = new Button();
            groupBox4 = new GroupBox();
            LsvDummy = new ListView();
            TrvDummy = new TreeView();
            BtnAddChild = new Button();
            BtnAddRoot = new Button();
            groupBox5 = new GroupBox();
            BtnLoad = new Button();
            PicNormal = new PictureBox();
            DlgOpenImage = new OpenFileDialog();
            GrbEditor = new GroupBox();
            BtnFileSave = new Button();
            BtnFileLoad = new Button();
            RtxEditor = new RichTextBox();
            groupBox6 = new GroupBox();
            BtnStop = new Button();
            BtnThread = new Button();
            BtnNoThread = new Button();
            PrgProcess = new ProgressBar();
            TxtLog = new TextBox();
            BgwProgress = new System.ComponentModel.BackgroundWorker();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TrbDummy).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PicNormal).BeginInit();
            GrbEditor.SuspendLayout();
            groupBox6.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(TxtSampleText);
            groupBox1.Controls.Add(ChkBold);
            groupBox1.Controls.Add(ChkItalic);
            groupBox1.Controls.Add(CboFonts);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("나눔고딕", 9F);
            groupBox1.Location = new Point(15, 12);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(375, 110);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "콤보박스, 체크박스, 텍스트박스";
            // 
            // TxtSampleText
            // 
            TxtSampleText.Font = new Font("나눔고딕", 9F);
            TxtSampleText.Location = new Point(27, 68);
            TxtSampleText.Margin = new Padding(3, 2, 3, 2);
            TxtSampleText.Name = "TxtSampleText";
            TxtSampleText.Size = new Size(319, 21);
            TxtSampleText.TabIndex = 3;
            TxtSampleText.Text = " Hello, C# ^^7!";
            // 
            // ChkBold
            // 
            ChkBold.AutoSize = true;
            ChkBold.Font = new Font("나눔고딕", 9F, FontStyle.Bold);
            ChkBold.Location = new Point(235, 35);
            ChkBold.Margin = new Padding(3, 2, 3, 2);
            ChkBold.Name = "ChkBold";
            ChkBold.Size = new Size(48, 18);
            ChkBold.TabIndex = 2;
            ChkBold.Text = "굵게";
            ChkBold.UseVisualStyleBackColor = true;
            ChkBold.CheckedChanged += ChkBold_CheckedChanged;
            // 
            // ChkItalic
            // 
            ChkItalic.AutoSize = true;
            ChkItalic.Font = new Font("나눔고딕", 9F, FontStyle.Italic);
            ChkItalic.Location = new Point(287, 35);
            ChkItalic.Margin = new Padding(3, 2, 3, 2);
            ChkItalic.Name = "ChkItalic";
            ChkItalic.Size = new Size(59, 18);
            ChkItalic.TabIndex = 2;
            ChkItalic.Text = "기울임";
            ChkItalic.UseVisualStyleBackColor = true;
            ChkItalic.CheckedChanged += ChkItalic_CheckedChanged;
            // 
            // CboFonts
            // 
            CboFonts.Font = new Font("나눔고딕", 9F);
            CboFonts.FormattingEnabled = true;
            CboFonts.Location = new Point(62, 33);
            CboFonts.Margin = new Padding(3, 2, 3, 2);
            CboFonts.Name = "CboFonts";
            CboFonts.Size = new Size(164, 22);
            CboFonts.TabIndex = 1;
            CboFonts.SelectedIndexChanged += CboFonts_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("나눔고딕", 9F);
            label1.Location = new Point(26, 37);
            label1.Name = "label1";
            label1.Size = new Size(39, 14);
            label1.TabIndex = 0;
            label1.Text = "폰트 : ";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(PrgDummy);
            groupBox2.Controls.Add(TrbDummy);
            groupBox2.Font = new Font("나눔고딕", 9F);
            groupBox2.Location = new Point(15, 132);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(375, 110);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "트랙바, 프로그레스바";
            // 
            // PrgDummy
            // 
            PrgDummy.Location = new Point(25, 70);
            PrgDummy.Maximum = 20;
            PrgDummy.Name = "PrgDummy";
            PrgDummy.Size = new Size(325, 23);
            PrgDummy.TabIndex = 3;
            // 
            // TrbDummy
            // 
            TrbDummy.Location = new Point(25, 26);
            TrbDummy.Maximum = 20;
            TrbDummy.Name = "TrbDummy";
            TrbDummy.Size = new Size(325, 45);
            TrbDummy.TabIndex = 2;
            TrbDummy.Scroll += TrbDummy_Scroll;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(BtnQuestion);
            groupBox3.Controls.Add(BtnMsgBox);
            groupBox3.Controls.Add(BtnModaless);
            groupBox3.Controls.Add(BtnModal);
            groupBox3.Font = new Font("나눔고딕", 9F);
            groupBox3.Location = new Point(15, 254);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(375, 80);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "모달, 모달리스";
            // 
            // BtnQuestion
            // 
            BtnQuestion.Location = new Point(300, 29);
            BtnQuestion.Name = "BtnQuestion";
            BtnQuestion.Size = new Size(55, 30);
            BtnQuestion.TabIndex = 1;
            BtnQuestion.Text = "...";
            BtnQuestion.UseVisualStyleBackColor = true;
            BtnQuestion.Click += BtnQuestion_Click;
            // 
            // BtnMsgBox
            // 
            BtnMsgBox.Font = new Font("나눔고딕", 9F);
            BtnMsgBox.Location = new Point(191, 29);
            BtnMsgBox.Name = "BtnMsgBox";
            BtnMsgBox.Size = new Size(95, 30);
            BtnMsgBox.TabIndex = 0;
            BtnMsgBox.Text = "MessageBox";
            BtnMsgBox.UseVisualStyleBackColor = true;
            BtnMsgBox.Click += BtnMsgBox_Click;
            // 
            // BtnModaless
            // 
            BtnModaless.Font = new Font("나눔고딕", 9F);
            BtnModaless.Location = new Point(104, 29);
            BtnModaless.Name = "BtnModaless";
            BtnModaless.Size = new Size(80, 30);
            BtnModaless.TabIndex = 0;
            BtnModaless.Text = "Modaless";
            BtnModaless.UseVisualStyleBackColor = true;
            BtnModaless.Click += BtnModaless_Click;
            // 
            // BtnModal
            // 
            BtnModal.Font = new Font("나눔고딕", 9F);
            BtnModal.Location = new Point(17, 29);
            BtnModal.Name = "BtnModal";
            BtnModal.Size = new Size(80, 30);
            BtnModal.TabIndex = 0;
            BtnModal.Text = "Modal";
            BtnModal.UseVisualStyleBackColor = true;
            BtnModal.Click += BtnModal_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(LsvDummy);
            groupBox4.Controls.Add(TrvDummy);
            groupBox4.Controls.Add(BtnAddChild);
            groupBox4.Controls.Add(BtnAddRoot);
            groupBox4.Font = new Font("나눔고딕", 9F);
            groupBox4.Location = new Point(15, 351);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(375, 205);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "트리뷰, 리스트뷰";
            // 
            // LsvDummy
            // 
            LsvDummy.Location = new Point(192, 22);
            LsvDummy.Name = "LsvDummy";
            LsvDummy.Size = new Size(170, 130);
            LsvDummy.TabIndex = 2;
            LsvDummy.UseCompatibleStateImageBehavior = false;
            LsvDummy.View = View.Details;
            // 
            // TrvDummy
            // 
            TrvDummy.Location = new Point(14, 22);
            TrvDummy.Name = "TrvDummy";
            TrvDummy.Size = new Size(170, 130);
            TrvDummy.TabIndex = 1;
            // 
            // BtnAddChild
            // 
            BtnAddChild.Location = new Point(104, 161);
            BtnAddChild.Name = "BtnAddChild";
            BtnAddChild.Size = new Size(80, 30);
            BtnAddChild.TabIndex = 0;
            BtnAddChild.Text = "자식추가";
            BtnAddChild.UseVisualStyleBackColor = true;
            BtnAddChild.Click += BtnAddChild_Click;
            // 
            // BtnAddRoot
            // 
            BtnAddRoot.Location = new Point(14, 161);
            BtnAddRoot.Name = "BtnAddRoot";
            BtnAddRoot.Size = new Size(80, 30);
            BtnAddRoot.TabIndex = 0;
            BtnAddRoot.Text = "루트추가";
            BtnAddRoot.UseVisualStyleBackColor = true;
            BtnAddRoot.Click += BtnAddRoot_Click;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(BtnLoad);
            groupBox5.Controls.Add(PicNormal);
            groupBox5.Font = new Font("나눔고딕", 9F);
            groupBox5.Location = new Point(404, 12);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(375, 310);
            groupBox5.TabIndex = 4;
            groupBox5.TabStop = false;
            groupBox5.Text = "픽쳐박스";
            // 
            // BtnLoad
            // 
            BtnLoad.Location = new Point(281, 268);
            BtnLoad.Name = "BtnLoad";
            BtnLoad.Size = new Size(80, 30);
            BtnLoad.TabIndex = 1;
            BtnLoad.Text = "불러오기";
            BtnLoad.UseVisualStyleBackColor = true;
            BtnLoad.Click += BtnLoad_Click;
            // 
            // PicNormal
            // 
            PicNormal.BackColor = Color.LavenderBlush;
            PicNormal.Location = new Point(13, 20);
            PicNormal.Name = "PicNormal";
            PicNormal.Size = new Size(348, 240);
            PicNormal.TabIndex = 0;
            PicNormal.TabStop = false;
            PicNormal.Click += PicNormal_Click;
            // 
            // GrbEditor
            // 
            GrbEditor.Controls.Add(BtnFileSave);
            GrbEditor.Controls.Add(BtnFileLoad);
            GrbEditor.Controls.Add(RtxEditor);
            GrbEditor.Font = new Font("나눔고딕", 9F);
            GrbEditor.Location = new Point(795, 12);
            GrbEditor.Name = "GrbEditor";
            GrbEditor.Size = new Size(375, 545);
            GrbEditor.TabIndex = 5;
            GrbEditor.TabStop = false;
            GrbEditor.Text = "텍스트 에디터";
            // 
            // BtnFileSave
            // 
            BtnFileSave.Location = new Point(100, 500);
            BtnFileSave.Name = "BtnFileSave";
            BtnFileSave.Size = new Size(80, 30);
            BtnFileSave.TabIndex = 2;
            BtnFileSave.Text = "저장하기";
            BtnFileSave.UseVisualStyleBackColor = true;
            BtnFileSave.Click += BtnFileSave_Click;
            // 
            // BtnFileLoad
            // 
            BtnFileLoad.Location = new Point(13, 500);
            BtnFileLoad.Name = "BtnFileLoad";
            BtnFileLoad.Size = new Size(80, 30);
            BtnFileLoad.TabIndex = 1;
            BtnFileLoad.Text = "불러오기";
            BtnFileLoad.UseVisualStyleBackColor = true;
            BtnFileLoad.Click += BtnFileLoad_Click;
            // 
            // RtxEditor
            // 
            RtxEditor.BorderStyle = BorderStyle.None;
            RtxEditor.Location = new Point(13, 20);
            RtxEditor.Name = "RtxEditor";
            RtxEditor.Size = new Size(350, 470);
            RtxEditor.TabIndex = 0;
            RtxEditor.Text = "";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(BtnStop);
            groupBox6.Controls.Add(BtnThread);
            groupBox6.Controls.Add(BtnNoThread);
            groupBox6.Controls.Add(PrgProcess);
            groupBox6.Controls.Add(TxtLog);
            groupBox6.Font = new Font("나눔고딕", 9F);
            groupBox6.Location = new Point(404, 331);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(375, 225);
            groupBox6.TabIndex = 6;
            groupBox6.TabStop = false;
            groupBox6.Text = "스레드, 백그라운드 워커";
            // 
            // BtnStop
            // 
            BtnStop.Enabled = false;
            BtnStop.Location = new Point(244, 181);
            BtnStop.Name = "BtnStop";
            BtnStop.Size = new Size(80, 30);
            BtnStop.TabIndex = 2;
            BtnStop.Text = "Stop";
            BtnStop.UseVisualStyleBackColor = true;
            BtnStop.Click += BtnStop_Click;
            // 
            // BtnThread
            // 
            BtnThread.Location = new Point(149, 181);
            BtnThread.Name = "BtnThread";
            BtnThread.Size = new Size(80, 30);
            BtnThread.TabIndex = 2;
            BtnThread.Text = "Thread";
            BtnThread.UseVisualStyleBackColor = true;
            BtnThread.Click += BtnThread_Click;
            // 
            // BtnNoThread
            // 
            BtnNoThread.Location = new Point(54, 181);
            BtnNoThread.Name = "BtnNoThread";
            BtnNoThread.Size = new Size(80, 30);
            BtnNoThread.TabIndex = 2;
            BtnNoThread.Text = "NoThread";
            BtnNoThread.UseVisualStyleBackColor = true;
            BtnNoThread.Click += BtnNoThread_Click;
            // 
            // PrgProcess
            // 
            PrgProcess.Location = new Point(12, 146);
            PrgProcess.Name = "PrgProcess";
            PrgProcess.Size = new Size(350, 23);
            PrgProcess.TabIndex = 1;
            // 
            // TxtLog
            // 
            TxtLog.Location = new Point(12, 20);
            TxtLog.Multiline = true;
            TxtLog.Name = "TxtLog";
            TxtLog.Size = new Size(350, 120);
            TxtLog.TabIndex = 0;
            // 
            // BgwProgress
            // 
            BgwProgress.DoWork += BgwProgress_DoWork;
            BgwProgress.ProgressChanged += BgwProgress_ProgressChanged;
            BgwProgress.RunWorkerCompleted += BgwProgress_RunWorkerCompleted;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(6F, 12F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 571);
            Controls.Add(groupBox6);
            Controls.Add(GrbEditor);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("나눔고딕코딩", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmMain";
            Text = "컨트롤 예제";
            FormClosing += FrmMain_FormClosing;
            Load += FrmMain_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TrbDummy).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PicNormal).EndInit();
            GrbEditor.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox CboFonts;
        private Label label1;
        private CheckBox ChkBold;
        private CheckBox ChkItalic;
        private TextBox TxtSampleText;
        private GroupBox groupBox2;
        private TrackBar TrbDummy;
        private ProgressBar PrgDummy;
        private GroupBox groupBox3;
        private Button BtnMsgBox;
        private Button BtnModaless;
        private Button BtnModal;
        private Button BtnQuestion;
        private GroupBox groupBox4;
        private ListView LsvDummy;
        private TreeView TrvDummy;
        private Button BtnAddChild;
        private Button BtnAddRoot;
        private GroupBox groupBox5;
        private Button BtnLoad;
        private PictureBox PicNormal;
        private OpenFileDialog DlgOpenImage;
        private GroupBox GrbEditor;
        private RichTextBox RtxEditor;
        private Button BtnFileSave;
        private Button BtnFileLoad;
        private GroupBox groupBox6;
        private Button BtnStop;
        private Button BtnThread;
        private Button BtnNoThread;
        private ProgressBar PrgProcess;
        private TextBox TxtLog;
        private System.ComponentModel.BackgroundWorker BgwProgress;
    }
}
