using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using MetroFramework.Forms;


namespace MYPEDIA
{
    public partial class FrmLogin : MetroForm
    {
        private bool isLogin = false;
        private string connString = "Data Source=localhost;" +
                                    "Initial Catalog=BookRentalShop2024;" +
                                    "Persist Security Info=True;" +
                                    "User ID=sa;Encrypt=False;Password=mssql_p@ss";

        private bool IsLogin // 로그인 성공여부 저장 변수
        {
            get { return isLogin; }
            set { isLogin = value; }
        }

        #region '생성자 초기화 영역'

        /* 생성자 초기화 영역 */
        public FrmLogin()
        {
            InitializeComponent();

            TxtUserId.Text = string.Empty;
            TxtPassword.Text = string.Empty;
        }
        #endregion

        /* 로그인 버튼 이벤트 핸들러 */
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            bool isFail = false;
            string errMsg = string.Empty;

            if (string.IsNullOrEmpty(TxtUserId.Text))
            {
                isFail = true;
                errMsg += "아이디를 입력하세요.\n";
            }
            if (string.IsNullOrEmpty(TxtPassword.Text))
            {
                isFail = true;
                errMsg += "비밀번호를 입력하세요.\n";
            }

            if (isFail == true)
            {
                MessageBox.Show(errMsg, "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //DB 연계
            IsLogin = LoginProcess(); // 로그인 성공하면 True, 실패하면 False 리턴
            if (IsLogin) this.Close();
        }

        /* 로그인 프로세스 함수 */

        private bool LoginProcess()
        {
            throw new NotImplementedException();
        }

        #region '텍스트박스 엔터 이벤트'

        /* 패스워드 입력 후 엔터 이벤트 핸들러 */
        private void TxtUserId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                TxtPassword.Focus();
            }
        }

        /* 아이디 입력 후 엔터 이벤트 핸들러 */
        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                BtnLogin_Click(sender, e);
            }
        }
        #endregion

        #region '비밀번호 체크박스'
        /* 비밀번호 보이기 이벤트 핸들러 */
        private void ChkCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkCheck.Checked)
            {
                TxtPassword.PasswordChar = '\0';
            }
            else
            {
                TxtPassword.PasswordChar = '*';
            }
        }
        #endregion

        /* 로그인창 닫기 이벤트 핸들러 */
        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show("정말로 종료하시겠습니까?", "종료 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) e.Cancel = true;

            // 닫기 버튼 누를 때 전체 종료하는 방법 물어보기
        }
    }
}
