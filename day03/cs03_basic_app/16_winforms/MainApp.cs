namespace _16_winforms
{
    internal class MainApp : Form
    {
        static void Main(string[] args)
        {
            // Application.Run(new MainApp());

            /* 새로 객체 생성 */
            MainApp form = new MainApp(); 

            form.Click += Form_Click;
            form.KeyPress += Form_KeyPress;

            Console.WriteLine("프로그램 시작!");
            Application.Run(form);

            Console.WriteLine("프로그램 종료!");
        }

        /* 키보드 입력 이벤트 핸들러 */
        private static void Form_KeyPress(object? sender, KeyPressEventArgs e)
        {
            Console.WriteLine(e.KeyChar);
        }


        /* 폼 클릭 이벤트 핸들러 */
        private static void Form_Click(object? sender, EventArgs e)
        {
            Console.WriteLine("프로그램 종료 중...");
            Application.Exit();
        }
    }
}
