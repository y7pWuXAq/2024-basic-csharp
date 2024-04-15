using System.Security.Cryptography.X509Certificates;

namespace ex09_delegators
{
    delegate int MyDelegate(int a, int b); // 대리자
    delegate int Compare(int a, int b); // 두 값을 비교하는 대리자 
    // 어떠한 일이 발생하는지 시스템이 알려주는 것 -> 이벤트
    delegate void Notify(string message); // notify 무언가를 공지하는 대리자를 만듦

    class Notifier
    {
        public Notify EventOccured; // 이벤트 발생(이벤트 메서드 실행)
    }

    class EventListener // 이벤트가 발생하는지 듣고 있는 객체 
    {
        private string name; // 생성자
        public EventListener(string name)
        {
            this.name = name;
        }
        public void SomethingHappened(string message) 
        {
            Console.WriteLine($"{name}.어떠한 일이 발생했습니다!! : {message}");
        }
    }

    class Sorting
    {
        // 오름차순 비교
        public int AscendCompare(int a, int b)
        {
            if (a > b)
                return 1;
            else if (a == b)
                return 0;
            else
                return -1;
        }

        // 내림차순 비교 
        public int DescendCompare(int a, int b)
        {
            if (a > b)
                return -1;
            else if (a == b)
                return 0;
            else
                return 1;

        }
    public void BubbleSort(int[] Dataset, Compare comparer)
    {
        int i = 0, j = 0, temp = 0;
        for (i = 0; i < Dataset.Length - 1; i++)
        {
            for (j = 0; j < Dataset.Length - (i + 1); j++)
            {
                if (comparer(Dataset[j], Dataset[j + 1]) > 0)
                {
                    temp = Dataset[j + 1];
                    Dataset[j + 1] = Dataset[j];
                    Dataset[j] = temp;
                }
            }
        }
    }
    }

    class Calculator
    {
        public int Plus(int a, int b)
        { return a + b; }

        public int Minus(int a, int b)
        { return a - b; }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Notifier notifier = new Notifier();
            EventListener listener1 = new EventListener("리스너1");
            EventListener listener2 = new EventListener("리스너2");
            EventListener listener3 = new EventListener("리스너3");
            // 대리자 체인! notifier의 EventOccured라는 대리자에 리스너 3개 일어날 수 있는 메서드 연결
            // 일반적인 메서드 호출에서는 한번에 여러개의 함수 호출(or 실행) 불가하다!! 
            notifier.EventOccured += listener1.SomethingHappened;
            notifier.EventOccured += listener2.SomethingHappened;
            notifier.EventOccured += listener3.SomethingHappened;
            notifier.EventOccured("메일을 받았습니다!");
            Console.WriteLine();

            notifier.EventOccured -= listener2.SomethingHappened; // 리스너 2번의 함수는 실행하지마 
            notifier.EventOccured("파일 다운로드 완료!");
            Console.WriteLine();

            notifier.EventOccured = new Notify(listener2.SomethingHappened) + new Notify(listener3.SomethingHappened);
            notifier.EventOccured("미사일 발사!"); 
            Console.WriteLine(); // 윈폼(PyQt 등) 이벤트도 이와 유사한 형태로 동작함❗


            #region "버블 대리자 코드 영역"

            int[] array = { 2, 3, 5, 1, 4 };
            Sorting sorting = new Sorting();

            Console.WriteLine("오름차순 정렬");
            sorting.BubbleSort(array, new Compare(sorting.AscendCompare));

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}");
            }
            Console.WriteLine();

            Console.WriteLine("내림차순 정렬");
            sorting.BubbleSort(array, new Compare(sorting.DescendCompare));

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}");
            }
            Console.WriteLine();

            #endregion

            #region "계산기 대리자 코드 영역"

            Calculator calc = new Calculator(); // 객체생성
            MyDelegate Callback;
            
            Callback = new MyDelegate(calc.Plus); // int a, int b 가 아닌 Calculator 객체의 Plus() 매서드 전달 
            var result = Callback(10, 4); // callback 은 calc.plus를 실행
            Console.WriteLine(result); // 결과값 14

            Callback = new MyDelegate(calc.Minus); // int a, int b 가 아닌 Calculator 객체의 Plus() 매서드 전달 
            result = Callback(10, 4);
            Console.WriteLine(result); // 결과값 6 

            #endregion
        }
    }
}
