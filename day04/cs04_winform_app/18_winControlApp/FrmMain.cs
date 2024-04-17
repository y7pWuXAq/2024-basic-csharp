using System.ComponentModel;
using System.Threading; // 스레드 클래스 사용 등록 : 타임 딜레이 기능을 사용하기 위함!

namespace _18_winControlApp
{
    public partial class FrmMain : Form
    {
        #region '콤보박스, 체크박스, 텍스트박스'

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
        #endregion

        #region '트랙바, 프로그래스바'
        /* 트랙바 스크롤 이벤트 핸들러 */
        private void TrbDummy_Scroll(object sender, EventArgs e)
        {
            PrgDummy.Value = TrbDummy.Value; // 트랙바 포인터를 옮기면 프로그레스바 값도 같이 변경
        }
        #endregion

        #region '트리뷰 랜덤값 세팅'

        Random rand = new Random(); // 트리뷰 노드 이름으로 사용 할 랜덤값
        public FrmMain()
        {
            InitializeComponent(); // 디자이너에서 정의한 화면구성 초기화

            LsvDummy.Columns.Add("이름");
            LsvDummy.Columns.Add("깊이");

            // GrbEditor.Text = "Txet Editor"; // 코드 비하인드 디자인 셋팅
        }
        #endregion

        #region '트리뷰, 리스트뷰'
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

        void TreeToList()
        {
            LsvDummy.Items.Clear();
            foreach (TreeNode node in TrvDummy.Nodes)
            {
                TreeToList(node);
            }
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
        #endregion

        #region '모달, 모달리스'
        private void BtnModal_Click(object sender, EventArgs e)
        {
            Form FrmModal = new Form();
            FrmModal.Text = "Modal";
            FrmModal.Width = 300;
            FrmModal.Height = 100;
            FrmModal.BackColor = Color.Cornsilk;

            // 모달창 뜨는 위치 설정
            FrmModal.StartPosition = FormStartPosition.CenterParent; // 부모창 위치의 중앙에 팝업
            FrmModal.ShowDialog(); // 모달창 띄우기
        }

        private void BtnModaless_Click(object sender, EventArgs e)
        {
            Form FrmModaless = new Form();
            FrmModaless.Text = "Modaless";
            FrmModaless.Width = 300;
            FrmModaless.Height = 100;
            FrmModaless.BackColor = Color.Pink;

            // 모달창 뜨는 위치 설정
            FrmModaless.StartPosition = FormStartPosition.Manual;

            // 부모창 위치의 중앙에 팝업하기 위한 위치 설정 작업
            FrmModaless.Location = new Point(this.Location.X + (this.Width - FrmModaless.Width) / 2,
                                             this.Location.Y + (this.Height - FrmModaless.Height) / 2);
            FrmModaless.Show(this); // 모달리스창 띄우기
        }
        #endregion

        #region '메세지 박스'

        private void BtnMsgBox_Click(object sender, EventArgs e)
        {
            // 기본 메세지 박스 사용 법
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
        #endregion

        #region '종료 이벤트'
        /* 종료 버튼을 클릭 했을 때 발생하는 이벤트 핸들러 */
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show("닫을꼬야? ㅠ.ㅠ", "종료?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) e.Cancel = true;
        }
        #endregion

        #region '이미지 박스'

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
            }
            else
            {
                PicNormal.SizeMode = PictureBoxSizeMode.Normal;
            }
        }
        #endregion

        #region '파일 로드'

        /* 파일 로드 이벤트 핸들러 */
        private void BtnFileLoad_Click(object sender, EventArgs e)
        {
            // OpenFileDialog 컨트롤을 디자인에서 구성하지 않고 생성하는 방법
            OpenFileDialog dialog = new OpenFileDialog(); // 디자인에서 OpenFileDialog 생성 안해도 OK

            // 파일을 여러개 선택하는 작업 금지!
            // 디자인 속성에서 Multiselect 변경과 동일한 방법
            dialog.Multiselect = false;
            dialog.Filter = "Text Files(*.txt; *.cs; *.py) | *.txt; *.cs; *.py";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // UTF-8로 인코딩 된 파일을 로드하면 한글이 깨짐
                // EUC-KR(Window 949), UTF-8(BOM)은 깨지지 않음
                RtxEditor.LoadFile(dialog.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        /* 리치 텍스트 파일로 저장하는 이벤트 핸들러 */
        private void BtnFileSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            // rtf는 MS 워드에서 열리는 확장자
            dialog.Filter = "RichText Files(*.rtf) | *.rtf";

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                RtxEditor.SaveFile(dialog.FileName, RichTextBoxStreamType.RichNoOleObjs);
            }
        }
        #endregion

        #region '스레드'

        private void BtnNoThread_Click(object sender, EventArgs e) // 윈도우 창에서 바로 실행
        {
            // 프로그래스바 설정
            var maxValue = 100;
            var currValue = 0;
            PrgProcess.Value = 0; // 프로그래스 밸류를 0으로 초기화
            PrgProcess.Minimum = 0;
            PrgProcess.Maximum = maxValue;

            BtnThread.Enabled = false;
            BtnNoThread.Enabled = false;
            BtnStop.Enabled = true;

            // 반복시작
            for (var i = 0; i <= maxValue; i++)
            {
                // 내부적으로 복잡하고 시간이 많이 필요한 작업
                currValue = i;
                PrgProcess.Value = currValue;

                // 텍스트 박스에 스레드 진행상태 표시
                TxtLog.AppendText($"진행중 : {currValue}\r\n");
                Thread.Sleep(500); // 1000ms = 1초, 500ms = 0.5초
            }

            // 작업이 끝났으니 버튼 상태 변경
            BtnThread.Enabled = BtnNoThread.Enabled = true;
            BtnStop.Enabled = false;

        }

        private void BtnThread_Click(object sender, EventArgs e) // 백그라운드 워커 사용!
        {
            var maxValue = 100;
            PrgProcess.Value = 0; // 프로그래스 밸류를 0으로 초기화
            PrgProcess.Minimum = 0;
            PrgProcess.Maximum = maxValue;

            BtnThread.Enabled = BtnNoThread.Enabled = false;
            BtnStop.Enabled = true;

            BgwProgress.WorkerReportsProgress = true; // 진행사항 리포트 활성화
            BgwProgress.WorkerSupportsCancellation = true; // 백그라운드워커 취소 활성화
            BgwProgress.RunWorkerAsync(null); // 백그라운드워커 실행!

        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            BgwProgress.CancelAsync(); // 비동기로 취소실행
        }
        #endregion

        #region '백그라운드워커 이벤트 핸들러'

        /* 사용하면 복잡하지만 사용하지 않으면 프로그램 응답 대기중 뜸 */

        private void DoRealWork(BackgroundWorker worker, DoWorkEventArgs e)
        {
            var MaxValue = 100;
            double currValue = 0; // 실수형으로 변경 해야함

            for (var i = 0; i <= MaxValue; i++)
            {
                if(worker.CancellationPending) // 중간에 취소할건지 물어보는 로직
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    currValue = i;
                    // 시간이 오래 걸리는 작업 처리
                    Thread.Sleep(500);

                    // 이하 로직 실행 시 BgwProgress_ProgressChanged 이벤트 핸들러에서
                    // ProgressChangedEventArgs 내의 ProgressPercentage 속성으로 값이 들어감
                    worker.ReportProgress((int)((currValue / MaxValue) * 100));
                }
            }
        }

        /* 일을 진행 */
        private void BgwProgress_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            DoRealWork((BackgroundWorker)sender, e);
            e.Result = null;
        }

        /* 진행 상태 변경 표시 */
        private void BgwProgress_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            PrgProcess.Value = e.ProgressPercentage;

            // 텍스트 박스에 스레드 진행상태 표시
            TxtLog.AppendText($"진행중 : {PrgProcess.Value}%\r\n");
        }

        /* 진행 종료 후 처리 */
        private void BgwProgress_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                TxtLog.AppendText("멈췄따!\r\n");
            }
            else
            {
                TxtLog.AppendText("끝나따!\r\n");
            }

            // 작업이 끝났으니 버튼 상태 변경
            BtnNoThread.Enabled = BtnThread.Enabled = true;
            BtnStop.Enabled = false;
        }
        #endregion
    }
}