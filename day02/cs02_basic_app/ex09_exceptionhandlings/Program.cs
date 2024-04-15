using Microsoft.VisualBasic;
using System.Diagnostics; // Debug 쓰면 추가되나봐 -> Debug클래스를 사용하려면 추가

namespace ex09_exceptionhandlings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[3] { 1, 2, 3 };

        try
        {
            for (int i = 0; i < 4; i++) 
            {
                Console.WriteLine($"{array[i]}");
            }
        }
        catch(Exception ex)// 모든 예외클래스의 조상이 Exception이므로,
                           // 어떤 예외코드를 써야하는지 모르겠으면 Exception 사용
            {
                Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("프로그램 종료!")
        }
    }
}
