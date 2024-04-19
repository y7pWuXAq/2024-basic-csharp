using MetroFramework.Forms;

namespace MYPEDIA
{
    public partial class FrmMain : MetroForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.TopMost = true; // 창이 제일 위에 뜨도록 하는 설정
            frm.ShowDialog();
        }
    }
}
