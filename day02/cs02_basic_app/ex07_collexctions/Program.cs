using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace ex07_collexctions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. 초기화
            int[] array = new int[5];
            // Console.WriteLine(int.MaxValue); c#에서 각 타입의 최대값, 최소값
            array[0] = 80;
            array[1] = 81;
            array[2] = 100;
            array[3] = 34;
            array[4] = 98;
            //array[5] = 99; array[5]는 없다 => int 5 니까

            /*
            빌드 오류 내려고 쓴거!!
            var text = Console.ReadLine(); // 콘솔에서 값입력 (파이썬에서 input 개념)
            Console.ReadLine();
            */

            // 2. 초기화 선언하면서 값을 바로 지정 
            int[] score = new int[5] { 80, 74, 81, 90, 34 };

            // 3. 초기화 배열의 크기를 생략 
            string[] names = new string[] { "Hello", "world", "C#" };

            // 4. 초기화 그냥 다 생략
            float[] points = { 3.14f, 5.5f, 4.4f, 10.8f };


            // 타입확인
            Console.WriteLine($"배열 타입 : {score.GetType()}");
            Console.WriteLine($"배열 기본 타입 : {score.GetType().BaseType}");

            foreach (var item in names)
            {
                Console.WriteLine($"문자열은 {item}");
            }

            Console.WriteLine(score.Length);

            Array.Sort(score);

            foreach (var item in names)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine("");

            Console.WriteLine(Array.BinarySearch(score, 90)); // 4출력, 인덱스 4에 90이 존재
            Console.WriteLine(Array.IndexOf(score, 90)); // 4출력, 인덱스 4에 90이 존재


            // 배열 분할은 C# 8.0부터 적용 되었으며, 파이썬의 배열 슬라이스를 도입함
            char[] array2 = new char[26]; //['z' - 'a' + 1];
            for (int i = 0; i < array2.Length; i++)
                array2[i] = (char)('A' + i);

            foreach (var item in array2)
            {
                Console.Write(item);
            }
            Console.WriteLine();


            // 배열 분할 전 
            Console.WriteLine(array2);
            // 배열 분할 후
            // 배열 분할 - 시작인덱스.. 종료인덱스 +1
            Console.WriteLine(array2[..]);
            Console.WriteLine($"<<배열 5번부터 끝까지");
            Console.WriteLine(array2[5..]);
            Console.WriteLine($"<<배열 5번부터 11번까지");
            Console.WriteLine(array2[5..11]);

            // 2차원배열, 3차원 배열, 가변배열 등은 C++과 동일 

            /*
            컬렉션
            */
            ArrayList arrayList = new ArrayList();
            arrayList.Add(10);
            arrayList.Add(array2);
            arrayList.Add(true);
            arrayList.Add("안녕하세요오~!");

            //Console.WriteLine(arrayList);

            foreach (var item in array2)
            {
                Console.Write(item);
            }
            Console.WriteLine();
            Console.WriteLine(arrayList.Count);  // ArrayList의 길이
            arrayList.RemoveAt(1);               //  ArrayList에서 인덱스 1번의 값을 삭제  
            arrayList.Insert(2, 25);             // 2번 인덱스에 25를 추가


            // Stack, Queue 파이썬 자료구조에서 배웠던 거랑 차이 없음
            Stack stack = new Stack();
            stack.Push(1);
            stack.Pop();

            Queue queue = new Queue();
            queue.Enqueue(1);
            queue.Dequeue();

            // Hashtable(== Dictionary)
            Hashtable hashtable = new Hashtable();
            hashtable["book"] = "책";
            hashtable["cook"] = "요리";
            hashtable["programer"] = "프로그래머";

            Console.WriteLine(hashtable["programer"]);


            // foreach 가능한 객체 만들기
            var obj = new CustomEnumerator();
            foreach (var item in obj)
            {
                Console.WriteLine(item);
            }
        }
        

    }
    // foreach 가능한 객체 만들기
    class CustomEnumerator
    {
        int[] numbers = { 1, 2, 3, 4, 5}; // 임의로 반복문(foreach)를 못쓴다고 가정
        public IEnumerator GetEnumerator()
        {
            // 일반 return은 return문을 만나면 메서드를 빠져나감
            // yield return은 return문을 실행한 뒤 다음 yield return 실행하기 전까지 멈춰있음.
            // Enumerator에서는 yield 제거 불가함
            yield return numbers[0];
            yield return numbers[1];
            yield return numbers[2];
            yield break;               // 모든 로직을 빠져나감
            yield return numbers[3];
        }
    }
}
