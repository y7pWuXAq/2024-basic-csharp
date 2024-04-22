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

        FrmLoginUser FrmLoginUser = null; // 객체를 메서드로 생성

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

        /* 상단 메뉴 이벤트 선택 이벤트 핸들러 */
        private void MnuLoginUsers_Click(object sender, EventArgs e)
        {
            // 이미 창이 열려 있으면 새로 생성 할 필요가 없기 때문에
            // 해당 작업 생략 시 메뉴 클릭 시 마다 새 폼이 열림
            FrmLoginUser = ShowActiveForm(FrmLoginUser, typeof(FrmLoginUser)) as FrmLoginUser;
        }

        /* 로그인 사용자 관리창 여는 함수 */
        Form ShowActiveForm(Form form, Type type)
        {
            if (form == null) // 화면을 한번도 안 열었으면
            {
                form = Activator.CreateInstance(type) as Form; // 타입은 클래스 타입
                form.MdiParent = this; // 자식창의 부모는 FrmMain
                form.WindowState = FormWindowState.Normal;
                form.Show();
            }
            else
            {
                if (form.IsDisposed) // 창이 한번 닫혔으면
                {
                    form = Activator.CreateInstance(type) as Form; // 타입은 클래스 타입
                    form.MdiParent = this; // 자식창의 부모는 FrmMain
                    form.WindowState = FormWindowState.Normal;
                    form.Show();
                }
                else // 만약에 창을 최소화 혹은 열려 있으면 그 창을 그냥 띄우기
                {
                    form.Activate(); // 창을 활성화
                }
            }
            return form;
        }
    }
}
