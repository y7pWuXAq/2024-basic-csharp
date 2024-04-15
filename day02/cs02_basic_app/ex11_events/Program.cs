namespace ex11_events
{
    delegate int Calculate(int a, int b);
    delegate void EventHandler(string massage); // 이벤트 핸들러 대리자(어떠한 메서드를 대신 호출)
    class CustomNotifier
    {
        // 이벤트 등록, event라는 키워드 쓰면 기본적으로 EventHandler 이름을 일반적으로 사용 
        public EventHandler SomethingHappened;
            
        public void DoSomething(int number)
        {
            int temp = number % 10;

            if (temp != 0 && temp % 3 == 0)
            {
                SomethingHappened($"{number} : 짝 !"); // 이벤트핸들러발생, 자신의 메서드가 아닌 외부에서 만들어진 메서드를 대신 실행 
            }
        }
    } // 우리가 구현하는 게 아니라, 원래부터 만들어져 있는 것 

    internal class Program
    {
        public static void MyHandler(string message)
        { 
            Console.WriteLine($"[{DateTime.Now.ToShortTimeString()}]: {message}");
        }
  
        static void Main(string[] args)
        {
            CustomNotifier notifier = new CustomNotifier();
            notifier.SomethingHappened += new EventHandler(MyHandler);

            for(int i = 1; i < 30; i++) 
            {
                notifier.DoSomething(i); // 내장된 클래스의 어떠한 메서드 호출  
            }

            //notifier.SomethingHappened(30); 이벤트핸들러는 함수가 아니기 때문에 호출불가
            #region "익명메서드"
            Calculate calc; // 대리자
            // 메서드 이름이 존재하지 않음! ==> 익명 메서드 
            // 한번 사용이후 다시 호출 할 필요가 없을 경우 사용 
            calc = delegate(int a, int b)
            { return a + b; };
            var result = calc(10, 4);

            #endregion
        }
    }
}
