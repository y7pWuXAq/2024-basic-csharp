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

    public partial class FrmBookDivision : MetroForm
    {
        private bool isNew = false; // UPDATE(false), INSERT(true)

        public FrmBookDivision()
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
            TxtDivision.Text = string.Empty;
            TxtDivision.ReadOnly = false; // 최초 입력할 때는 PK값을 입력
            TxtDivision.Focus();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // 도서 분류 코드 입력
            if (string.IsNullOrEmpty(TxtDivision.Text))
            {
                MessageBox.Show("분류 코드는 비워둘 수 없습니다.");
                return;
            }

            // 도서 장르 입력
            if (string.IsNullOrEmpty(TxtNames.Text))
            {
                MessageBox.Show("도서 장르는 비워둘 수 없습니다.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    conn.Open();

                    var query = "";
                    if (isNew) // INSERT이면
                    {
                        query = @"INSERT INTO divtbl
                                       ( Division
                                       , Names)
                                  VALUES
                                       ( @Division
                                       , @Names)";
                    }
                    else // UPDATE이면
                    {
                        query = @"UPDATE divtbl
                                 SET Names = @Names
                               WHERE Division = @Division";
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlParameter prmDivision = new SqlParameter("@Division", TxtDivision.Text);
                    SqlParameter prmNames = new SqlParameter("@Names", TxtNames.Text);

                    // Command에 Parameter를 연결 해줘야 함
                    cmd.Parameters.Add(prmDivision);
                    cmd.Parameters.Add(prmNames);

                    var result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        // this : 메세지 박스의 부모창이 누구인지
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

            TxtDivision.Text = TxtNames.Text = string.Empty; // 수정 삭제 이후 모든 입력값 삭제
            RefreshData();
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtDivision.Text)) // 구분코드 값이 없으면
            {
                MessageBox.Show("삭제할 분류 코드를 선택하세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var answer = MessageBox.Show("삭제하시겠습니까?", "경고", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.No) return;

            using(SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
            {
                conn.Open();
                var query = @"DELETE FROM divtbl WHERE Division = @Division";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter prmDivision = new SqlParameter(@"Division", TxtDivision.Text);
                cmd.Parameters.Add(prmDivision);

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
            TxtDivision.Text = TxtNames.Text = string.Empty; // 수정 삭제 이후 모든 입력값 삭제
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

                var query = @"SELECT Division
                                   , Names
                                FROM divtbl"; // 화면에 필요한 테이블 쿼리로 변경

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "divtbl"); // divtbl 가상의 테이블에 데이터 저장

                DgvResult.DataSource = ds.Tables[0];
                DgvResult.ReadOnly = true;
                DgvResult.Columns[0].HeaderText = "분류 코드";
                DgvResult.Columns[1].HeaderText = "도서 장르";
            }
        }
        #endregion


        /* 셀 값 선택 수정 이벤트 핸들러 */
        private void DgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) // 아무것도 선택하지 않으면 -1
            {
                var selData = DgvResult.Rows[e.RowIndex]; // 내가 선택한 인덱스의 값
                TxtDivision.Text = selData.Cells[0].Value.ToString();
                TxtNames.Text = selData.Cells[1].Value.ToString();
                TxtDivision.ReadOnly = true; // UPDATE시는 PK인 Division을 변경하면 안됨

                isNew = false; // UPDATE
            }
        }

    }
}
