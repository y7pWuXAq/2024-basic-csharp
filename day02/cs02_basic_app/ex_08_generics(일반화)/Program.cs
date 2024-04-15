namespace ex_08_generics_일반화_
{
    internal class Program
    {
        // 배열 복사 기능 -> 일반화 
        //static void CopyArray(int[] src, int[] dest)
        //{
        //    for (int i = 0; i < src.Length; i++)
        //        dest[i] = src[i];   
        //}
        //static void CopyArray(float[] src, float[] dest)
        //{
        //    for (int i = 0; i < src.Length; i++)
        //        dest[i] = src[i];
        //}
        //static void Main(string[] args)
        //{
        //    int[] array1 = { 10, 20, 30, 50, 70 };
        //    int[] array2 = new int[array1.Length];

        //    CopyArray(array1 , array2);
        //    Console.WriteLine(array2[4]);

        //    float[] array3 = { 3.4f, 2.7f, 7.7f };
        //    float[] array4 = new float[array3.Length];

        //    CopyArray(array3, array4);
        //    Console.WriteLine(array4[0]);

        //}

        // 일반화 프로그래맹 
        // 메서드 뒤에 <T>, 매개변수의 타입대신 T 로 변경
        static void CopyArray<T>(T[] src, T[] dest)
        {
            for (int i = 0; i < src.Length; i++)
                dest[i] = src[i];
            
        }
    }
}
