using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace _22_NewBookRentalShopApp
{
    /* 생성자 초기화 영역 */

    public partial class FrmLoginUser : MetroForm
    {
        private bool isNew = false; // UPDATE(false), INSERT(true)


        public FrmLoginUser()
        {
            InitializeComponent();
        }

        /* 폼 로드 이벤트 핸들러 */
        private void FrmLoginUser_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        #region '버튼 이벤트'

        /* 버튼 이벤트 헨들러 */
        private void BtnNew_Click(object sender, EventArgs e)
        {
            isNew = true;
            TxtUserIdx.Text = TxtUserIdx.Text = TxtPassword.Text = string.Empty;
            TxtUserIdx.ReadOnly = true;
            TxtUserId.Focus(); // 유저 번호는 자동 증가로 입력X, 아이디로 자동 포커스
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var md5Hash = MD5.Create(); // MD5 암호화용 객체 생성
            var valid = true;
            var errMsg = "";

            // 입력검증(Validation Check), 아이디, 패스워드를 안 넣으면
            if (string.IsNullOrEmpty(TxtUserId.Text))
            {
                errMsg += "사용자 아이디는 비워둘 수 없습니다.\n";
                valid = false;
            }

            if (string.IsNullOrEmpty(TxtPassword.Text))
            {
                errMsg += "사용자 비밀번호는 비워둘 수 없습니다.\n";
                valid = false;
            }

            if (valid == false)
            {
                MessageBox.Show(errMsg, "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    conn.Open();

                    var query = "";
                    if (isNew) // INSERT이면
                    {
                        query = @"INSERT INTO usertbl
                                   ( userId
                                   , [password])
                              VALUES
                                   ( @userId
                                   , @password)";
                    }
                    else // UPDATE이면
                    {
                        query = @"UPDATE usertbl
                                 SET userId = @userId
                                   , [password] = @password
                               WHERE userIdx = @userIdx";
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);

                    if (isNew == false) // UPDATE시 @userIdx 파라미터 필요함
                    {
                        SqlParameter prmUserIdx = new SqlParameter("@userIdx", TxtUserIdx.Text);
                        cmd.Parameters.Add(prmUserIdx);
                    }

                    SqlParameter prmUserId = new SqlParameter("@userId", TxtUserId.Text);
                    SqlParameter prmUserPassword = new SqlParameter("@password", Helper.Common.GetMd5Hash(md5Hash, TxtPassword.Text)); // 암호화

                    // Command에 Parameter를 연결 해줘야 함
                    cmd.Parameters.Add(prmUserId);
                    cmd.Parameters.Add(prmUserPassword);

                    var result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        // this : 메세지 박스의 부모창이 누구인지, 이 코드에서는 FrmLoginUser
                        // MetroMessageBox.Show(this, "저장성공 ^^7", "안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("저장성공 ^^7", "안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("저장 실패 T.T", "안내", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류! : {ex.Message}", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            TxtUserIdx.Text = TxtUserId.Text = TxtPassword.Text = string.Empty; // 수정 삭제 이후 모든 입력값 삭제
            RefreshData();
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtUserIdx.Text))
            {
                MessageBox.Show("삭제할 사용자를 선택하세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var answer = MessageBox.Show("삭제하시겠습니까?", "경고", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.No) return;

            using(SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
            {
                conn.Open();
                var query = @"DELETE FROM usertbl WHERE userIdx = @userIdx";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter prmUserIdx = new SqlParameter(@"userIdx", TxtUserIdx.Text);
                cmd.Parameters.Add(prmUserIdx);

                var result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("삭제성공 ^^7", "안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("삭제실패 T.T", "안내", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            TxtUserIdx.Text = TxtUserId.Text = TxtPassword.Text = string.Empty; // 수정 삭제 이후 모든 입력값 삭제
            RefreshData();
        }
        #endregion

        #region 'ReFreshData() 메서드'

        /* 데이터 그리뷰에 데이터를 새로 부르기 */
        private void RefreshData()
        {
            using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
            {
                conn.Open();

                var query = @"SELECT userIdx
                                   , userId
                                   , [password]
                                   , lastLoginDateTime
                                FROM usertbl";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "usertbl"); // usertbl 가상의 테이블에 데이터 저장

                DgvResult.DataSource = ds.Tables[0];
                DgvResult.ReadOnly = true;
                DgvResult.Columns[0].HeaderText = "사용자 번호";
                DgvResult.Columns[1].HeaderText = "사용자 아이디";
                DgvResult.Columns[2].HeaderText = "사용자 비밀번호";
                DgvResult.Columns[3].HeaderText = "마지막 로그인";
            }
        }
        #endregion


        /* 셀 값 선택 수정 이벤트 핸들러 */
        private void DgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) // 아무것도 선택하지 않으면 -1
            {
                var selData = DgvResult.Rows[e.RowIndex]; // 내가 선택한 인덱스의 값
                TxtUserIdx.Text = selData.Cells[0].Value.ToString();
                TxtUserIdx.ReadOnly = true;
                TxtUserId.Text = selData.Cells[1].Value.ToString();
                TxtPassword.Text = selData.Cells[2].Value.ToString();

                isNew = false; // UPDATE
            }
        }

    }
}
