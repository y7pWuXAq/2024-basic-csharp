namespace _06_properties
{
    class Kiturami
    {
        private int temperature; // 온도

        private int year; // 제작년도
        public int Year
        {
            get { return year; }
            set { year = value; }
        } // 일반 프로퍼티

        public string Name { get; set; } // 자동 프로퍼티 : get, set에서 특별한 로직이 없으면 생략가능

        public int Temperature
        {
            // Rosalyn VS 개발서포터
            get
            {
                // 값을 리턴하기 때문에 특별한 기능 없음
                return temperature;
            }
            set
            {
                // 잘못된 값이 들어오면 안되기 때문에 여러 제약을 걸어줌
                if (value < 10)
                    temperature = 20; // 10도 이하는 허용 안함
                else if (value > 70)
                    temperature = 50; // 70도 초과는 허용 안함                
                else
                    temperature = value;
            }
        }

        // 생성자
        public Kiturami(int year, string name, int temperature)
        {
            Year = year;
            Name = name;
            Temperature = temperature;
        }


        //public void SetTemperature(int temp)
        //{
        //    if (temp > 70)
        //    {
        //        Console.WriteLine("온도가 너무 높습니다. 50도로 조정합니다.");
        //        temperature = 50;
        //    }
        //    else if (temp < 10)
        //    {
        //        Console.WriteLine("온도가 너무 낮습니다. 20도로 조정합니다.");
        //        temperature = 20;
        //    }

        //    this.temperature = temp;
        //}

        //public int GetTemperature() 
        //{ 
        //    return this.temperature; 
        //}


        public void On()
        {
            Console.WriteLine("보일러 ON");
        }

        public void Off()
        {
            Console.WriteLine("보일러 OFF");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("보일러 가동!");
            // Kiturami boiler = new Kiturami();
            // boiler.temperature = 40; // 퍼블릭 변경으로 접근 X
            // Console.WriteLine($"보일러 온도는 {boiler.temperature}도 입니다."); // 퍼블릭 변경으로 접근 X
            // boiler.SetTemperature(60);
            // Console.WriteLine($"보일러 온도는 {boiler.GetTemperature()}도 입니다.");

            // boiler.Temperature = 400; // 프로퍼티로 구현
            // Console.WriteLine($"보일러 온도는 {boiler.Temperature}도 입니다.");
            // boiler.On();

            // boiler.Name = "귀뚜라미";
            // Console.WriteLine($"보일러 이름은 {boiler.Name}");

            Kiturami kiturami = new Kiturami(name : "라미", temperature : 25, year : 2023);
            Console.WriteLine(kiturami.Name);
            Console.WriteLine($"제작년도 : {kiturami.Year}");
            kiturami.Temperature = 180;
            Console.WriteLine($"{kiturami.Name}의 현재 온도는 {kiturami.Temperature}도 입니다.");
        }
    }
}
