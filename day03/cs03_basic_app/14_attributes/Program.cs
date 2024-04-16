using System.Reflection;

namespace _14_attributes
{

    class MyClass
    {
        [Obsolete("이 메서드는 다음 버전에서 폐기됩니다. NewMethod()를 사용하세요!")] // , true를 적으면 아에 사용불가
        public void OldMethod() // 최초로 제작한 메서드
        {
            Console.WriteLine("Old Method!");
        }


        /// <summary>
        /// 이제 이거 사용하기!
        /// </summary>
        public void NewMethod() // 개선 한 메서드
        {
            Console.WriteLine("New Method!");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            #region '리플렉션'
            Console.WriteLine("리플렉션!");

            int a = int.MaxValue;
            Type type = a.GetType();
            Console.WriteLine(type.FullName); // 결과값 : System.Int32

            float f = float.MaxValue;
            Console.WriteLine(f.GetType()); // 결과값 : System.Single

            double d = double.MaxValue;
            Console.WriteLine(d.GetType()); // 결과값 : System.Double


            // Adcanced 개발 시 필요한 내용
            /* 타입 객체에서 어떤 필드가 있는지 모두 확인 */
            FieldInfo[] fields = type.GetFields();
            foreach (var item in fields)
            {
                Console.WriteLine($"Type : {item.FieldType}, Name : {item.Name}");
            }

            MethodInfo[] methods = type.GetMethods();
            foreach (var item in methods)
            {
                Console.WriteLine($"Type : {item.DeclaringType}, Name : {item.Name}");
            }
            #endregion

            // 애트리뷰트
            Console.WriteLine("애트리뷰트!");
            MyClass myClass = new MyClass();
            myClass.OldMethod();
            myClass.NewMethod();

        }
    }
}
