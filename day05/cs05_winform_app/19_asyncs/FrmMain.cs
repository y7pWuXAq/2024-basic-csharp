namespace _19_asyncs
{
    public partial class FrmMain : Form
    {
        #region '생성자, 초기화 영역'
        public FrmMain()
        {
            InitializeComponent();
        }
        #endregion

        #region '버튼 클릭 이벤트 핸들러'

        /* 복사할 원본 파일 선택 이벤트 핸들러 */
        private void BtnGetSource_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // 속성에서 ReadOnly = true 설정하기
                TxtSource.Text = dlg.FileName;
            }
        }

        /* 붙여넣기 할 타겟파일 선택 이벤트 핸들러 */
        private void BtnSetTarget_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                TxtTarget.Text = dlg.FileName;
            }
        }

        /* 동기화 복사 진행 이벤트 핸들러 */
        private void BtnSyncCopy_Click(object sender, EventArgs e)
        {
            long result = CopySync(TxtSource.Text, TxtTarget.Text);
        }

        /* 비동기화 복사 진행 이벤트 핸들러 */

        // void는 리턴값이 없기 때문에 Task<void> 없음
        // async랑 await는 항상 쌍으로 사용
        async private void BtnAsyncCopy_Click(object sender, EventArgs e)
        {
            long resilt = await CopyAsync(TxtSource.Text, TxtTarget.Text);
        }

        /* 복사 취소 처리 이벤트 핸들러 */
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("UI 반응 테스트 끝!");
        }
        #endregion

        #region '사용자 추가 메서드'

        /* 동기화 복사 함수 */
        long CopySync(string srcPath, string destPath)
        {
            // 버튼 사용 비활성화 작업
            BtnSyncCopy.Enabled = BtnAsyncCopy.Enabled = false;
            long totalCopied = 0;

            // File은 Open() 하면 반드시 Close() 해야 함!!
            // 단, using을 쓰면 Close()를 C#이 알아서 해줌!
            
            /* 파일 입출력 */
            using (FileStream fromStream = new FileStream(srcPath, FileMode.Open))
            // 원래 존재하는 기존 파일을 열기 때문에 FileMode.Open 사용
            {
                using (FileStream toStream = new FileStream(destPath, FileMode.Create))
                // 존재하지 않는 파일을 만들기 때문에 FileMode.Create 사용
                {
                    // 1MByte 버퍼 생성
                    byte[] buffer = new byte[1024 * 1024]; // 1024(byte) = 1KByte, 1024 * 1024 = 1MByte
                    // FromStream에 들어온 파일을 1MB씩 잘라서 버퍼에 담은 다음
                    // toStream에 1MB씩 붙여 넣는 작업

                    int nRead = 0;
                    while ((nRead = fromStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        toStream.Write(buffer, 0, nRead);
                        totalCopied += nRead; // 전체 복사 사이즈를 계속 증가

                        // 프로그래스바에 진행상황을 표시
                        PrgCopy.Value = (int)((double)(totalCopied / fromStream.Length) * 100);
                    }
                }
            }

            BtnSyncCopy.Enabled = BtnAsyncCopy.Enabled = true;
            return totalCopied; // 복사한 파일 사이즈 리턴
        }

        /* 비동기화 복사 함수 */

        // 비동기로 처리하면 응답없음 안 뜸
        // 비동기 처리 시 async, await 키워드가 가장 중요
        // async 비동기 메서드임을 정의
        // await 비동기 메서드가 끝날 때 까지 기다린다는 정의
        // 비동기를 처리하는 메서드명 ... Async()로 끝남
        // async는 메서드의 리턴값 앞에 작성, 리턴값은 Task<리턴값>

        async Task<long> CopyAsync(string srcPath, string destPath)
        {
            // 버튼 사용 비활성화 작업
            BtnSyncCopy.Enabled = BtnAsyncCopy.Enabled = false;
            long totalCopied = 0;

            /* 파일 입출력 */
            using (FileStream fromStream = new FileStream(srcPath, FileMode.Open))
            {
                using (FileStream toStream = new FileStream(destPath, FileMode.Create))
                {
                    // 1MByte 버퍼 생성
                    byte[] buffer = new byte[1024 * 1024];

                    int nRead = 0;
                    while ((nRead = await fromStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                    {
                        await toStream.WriteAsync(buffer, 0, nRead);
                        totalCopied += nRead;

                        // 프로그래스바 표시
                        PrgCopy.Value = (int)((double)(totalCopied / fromStream.Length) * 100);
                    }
                }
            }

            BtnSyncCopy.Enabled = BtnAsyncCopy.Enabled = true;
            return totalCopied;
        }
        #endregion
    }
}
