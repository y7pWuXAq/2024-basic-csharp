using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace _22_NewBookRentalShopApp
{
    public partial class FrmMain : MetroForm
    {
        /* 생성자 초기화 영역 */
        public FrmMain()
        {
            InitializeComponent();
        }

        /* 폼 로드 이벤트 핸들러(로그인 창을 먼저 띄우기) */
        private void FrmMain_Load(object sender, EventArgs e)   
        {
            FrmLogin frm = new FrmLogin();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.TopMost = true; // 창이 제일 위에 뜨도록 하는 설정
            frm.ShowDialog();
        }
    }
}
