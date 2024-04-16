namespace _18_winControlApp
{
    public partial class FrmMain : Form
    {
        Random rand = new Random(); // 트리뷰 노드 이름으로 사용 할 랜덤값
        public FrmMain()
        {
            InitializeComponent(); // 디자이너에서 정의한 화면구성 초기화

            LsvDummy.Columns.Add("이름");
            LsvDummy.Columns.Add("깊이");
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var Fonts = FontFamily.Families; // 현재 OS에 설치 된 폰트 모두 선택
            foreach (var font in Fonts)
            {
                CboFonts.Items.Add(font.Name);
            }
        }

        /* 글자체, 볼드, 기울임으로 변경하는 메서드 */
        void ChangeFont()
        {
            if (CboFonts.SelectedIndex < 0) // 아무것도 선택 안함
                return;

            FontStyle style = FontStyle.Regular; // 일반 글자(볼드x, 기울기x) 초기화

            if (ChkBold.Checked) // 굵게 선택 하면 
                style |= FontStyle.Bold;

            if (ChkItalic.Checked) // 기울게 선택 하면
                style |= FontStyle.Italic;

            TxtSampleText.Font = new Font((string)CboFonts.SelectedItem, 12, style);
        }

        void TreeToList()
        {
            LsvDummy.Items.Clear();
            foreach (TreeNode node in TrvDummy.Nodes)
            {
                TreeToList(node);
            }
        }

        private void TreeToList(TreeNode node)
        {
            // throw new NoImplementedException();
            LsvDummy.Items.Add( // 리스트뷰에 아이템 추가
                new ListViewItem(
                    new string[] { node.Text, node.FullPath.Count(f => f == '\\').ToString() }));

            foreach (TreeNode subNode in node.Nodes)
            {
                TreeToList(subNode);
            }
        }

        private void CboFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void ChkBold_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void ChkItalic_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }

        /* 트랙바 스크롤 이벤트 핸들러 */
        private void TrbDummy_Scroll(object sender, EventArgs e)
        {
            PrgDummy.Value = TrbDummy.Value; // 트랙바 포인터를 옮기면 프로그레스바 값도 같이 변경
        }

        private void BtnModal_Click(object sender, EventArgs e)
        {
            Form FrmModal = new Form();
            FrmModal.Text = "Modal";
            FrmModal.Width = 300;
            FrmModal.Height = 100;
            FrmModal.BackColor = Color.Cornsilk;
            FrmModal.ShowDialog(); // 모달창 띄우기
        }

        private void BtnModaless_Click(object sender, EventArgs e)
        {
            Form FrmModaless = new Form();
            FrmModaless.Text = "Modaless";
            FrmModaless.Width = 300;
            FrmModaless.Height = 100;
            FrmModaless.BackColor = Color.Pink;
            FrmModaless.Show(); // 모달리스창 띄우기
        }

        private void BtnMsgBox_Click(object sender, EventArgs e)
        {
            // 기본 사용 법
            MessageBox.Show(TxtSampleText.Text, "MessageBoX", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnQuestion_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("지금 쪼아?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                MessageBox.Show("쪼아!!");
            }
            else if (res == DialogResult.No)
            {
                MessageBox.Show("싫어!!");
            }
        }

        /* 종료 버튼을 클릭 했을 때 발생하는 이벤트 핸들러 */
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show("닫을꼬야? ㅠ.ㅠ", "종료?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) e.Cancel = true;
        }

        private void BtnAddRoot_Click(object sender, EventArgs e)
        {
            TrvDummy.Nodes.Add(rand.Next().ToString());
            TreeToList();
        }

        private void BtnAddChild_Click(object sender, EventArgs e)
        {
            if (TrvDummy.SelectedNode == null) // 부모 노드를 선택하지 않으면
            {
                MessageBox.Show("노드 선택이 필요합니다.", "경고!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // 진행 없이 메서드 종료
            }
            TrvDummy.SelectedNode.Nodes.Add(rand.Next().ToString());
            TrvDummy.SelectedNode.Expand();
            TreeToList(); // 리스트뷰를 다시 그려준다.
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            DlgOpenImage.Title = "이미지 열기";
            // Filter : 확장자를 이미지로만 한정하기 위해서 설정
            DlgOpenImage.Filter = "Image Files(*.bmp; *.jpg; *.png) | *.bmp; *.jpg; *.png";

            var res = DlgOpenImage.ShowDialog(this); // this 생략 가능
            /* 픽처박스에 이미지 불러오기 */
            if (res == DialogResult.OK) 
            {
                // MessageBox.Show(DlgOpenImage.FileName.ToString());
                PicNormal.Image = Bitmap.FromFile(DlgOpenImage.FileName);
            }
        }

        /* 픽처박스에 불러 온 사진을 클릭 시 크기에 맞추기 */
        private void PicNormal_Click(object sender, EventArgs e)
        {
            if (PicNormal.SizeMode == PictureBoxSizeMode.Normal)
            {
                PicNormal.SizeMode = PictureBoxSizeMode.StretchImage;
            } else
            {
                PicNormal.SizeMode = PictureBoxSizeMode.Normal;
            }
        }
    }
}