// 파이썬용 라이브러리 사용 등록
using IronPython.Hosting;
using static System.Net.Mime.MediaTypeNames;
using System;

namespace _15_Pythons
{
    /* [
        'C:\\DEV\\Langs\\Python311'
        'C:\\DEV\\Langs\\Python311\\DLLs'
        'C:\\DEV\\Langs\\Python311\\Lib'
        'C:\\DEV\\Langs\\Python311\\Lib\\site-packages'

        'C:\\Users\\user\\AppData\\Roaming\\Python\\Python311\\site-packages'
        'C:\\Users\\user\\AppData\\Roaming\\Python\\Python311\\site-packages\\win32'
        'C:\\Users\\user\\AppData\\Roaming\\Python\\Python311\\site-packages\\win32\\lib'
        'C:\\Users\\user\\AppData\\Roaming\\Python\\Python311\\site-packages\\Pythonwin'
    ] */

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("파이썬 실행예제");

            var engine = Python.CreateEngine();
            var scope = engine.CreateScope();
            var paths = engine.GetSearchPaths();

            // 파이썬 경로 설정 @(리소스 키워드)
            paths.Add(@"C:\DEV\Langs\Python311"); // 기본 파이썬 경로
            paths.Add(@"C:\DEV\Langs\Python311\DLLs");
            paths.Add(@"C:\DEV\Langs\Python311\Lib");
            paths.Add(@"C:\DEV\Langs\Python311\Lib\site-packages");

            paths.Add(@"C:\Users\user\AppData\Roaming\Python\Python311\site-packages");
            paths.Add(@"C:\Users\user\AppData\Roaming\Python\Python311\site-packages\win32");
            paths.Add(@"C:\Users\user\AppData\Roaming\Python\Python311\site-packages\win32\lib");

        // 실행시킬 Python 파일 경로 설정
            var filePath = @"C:\Sources\2024-basic-csharp\day03\cs03_basic_app\15_Pythons\test.py";
            var source = engine.CreateScriptSourceFromFile(filePath);

            // Python 실행
            source.Execute(scope);

            var PythonFunc = scope.GetVariable<Func<int, int, int>>("sum");
            var result = PythonFunc(10, 7);
            Console.WriteLine($"Python 함수 실행 = {result}");

            var PythonGreeting = scope.GetVariable<Func<string>>("sayGreeting");
            var greeting = PythonGreeting();
            Console.WriteLine($"결과 = {greeting}");
        }
    }
}
