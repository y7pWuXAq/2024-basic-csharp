using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _22_NewBookRentalShopApp
{
    public partial class PopBook : MetroForm
    {
        public PopBook()
        {
            InitializeComponent();
        }

        private void PopMember_Load(object sender, EventArgs e)
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

        private void DgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // xx
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (DgvResult.SelectedRows == null)
            {
                MessageBox.Show("도서를 선택하세요.", "안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selData = DgvResult.SelectedRows[0];
            Helper.Common.SelBookIdx = selData.Cells[0].Value.ToString();
            Helper.Common.SelBookName = selData.Cells[4].Value.ToString();

            this.DialogResult = DialogResult.Yes; // DialogResult 발생시킴
            this.Close();

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // 그냥 닫기
        }
    }
}
