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
    public partial class PopMember : MetroForm
    {
        public PopMember()
        {
            InitializeComponent();
        }

        private void PopMember_Load(object sender, EventArgs e)
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
                MessageBox.Show("회원을 선택하세요.", "안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selData = DgvResult.SelectedRows[0];
            Helper.Common.SelMemberIdx = selData.Cells[0].Value.ToString();
            Helper.Common.SelMemberName = selData.Cells[1].Value.ToString();

            this.DialogResult = DialogResult.Yes; // DialogResult 발생시킴
            this.Close();

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // 그냥 닫기
        }
    }
}
