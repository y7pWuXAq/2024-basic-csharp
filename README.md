## C# 기본 학습
2024년 IoT 개발자 과정 C# 리포지토리


### DAY 01

- C# 소개
    - MS에서 소개 한 차세대 프로그래밍 언어
    - 2000년 최초 발표
    - 개발자 : 엔더스 하일버그(파스칼, 델파이 개발자)
    - 1996년 Java 발표 이후 경쟁하기 위해 개발
    - 객체지향 언어, C/C++과 Java를 참조해서 개발
    - OS 플랫폼 독립적, 메모리 관리 쉬움, 다양한 분야에서 사용 중
    - 2024년 12버전

- .NET Framework
    - Window OS에 종속적
    - OS 독립적인 새로운 틀을 제작하기 시작(2022년~) > .NET 5.0
    - 2024년 현재 .NET 8.0 사용
    - C/C++ : gcc 컴파일러 / Java : JDK / C# : .NET 5.0 이상 필요
    - 이제는 신규 개발 시, .NET Framework는 사용하지 말것!

- Hello, C#!
    - Visual Studio 시작
    - Project : 프로그램 개발 최소단위 그룹
    - 솔루션 : 프로젝트의 묶음
    
    ```cs
        namespace _02_hello_world // 소스의 가장 큰 단위 namespace == project
    {
        internal class Program // 접근제한자 class 파일명
        {
            static void Main(string[] args) // 정적 void Main . . .
            {
                // Sytem 네임스페이스 > Console 클래스에 있는 정적메서드 WriteLine()
                Console.WriteLine("Hello, World!");
            }
        }
    }
    ```

- 변수와 상수
    - C++ 과 동일
    - 모든 C#의 객체는 Object를 조상으로 한다.
    - 박싱, 언박싱

    ```cs
        int a 20;
        object b = a; // 박싱(object 박스에 담기) > 힙에 올라눈 것

        int c = (int) b; // 언박싱(object를 각 타입으로 변환)
    ```
    - 상수는 const 키워드 사용
    - var는 컴파일러가 자동으로 타입을 지정해주는 변수. 지역변수에서만 사용가능

- 연산자
    - C++과 동일
    - if, switch, while, do~while, for, break, continue, goto 모두 동일!
    - C#에는 foreach가 존재 : python의 for item in []과 동일

    ```cs
        int[] arr = { 1, 2, 3, 4, 5 };

        foreach(var item in arr)
        {
            Console.WriteLine($"현재 수 : {item}");
        }
    ```

- 메서드(Method)
    - 함수와 동일. 구조적 프로그래밍에서 함수, 객체지향에서는 메서드로 부른다.(파이썬만 예외)
    - 매개변수 참조형식 > C++에서 Pointer로 값을 사용할 때와 동일한 기능
    
    ```cs
    public static void RefSwap(ref int a, ref int b)
    {
        int temp = b;
        b = a;
        a = temp;
    }
    // 사용시에도 ref 키워드 사용
    RefSwap(ref x, ref y);
    ```

    - 매개변수 출력형식 > 매개변수를 리턴값으로 사용하도록 대체해주는 방법(과도기적인 방법)

    ```cs
    public static void Divide(int a, int b, out int quotient, out int remainder)
    {
        quotient = a / b;
        remainder = a % b;
    }
    ```

    - 메서드 오버로딩 > 여러타입으로 같은 처리를 하는 메서드를 여러개 만들 때

    ```cs
    public static int Plus(int a, int b)
    {
        return a + b;
    }

    public static float Plus(float a, float b) 
    {
        return a + b;
    }
    ```

    - 매개변수 가변길이 > 매개변수 개수를 동적으로 처리할 때

    ```cs
    public static int Sum(params int[] argv)
    {
        int sum = 0;
        foreach (int item in argv)
        {
            sum += item;
        }
        return sum;
    }
    ```

    - 명명된 매개변수 > 매개변수 사용 순서를 변경 가능

    ```cs
    public static void PrintProfile(string name, string phone)
    {
        Console.WriteLine($"이름 : {name}, 핸드폰 : {phone}");
    }

    PrintProfile(phone: "010-1234-5678", name: "홍길동"); // 매개변수 순서를 지정 가능
    ```

    - 기본값 매개변수 > 매개변수 값을 미할당 시 기본값 지정

    ```cs
    public static void DefaultMethod(int a = 1, int b = 0)
    {
        Console.WriteLine($"DefaultMethod = {a}, {b}");
    }
    DefaultMethod(10, 8); // a = 10, b = 8
    DefaultMethod(6); // a = 6, b = 0
    DefaultMethod(); // a = 1, b = 0
    ```

- 클래스
    - C++ 클래스, 객채와 유사(문법이 다소 상이)
    - 생성자는 new, 객체 생성
    - 종료자는 C#에서 거의 사용안함
    - 생성자 오버로딩 > 파라미터 개수에 따라서 사용가능, 기본적인 메서드 오버로딩과 기능 동일
    - this키워드 > C++는 "this->", C#은 "this.", 파이썬의 "self."와 동일
    - 접근한정자(Access Modifier)
        - public : 모든 곳에서 접근 가능
        - private : 외부에서 접근 불가(default)
        - protected : 외부에서 접근 불가, 파생(상속) 클래스에서는 사용 가능
        - internal : 같은 어셈블리(네임스페이스)내에서는 public과 동일
        - protected internal, private protected : 난이도 있는 한정자(고급)

    - C#에는 C++과 같은 다중상속 없음. C++ 다중상속으로 생기는 문제점을 해결하기 위해서 다중상속을 없앰
        - 다중상속이 필요함을 해결 > 인터페이스

        ```cs
        class BaseClass {
            // 부모클래스
        }

        class DerivedClass : BaseClass {
            // 파생(자식) 클래스
        }
        ```

    - 구조체
        - 객체지향이 없었을 때 좀 더 객체지향적인 프로그래밍을 위해서 만들어진 부분(C에서)
        - class이후로 사용 빈도가 완전히 줄어든 구조
        - 구조체 스택(값형식), 클래스 힙(참조형식)
        - C#에서는 구조체 사용하지 않아도 된다.
        
    - 튜플(C# 7.0 이후 반영)
        - 한꺼번에 여러개의 데이터를 리턴하거나 전달할 때 유용
        - 값 할당 후 변경 불가

    - 인터페이스
        - 클래스 : 객체의 청사진 / 인터페이스 : 클래스의 청사진
        - 인터페이스는 클래스가 어떠한 메서드를 가져야 하는지를 약속하는 것
        - 다중상속의 문제를 단일상속으로 해결하게 만든 주체
        - 인터페이스는 명명할 때 제일 앞에 I를 적음
        - 인터페이스의 메서드에는 구현을 작성하지 않음
        - 인터페이스는 약속!
        - 클래스는 상속한다 <-> 인터페이스는 구현한다
        - 클래스는 상속시 별다른 문제가 없음 <-> 인터페이스 구현 시 약속을 지키지 않으면 오류표시
        - 인터페이스에서 약속한 메서드를 구현하지 않으면 빌드 불가!

        ![인터페이스 설명](https://raw.githubusercontent.com/y7pWuXAq/2024-basic-csharp/main/images/cs001.png)
        
    
    - 추상클래스(abstract)
        - Virutal 메서드하고도 유사
        - 추상클래스를 단순화 시키면 인터페이스

    - 프로퍼티
        - 클래스의 멤버변수 변형, 일반 변수와 유사
        - 멤버변수의 접근제한자를 public으로 했을 때의 객체지향적 문제점(코드오염 등)을 해결하기 위해서 개발
        - GET(접근자), SET(접근자)
        - SET는 값 할당시에 잘못된 데이터가 들어가지 않도록 제약을 걸어 막아야 함
        - Java에서는 Getter 메서드, Setter메서드로 사용함


### DAY 02

- TIP, C# 에서 빌드 시 오류 프로세스 액세스 오류
    - 빌드하고자는 프로그램이 백그라운드 상에 실행중이기 때문
    - Ctrl + Shift + ESC(작업관리자) 에서 해당 프로세스 작업 끝내기 후
    - 재빌드

- 컬렉션(배열, 리스트, 인덱서)
    - 모든 배열은 System.Array 클래스를 상속한 하위 클래스
    - 기본적인 배열의 사용법, Python 리스트와도 동일
    - 배열 분할 - C# 8.0부터. 파이썬의 배열 슬라이스를 도입(잘만든 기능)
    - 컬렉션, 파이썬이 리스트, 스택, 큐, 딕셔너리와 동일
        - ArrayList
        - Stack, Queue
        - Hashtable(== Dictionary)
    - foreach를 사용할 수 있는 객체로 만들기 - yield

- 일반화(Generic) 프로그래밍
    - 파이썬 - 변수에 제약사항 없음 
    - 타입의 제약을 해소하고자 만든 기능. ArrayList 등이 해결(단, 박싱(언박싱)등 성능의 문제가 있음)
    - **하나의 메서드로 여러 타입의 처리를 해줄 수 있는 프로그래밍 방식**
    - 일반화 컬렉션
        - List<T>
        - Stack<T>, Queue<T>
        - Dictionary<TKey, TValue>

- 예외처리
    - 소스코드 상 문법적 오류 - 오류(Error)
    - 실행 중 생기는 오류 - 예외(Exception)

    ```cs
    try {
        // .. 예외가 발생할 것 같은 소스코드
    } catch (Exception ex) {
        /* 모든 예외클래스의 조상은 Exception(예 IndexOutOfRangeException)
           어떤 예외클래스를 쓸지 모르면 무조건 Exception 클래스 사용하면 됨 */
        Console.WriteLine(ex.Message);
    } finally {
        // 예외발생 유무에 상관없이 항상 실행
    }
    ```

- 대리자와 이벤트
    - 메서드 호출 시 매개변수 전달
    - 대리자 호출 시 함수(메서드) 자체를 전달
    - 이벤트 - 컴퓨터 내에서 발생하는 객체의 사건들
    - 익명 메서드 사용 가능
    - delegate > event
    - 윈폼개발 > 이벤트 기반(Event driven) 프로그래밍

- TIP, C# 주석 중 영역을 지정할 수 있는 주석
    - #region ~ #endregion 영역을 Expend 또는 Collapse 가능

    ![region주석](https://raw.githubusercontent.com/y7pWuXAq/2024-basic-csharp/main/images/cs002.png)


### DAY 03

- 람다식
    - 익명 메서드를 만드는 방식 중에 하나 : delegate, lambda expresion
    - 익명 메서드 사용하면 코딩량 줄어듬, 프로퍼티 동일
    - 익명 메서드 사용 할 때마다 대리자를 선언해야 하기 때문에
        - Func, Action을 MS에서 미리 만들어둠

- LINQ(Lanuguage INtegrated Query)
    - C#에 통합 된 데이터 질의 기능 (DB SQL과 거의 동일)
    - group by에 집계함수가 필수가 아닌 것 외에는 SQL과 거의 동일
    - 단, 키워드 사용순서 다른 것은 인지하기
    - LINQ만 고집하면 XX! 기존의 C# 로직을 사용해야 할 수 있기 때문에!

- 리플렉션
    - 리플렉션 object.GetType();

- 애트리뷰트
    - [obsolete("다음 버전 사용불가!")]

- C#에서 파이썬 실행하기
    - COM 객체 사용(dynamic)
    - IronPython 라이브러리 : 파이썬을 C#에서 사용 할 수 있도록 해주는 오픈소스 라이브러리
    - NuGet Package : 파이썬 pip와 같은 라이브러리 관리 툴
    - 선택 프로젝트 > 종속성 > 우클릭 > NuGet 패키지 관리
    - 실행하는 방법
        1. 파이썬 엔진, 스코프, 설정 경로 생성
        2. 해당 컴퓨터 파이썬 경로들 설정
        3. 실행시킬 파이썬 파일 경로 지정
        4. 파이선 실행
        5. 파이썬 함수를 Func 또는 Action으로 매핑
        6. 매핑시킨 메서드를 실행

- 가비지 컬렉션
    - C, C++은 메모리 사용 시 개발자가 직접 메모리 해제 해야 함
    - C#, Java, Python 등의 객체지향 언어는 GC(쓰레기 수집기) 기능으로 프로그램이 직접 관리
    - C# 개발자는 메모리 관리에 아무것도 할게 없음!

- Winform UI 개발 + 파일, 스레드
    - 그래픽 사용자 인터페이스를 만드는 방법
        - Window Forms(Windows Forms)
        - WPF(Windows Presentation Foundation)
    - WYSIWYG(What You See Is Wath You Get) 방식의 GUI 프로그램 개발


### DAY 04

- 윈폼 UI 개발
- Winforms로 윈폼 개발 학습
    - 컨트롤 Prefix Naming Guide
        - ComboBox : Cbo -
        - CheckBox : Chk -
        - RadioButton : Rdo -
        - TextBox : Txt -
        - Button : Btn -
        - TrackBar : Trb -
        - ProgressBar : Prg -
        - PictureBox : Pic -
        - *Dialog : Dlg - 
        - RichTextBox : Rtx -


### DAY 05

- 윈폼 UI 개발 (이어서!)
    - 스레드 추가
        - 스레드 : 프로세스를 나눠서 동시에 여러가지 일을 진행하는 것
        - C#은 스레드 사용하기 불편함
        - C#에서는 BackgroundWorker 클래스를 추가해서 사용(Thread를 사용하기 편하게 만든 클래스)

    - 파일 입출력 추가
        - 리치 텍스트박스 (like MSWord, 한글워드)로 파일 저장

        <img src="https://raw.githubusercontent.com/y7pWuXAq/2024-basic-csharp/main/images/cs003.png" whidth = "850">
    
    - 비동기화 작업 앱
        - 가장 트렌드가 되는 작업
        - 백그라운드 처리는 Thread, BackgroundWorker와 유사
        - async, await 키워드

        ![비동기화앱](https://raw.githubusercontent.com/y7pWuXAq/2024-basic-csharp/main/images/cs004.png)

### DAY 06

- 예제 프로젝트
    - 윈도우 탐색기 앱
        - MyExplorer 프로젝트 생성
        - 앱 아이콘 : https://www.flaticon.com
        - 트리뷰, 리스트뷰 기능 추가
        - 컨텍스트 메뉴 추가
        
        ![중간결과](https://raw.githubusercontent.com/y7pWuXAq/2024-basic-csharp/main/images/cs005.png)


        - 미적용 기능 : 컨텍스트 메뉴 보기 기능, 더블클릭으로 프로그램 실행


### DAY 07

- 토이 프로젝트
    - 윈도우 탐색기 앱 종료
 

    https://github.com/y7pWuXAq/2024-basic-csharp/assets/158008080/f82b9f2d-4c42-4a4b-8c10-b57f5b262d69




    - 도서관리 앱 With SQL Server (DB 연동), ModernUI 앱(NuGet 패키지)

        - Nullable(C#에만 있음)
        ```cs
            // 값형식 변수는 null 사용x
            // 값형식 변수에 null값을 넣을 수 있도록 만들어준 기능 Nullable(C#에만 있음)
            
            int? a = null;
            double? b = null;
            float? c = null;

            // 변수명 뒤에? 추가하기
        ```
        - 로그인 창 만들기
        - DB 연동


### DAY 08

- 토이 프로젝트
    - 도서 관리 앱
        - 앱 사용자 관리
            - 아이디 중복 방지
            - 비밀번호 암호화(MD5)


### DAY 09

- 토이 프로젝트
- 기존 만들어진 Form을 복사해서 변경할 시 : **.cs에 클래스명, 생성자, *.Designer.cs에 있는 클래스명** 3가지 이름 변경
    - 도서 장르 관리
    - 도서 정보 관리
    - 도서 회원 관리
    - 도서 대출 관리
    - 이 프로그램은...


### 나머지

- Pending
    - IoT Dummy 앱 With SQL Sever(IoT, DB 활용)
    - 국가교통정보센터 CCTV뷰 앱 (OpenAPI, NuGet dll, Network, UI디자인, 비동기메서드)


#### 개인 토이 프로젝트
- 심플 메모장 앱
    - 기능
    - 특징
    - 배운점
