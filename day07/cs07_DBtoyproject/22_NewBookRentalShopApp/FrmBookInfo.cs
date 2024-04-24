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

    public partial class FrmBookInfo : MetroForm
    {
        private bool isNew = false; // UPDATE(false), INSERT(true)

        public FrmBookInfo()
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

        #region 'ReFreshData() 메서드'

        /* 데이터 그리뷰에 데이터를 새로 부르기 */
        private void RefreshData()
        {
            using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
            {
                conn.Open();

                var query = @"SELECT b.bookIdx
                                   , b.Author
                                   , b.Division
                                   , d.Names AS DivNames -- 책장르의 구분명
                                   , b.[Names] -- 책제목
                                   , b.ReleaseDate
                                   , b.ISBN
                                   , b.Price
                                FROM bookstbl AS b
                                JOIN divtbl AS d
                                  ON b.Division = d.Division"; // 화면에 필요한 테이블 쿼리로 변경

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "divtbl"); // divtbl 가상의 테이블에 데이터 저장

                DgvResult.DataSource = ds.Tables[0];
                DgvResult.ReadOnly = true;
                DgvResult.Columns[0].HeaderText = "도서 번호";
                DgvResult.Columns[1].HeaderText = "저자명";
                DgvResult.Columns[2].HeaderText = "분류 코드";
                DgvResult.Columns[3].HeaderText = "도서 장르"; // JOIN 으로 새로 추가
                DgvResult.Columns[4].HeaderText = "도서 제목";
                DgvResult.Columns[5].HeaderText = "출판일";
                DgvResult.Columns[6].HeaderText = "ISBN";
                DgvResult.Columns[7].HeaderText = "가격";

                // 각 컬럼의 넓이 지정
                DgvResult.Columns[0].Width = 38;
                DgvResult.Columns[1].Width = 145;
                DgvResult.Columns[2].Visible = false; // 표시되지 않도록 설정
                DgvResult.Columns[4].Width = 195;
                DgvResult.Columns[5].Width = 75;
                DgvResult.Columns[7].Width = 70;
            }
        }
        #endregion

        #region 'InitInputData() 메서드'
        private void InitInputData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    conn.Open();

                    var query = @"SELECT Division, Names From divtbl";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    // SqlDataReader은 개발자가 하나씩 처리할 때
                    // SqlDataAdapter, DataSet는 데이터그리드뷰 등에 뿌릴 때
                    SqlDataReader reader = cmd.ExecuteReader();
                    var temp = new Dictionary<string, string>();

                    while (reader.Read())
                    {
                        // reader[0] = Division 컬럼, reader[1] = Names 컬럼
                        temp.Add(reader[0].ToString(), reader[1].ToString());
                    }

                    // Debug.WriteLine(temp.Count);
                    CboDivision.DataSource = new BindingSource(temp, null);
                    CboDivision.DisplayMember = "Value"; // 장르 표시
                    CboDivision.ValueMember = "Key"; // 도서 구분 코드 표시
                    CboDivision.SelectedIndex = -1;
                }
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

            TxtBookIdx.Text = TxtAuthor.Text = string.Empty;
            CboDivision.SelectedIndex = -1;
            TxtNames.Text = TxtIsbn.Text = string.Empty;
            DtpReleaseDate.Value = DateTime.Now;
            NudPrice.Value = 0;

            TxtAuthor.Focus();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // 도서 장르 입력
            if (string.IsNullOrEmpty(TxtAuthor.Text))
            {
                MessageBox.Show("도서 장르는 비워둘 수 없습니다.");
                return;
            }

            // 콤보박스는 SelectedIndex가 -1이 되면 안됨
            if (CboDivision.SelectedIndex < 0)
            {
                MessageBox.Show("도서 장르를 선택하세요");
                return;
            }

            if (string.IsNullOrEmpty(TxtNames.Text))
            {
                MessageBox.Show("도서 제목은 비워둘 수 없습니다.");
                return;
            }

            // 출판일은 기본으로 오늘날짜가 들어감
            // ISBN은 null이 들어가도 상관없음
            // 책가격은 기본이 0원 

            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    conn.Open();

                    var query = "";
                    if (isNew) // INSERT이면
                    {
                        query = @"INSERT INTO [dbo].[bookstbl]
                                            ( [Author]
                                            , [Division]
                                            , [Names]
                                            , [ReleaseDate]
                                            , [ISBN]
                                            , [Price])
                                       VALUES
                                            ( @Author
                                            , @Division
                                            , @Names
                                            , @ReleaseDate
                                            , @ISBN
                                            , @Price)";
                    }
                    else // UPDATE이면
                    {
                        query = @"UPDATE [bookstbl]
                                     SET [Author] = @Author
                                       , [Division] = @Division
                                       , [Names] = @Names
                                       , [ReleaseDate] = @ReleaseDate
                                       , [ISBN] = @ISBN
                                       , [Price] = @Price
                                   WHERE bookIdx = @bookIdx";
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlParameter prmAuthor = new SqlParameter("@Author", TxtAuthor.Text);
                    cmd.Parameters.Add(prmAuthor);
                    
                    SqlParameter prmDivision = new SqlParameter("@Division", CboDivision.SelectedValue);
                    cmd.Parameters.Add(prmDivision);
                    
                    SqlParameter prmNames = new SqlParameter("@Names", TxtNames.Text);
                    cmd.Parameters.Add(prmNames);
                    
                    SqlParameter prmReleaseDate = new SqlParameter("@ReleaseDate", DtpReleaseDate.Value);
                    cmd.Parameters.Add(prmReleaseDate);
                    
                    SqlParameter prmIsbn = new SqlParameter("@ISBN", TxtIsbn.Text);
                    cmd.Parameters.Add(prmIsbn);
                    
                    SqlParameter prmPrice = new SqlParameter("@Price", NudPrice.Text);
                    cmd.Parameters.Add(prmPrice);

                    if (isNew != true)
                    {
                        SqlParameter prmBookIdx = new SqlParameter("@bookIdx", TxtBookIdx.Text);
                        cmd.Parameters.Add(prmBookIdx);
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
            TxtBookIdx.Text = TxtAuthor.Text = string.Empty; 
            CboDivision.SelectedIndex = -1;
            TxtNames.Text = TxtIsbn.Text = string.Empty;
            DtpReleaseDate.Value = DateTime.Now;
            NudPrice.Value = 0;

            RefreshData();
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtBookIdx.Text)) // 책 번호가 없으면 삭제X
            {
                MessageBox.Show("삭제할 책을 선택하세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var answer = MessageBox.Show("삭제하시겠습니까?", "경고", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.No) return;

            using(SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
            {
                conn.Open();
                var query = @"DELETE FROM bookstbl WHERE bookIdx = @bookIdx";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter prmBookIdx = new SqlParameter(@"bookIdx", TxtBookIdx.Text);
                cmd.Parameters.Add(prmBookIdx);

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
            TxtBookIdx.Text = TxtAuthor.Text = string.Empty;
            CboDivision.SelectedIndex = -1;
            TxtNames.Text = TxtIsbn.Text = string.Empty;
            DtpReleaseDate.Value = DateTime.Now;
            NudPrice.Value = 0;

            RefreshData();
        }
        #endregion


        /* 셀 값 선택 수정 이벤트 핸들러 */
        private void DgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) // 아무것도 선택하지 않으면 -1
            {
                var selData = DgvResult.Rows[e.RowIndex]; // 내가 선택한 인덱스의 값
                TxtBookIdx.Text = selData.Cells[0].Value.ToString(); // 책번호
                TxtAuthor.Text = selData.Cells[1].Value.ToString(); // 저자명
                TxtNames.Text = selData.Cells[4].Value.ToString(); // 책제목

                // 2019-04-23 문자열을 DateTime.Parse()로 DateTime형으로 형변환
                DtpReleaseDate.Value = DateTime.Parse(selData.Cells[5].Value.ToString());
                TxtIsbn.Text = selData.Cells[6].Value.ToString();
                // 20000 가격을 숫자형으로 형변환 해주는
                NudPrice.Value = Decimal.Parse(selData.Cells[7].Value.ToString());
                // 거의 모든 타입에 *.Parse(string 타입) 형변환 하는 메서드 존재

                // 콤보박스는 맨 마지막으로
                // MessageBox.Show(selData.Cells[3].Value.Tostring());
                CboDivision.SelectedValue = selData.Cells[2].Value; // 구분코드로 선택 해야함

                isNew = false; // UPDATE
            }
        }

        /* ISBN 숫자만 입력되도록 설정 */
        private void TxtIsbn_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자 이외에는 전부 막아버림
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
