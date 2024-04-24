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

    public partial class FrmBookRental : MetroForm
    {
        private bool isNew = false; // UPDATE(false), INSERT(true)

        public FrmBookRental()
        {
            InitializeComponent();
        }

        /* 폼 로드 이벤트 핸들러 */
        private void FrmLoginUser_Load(object sender, EventArgs e)
        {
            RefreshData();

            // 콤보박스에 들어가는 데이터를 초기화
            InitInputData(); 
            
        }


        /* 데이터 그리뷰에 데이터를 새로 부르기 */
        private void RefreshData()
        {
            using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
            {
                conn.Open();

                var query = @"SELECT r.rentalIdx
                                   , r.memberIdx
	                               , m.Names As memNames
                                   , r.bookIdx
	                               , b.Names AS bookNames
                                   , r.rentalDate
                                   , r.returnDate
                                FROM rentaltbl AS r
                                JOIN membertbl AS m
                                  ON r.memberIdx = m.memberIdx
                                JOIN bookstbl AS b
                                  ON r.bookIdx = b.bookIdx"; // 화면에 필요한 테이블 쿼리로 변경

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "rentaltbl"); // 대표 테이블 이름으로 설정

                DgvResult.DataSource = ds.Tables[0];
                DgvResult.ReadOnly = true;
                DgvResult.Columns[0].HeaderText = "대출 번호";
                DgvResult.Columns[1].HeaderText = "회원 번호";
                DgvResult.Columns[2].HeaderText = "회원명";
                DgvResult.Columns[3].HeaderText = "도서 번호";
                DgvResult.Columns[4].HeaderText = "도서 제목";
                DgvResult.Columns[5].HeaderText = "대여일";
                DgvResult.Columns[6].HeaderText = "반납일";

                // 각 컬럼의 넓이, 컬럼 숨김 지정
                
            }
        }

        #region 'InitInputData() 메서드'
        private void InitInputData()
        {
            try
            {
                // TODO 지금은 필요 없음
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류 : {ex.Message}", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region '버튼 이벤트'

        /* 버튼 이벤트 헨들러 */
        private void BtnNew_Click(object sender, EventArgs e)
        {
            isNew = true;

            TxtRentalIdx.Text = TxtMemNames.Text = string.Empty;
            TxtMemberIdx.Text = TxtBookIdx.Text = TxtBookNames.Text = string.Empty;
            TxtMemNames.Focus(); // 대출 순번은 자동증가로 입력X
            DtpRentalDate.Value = DtpReturnDate.Value = DateTime.Now;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // 도서 장르 입력
            if (string.IsNullOrEmpty(TxtMemNames.Text))
            {
                MessageBox.Show("회원명은 비워둘 수 없습니다.");
                return;
            }

            if (string.IsNullOrEmpty(TxtBookNames.Text))
            {
                MessageBox.Show("도서 제목은 비워둘 수 없습니다.");
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
                        query = @"INSERT INTO [dbo].[rentaltbl]
                                            ( [memberIdx]
                                            , [bookIdx]
                                            , [rentalDate]
                                            , [returnDate])
                                       VALUES
                                            ( @memberIdx
                                            , @bookIdx
                                            , @rentalDate
                                            , @returnDate)";
                    }
                    else // UPDATE이면
                    {
                        query = @"UPDATE [dbo].[rentaltbl]
                                           SET [memberIdx] = @memberIdx
                                              ,[bookIdx] = @bookIdx
                                              ,[rentalDate] = @rentalDate
                                              ,[returnDate] = @returnDate
                                         WHERE rentalIdx = @rentalIdx";
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlParameter prmMemberIdx = new SqlParameter("@memberIdx", TxtMemberIdx.Text);
                    cmd.Parameters.Add(prmMemberIdx);

                    SqlParameter prmBookIdx = new SqlParameter("@bookIdx", TxtBookIdx.Text);
                    cmd.Parameters.Add(prmBookIdx);

                    SqlParameter prmRentalDate = new SqlParameter("@rentalDate", DtpRentalDate.Value);
                    cmd.Parameters.Add(prmRentalDate);

                    var returnDate = ""; // 반납 날짜 추가 처리
                    if (DtpReturnDate.Value <= DtpRentalDate.Value) // 대출일 보다 반납일이 나중의 날짜가 되어야 함
                    {
                        returnDate = "";
                    }
                    else
                    {
                        returnDate = DtpReturnDate.Value.ToString("yyyy-MM-dd");
                    }
                    SqlParameter prmReturnDate = new SqlParameter("@returnDate", returnDate);
                    cmd.Parameters.Add(prmReturnDate);
                    

                    if (isNew != true)
                    {
                        SqlParameter prmRentalIdx = new SqlParameter("@rentalIdx", TxtRentalIdx.Text);
                        cmd.Parameters.Add(prmRentalIdx);
                    }

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

            // 수정 삭제 이후 모든 입력값 삭제
            TxtRentalIdx.Text = TxtMemNames.Text = string.Empty;
            TxtMemberIdx.Text = TxtBookIdx.Text = TxtBookNames.Text = string.Empty;
            DtpRentalDate.Value = DtpReturnDate.Value = DateTime.Now;

            RefreshData();
        }
        #endregion


        /* 셀 값 선택 수정 이벤트 핸들러 */
        private void DgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) // 아무것도 선택하지 않으면 -1
            {
                var selData = DgvResult.Rows[e.RowIndex]; // 내가 선택한 인덱스의 값

                TxtRentalIdx.Text = selData.Cells[0].Value.ToString(); // 대출 번호
                TxtMemberIdx.Text = selData.Cells[1].Value.ToString(); // 회원 순번
                TxtMemNames.Text = selData.Cells[2].Value.ToString(); // 회원명
                TxtBookIdx.Text = selData.Cells[3].Value.ToString(); // 도서 번호
                TxtBookNames.Text = selData.Cells[4].Value.ToString(); // 도서 제목
                DtpRentalDate.Value = DateTime.Parse(selData.Cells[5].Value.ToString()); // 대여일
                DtpReturnDate.Value = !string.IsNullOrEmpty(selData.Cells[6].Value.ToString()) ?
                                        DateTime.Parse(selData.Cells[6].Value.ToString()) : 
                                        DateTime.Parse("1800-01-01"); // 반납일이 1800년도로 뜰 경우 반납X

                isNew = false; // UPDATE
            }
        }

        /* 회원명 검색 이벤트 핸들러 */
        private void BtnSearchMember_Click(object sender, EventArgs e)
        {
            PopMember popup = new PopMember();
            popup.StartPosition = FormStartPosition.CenterParent;
            
            if (popup.ShowDialog() == DialogResult.Yes)
            {
                TxtMemberIdx.Text = Helper.Common.SelMemberIdx;
                TxtMemNames.Text = Helper.Common.SelMemberName;
            }
        }

        /* 도서 제목 검색 이벤트 핸들러 */
        private void BtnSearchBook_Click(object sender, EventArgs e)
        {
            PopBook popup = new PopBook();
            popup.StartPosition = FormStartPosition.CenterParent;

            if (popup.ShowDialog() == DialogResult.Yes)
            {
                TxtBookIdx.Text = Helper.Common.SelBookIdx;
                TxtBookNames.Text = Helper.Common.SelBookName;
            }
        }
    }
}
