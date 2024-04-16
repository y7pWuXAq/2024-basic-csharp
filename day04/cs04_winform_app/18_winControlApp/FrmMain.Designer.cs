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
            groupBox1 = new GroupBox();
            TxtSampleText = new TextBox();
            ChkBold = new CheckBox();
            ChkItalic = new CheckBox();
            CboFonts = new ComboBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(TxtSampleText);
            groupBox1.Controls.Add(ChkBold);
            groupBox1.Controls.Add(ChkItalic);
            groupBox1.Controls.Add(CboFonts);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("나눔바른고딕", 9F);
            groupBox1.Location = new Point(10, 10);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(372, 110);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "콤보박스, 체크박스, 텍스트박스";
            // 
            // TxtSampleText
            // 
            TxtSampleText.Font = new Font("나눔바른고딕", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 129);
            TxtSampleText.Location = new Point(28, 67);
            TxtSampleText.Margin = new Padding(3, 2, 3, 2);
            TxtSampleText.Name = "TxtSampleText";
            TxtSampleText.Size = new Size(319, 21);
            TxtSampleText.TabIndex = 3;
            TxtSampleText.Text = " Hello, C#!";
            // 
            // ChkBold
            // 
            ChkBold.AutoSize = true;
            ChkBold.Font = new Font("나눔바른고딕", 9F);
            ChkBold.Location = new Point(239, 38);
            ChkBold.Margin = new Padding(3, 2, 3, 2);
            ChkBold.Name = "ChkBold";
            ChkBold.Size = new Size(48, 18);
            ChkBold.TabIndex = 2;
            ChkBold.Text = "굵게";
            ChkBold.UseVisualStyleBackColor = true;
            // 
            // ChkItalic
            // 
            ChkItalic.AutoSize = true;
            ChkItalic.Font = new Font("나눔바른고딕", 9F);
            ChkItalic.Location = new Point(293, 38);
            ChkItalic.Margin = new Padding(3, 2, 3, 2);
            ChkItalic.Name = "ChkItalic";
            ChkItalic.Size = new Size(59, 18);
            ChkItalic.TabIndex = 2;
            ChkItalic.Text = "기울게";
            ChkItalic.UseVisualStyleBackColor = true;
            // 
            // CboFonts
            // 
            CboFonts.Font = new Font("나눔바른고딕", 9F);
            CboFonts.FormattingEnabled = true;
            CboFonts.Location = new Point(61, 35);
            CboFonts.Margin = new Padding(3, 2, 3, 2);
            CboFonts.Name = "CboFonts";
            CboFonts.Size = new Size(164, 22);
            CboFonts.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("나눔바른고딕", 9F);
            label1.Location = new Point(28, 38);
            label1.Name = "label1";
            label1.Size = new Size(39, 14);
            label1.TabIndex = 0;
            label1.Text = "폰트 : ";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(6F, 12F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(392, 573);
            Controls.Add(groupBox1);
            Font = new Font("나눔고딕코딩", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmMain";
            Text = "컨트롤 예제";
            Load += FrmMain_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox CboFonts;
        private Label label1;
        private CheckBox ChkBold;
        private CheckBox ChkItalic;
        private TextBox TxtSampleText;
    }
}
