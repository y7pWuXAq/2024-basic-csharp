using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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

    public partial class FrmMember : MetroForm
    {
        private bool isNew = false; // UPDATE(false), INSERT(true)

        public FrmMember()
        {
            InitializeComponent();
        }

        /* 폼 로드 이벤트 핸들러 */
        private void FrmLoginUser_Load(object sender, EventArgs e)
        {
            RefreshData(); // bookstbl에서 데이터를 가져오는 부분

            // 콤보박스에 들어가는 데이터를 초기화
            InitInputData(); // 콤보박스, 날짜, NumericUpDoun 컨트롤 데이터 초기화
            
        }

        #region 'InitInputData() 메서드'
        private void InitInputData()
        {
            // divtbl에서 가져 온 정보를 텍스트로 대체
            var temp = new Dictionary<string, string>();
            temp.Add("A", "A");
            temp.Add("B", "B");
            temp.Add("C", "C");
            temp.Add("D", "D");

            CboLevels.DataSource = new BindingSource(temp, null);
            CboLevels.DisplayMember = "Value";
            CboLevels.ValueMember = "Key";
            CboLevels.SelectedIndex = -1;
        }
        #endregion

        #region 'ReFreshData() 메서드'

        /* 데이터 그리뷰에 데이터를 새로 부르기 */
        private void RefreshData()
        {
            using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
            {
                conn.Open();

                var query = @"SELECT [memberIdx]
                                   , [Names]
                                   , [Levels]
                                   , [Addr]
                                   , [Mobile]
                                   , [Email]
                               FROM  [membertbl]"; // 화면에 필요한 테이블 쿼리로 변경

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "membertbl"); // membertbl 가상의 테이블에 데이터 저장

                DgvResult.DataSource = ds.Tables[0];
                DgvResult.ReadOnly = true; // 수정불가
                
                // 컬럼 이름 변경
                DgvResult.Columns[0].HeaderText = "회원 번호";
                DgvResult.Columns[1].HeaderText = "회원명";
                DgvResult.Columns[2].HeaderText = "회원 등급";
                DgvResult.Columns[3].HeaderText = "회원 주소";
                DgvResult.Columns[4].HeaderText = "전화번호";
                DgvResult.Columns[5].HeaderText = "EMail";

                // 각 컬럼의 넓이 지정
                DgvResult.Columns[0].Width = 38;
                DgvResult.Columns[1].Width = 80;
                DgvResult.Columns[2].Width = 38;
                DgvResult.Columns[4].Width = 100;
                // DgvResult.Columns[5].Width = 75;
            }
        }
        #endregion

        #region '버튼 이벤트'

        /* 버튼 이벤트 헨들러 */
        private void BtnNew_Click(object sender, EventArgs e)
        {
            isNew = true;

            TxtMemberIdx.Text = TxtNames.Text = string.Empty;
            CboLevels.SelectedIndex = -1;
            TxtAddr.Text = TxtEmail.Text = string.Empty;

            TxtNames.Focus();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // 도서 장르 입력
            if (string.IsNullOrEmpty(TxtNames.Text))
            {
                MessageBox.Show("회원명은 비워둘 수 없습니다.");
                return;
            }

            // 콤보박스는 SelectedIndex가 -1이 되면 안됨
            if (CboLevels.SelectedIndex < 0)
            {
                MessageBox.Show("등급을 선택하세요");
                return;
            }

            if (string.IsNullOrEmpty(TxtAddr.Text))
            {
                MessageBox.Show("주소는 비워둘 수 없습니다.");
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
                        query = @"INSERT INTO [dbo].[membertbl]
                                            ( [Names]
                                            , [Levels]
                                            , [Addr]
                                            , [Mobile]
                                            , [Email])
                                       VALUES
                                            ( @Names
                                            , @Levels
                                            , @Addr
                                            , @Mobile
                                            , @Email)";
                    }
                    else // UPDATE이면
                    {
                        query = @"UPDATE [dbo].[membertbl]
                                           SET [Names] = @Names
                                              ,[Levels] = @Levels
                                              ,[Addr] = @Addr
                                              ,[Mobile] = @Mobile
                                              ,[Email] = @Email
                                         WHERE memberIdx = @memberIdx";
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);

                    // 복붙 후 쿼리가 바뀌면 늘 파라미터는 꼭 변경!!
                    SqlParameter prmNames = new SqlParameter("@Names", TxtNames.Text);
                    cmd.Parameters.Add(prmNames);
                    
                    SqlParameter prmLevels = new SqlParameter("@Levels", CboLevels.SelectedValue);
                    cmd.Parameters.Add(prmLevels);
                    
                    SqlParameter prmAddr = new SqlParameter("@Addr", TxtAddr.Text);
                    cmd.Parameters.Add(prmAddr);
                    
                    SqlParameter prmMobile = new SqlParameter("@Mobile", TxtMobile.Text);
                    cmd.Parameters.Add(prmMobile);

                    SqlParameter prmEmail = new SqlParameter("@Email", TxtEmail.Text);
                    cmd.Parameters.Add(prmEmail);

                    if (isNew != true)
                    {
                        SqlParameter prmMemberIdx = new SqlParameter("@memberIdx", TxtMemberIdx.Text);
                        cmd.Parameters.Add(prmMemberIdx);
                    }

                    var result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
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

            // 수정 삭제 이후 모든 입력값 삭제
            TxtMemberIdx.Text = TxtNames.Text = string.Empty; 
            CboLevels.SelectedIndex = -1;
            TxtAddr.Text = TxtEmail.Text = string.Empty;

            RefreshData();
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtMemberIdx.Text)) // 책 번호가 없으면 삭제X
            {
                MessageBox.Show("삭제할 책을 선택하세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var answer = MessageBox.Show("삭제하시겠습니까?", "경고", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.No) return;

            using(SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
            {
                conn.Open();
                var query = @"DELETE FROM membertbl WHERE memberIdx = @memberIdx";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter prmMemberIdx = new SqlParameter("@memberIdx", TxtMemberIdx.Text);
                cmd.Parameters.Add(prmMemberIdx);

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

            // 수정 삭제 이후 모든 입력값 삭제
            TxtMemberIdx.Text = TxtNames.Text = string.Empty;
            CboLevels.SelectedIndex = -1;
            TxtAddr.Text = TxtEmail.Text = string.Empty;

            RefreshData();
        }
        #endregion


        /* 셀 값 선택 이벤트 핸들러 */
        private void DgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) // 아무것도 선택하지 않으면 -1
            {
                var selData = DgvResult.Rows[e.RowIndex]; // 내가 선택한 인덱스의 값

                TxtMemberIdx.Text = selData.Cells[0].Value.ToString(); // 회원 번호
                TxtNames.Text = selData.Cells[1].Value.ToString(); // 회원명
                CboLevels.SelectedValue = selData.Cells[2].Value; // 구분코드로 선택
                TxtAddr.Text = selData.Cells[3].Value.ToString(); // 회원 주소
                TxtMobile.Text = selData.Cells[4].Value.ToString(); // 전화번호
                TxtEmail.Text = selData.Cells[5].Value.ToString(); // 이메일

                isNew = false; // UPDATE
            }
        }

    }
}
