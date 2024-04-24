using System.Security.Cryptography;
using System.Text;

namespace _22_NewBookRentalShopApp.Helper
{
    public class Common
    {
        // 정적으로 만드는 공통 연결문자열
        public static readonly string ConnString = "Data Source=localhost;" +
                                                   "Initial Catalog=BookRentalShop2024;" +
                                                   "Persist Security Info=True;" +
                                                   "User ID=sa;Encrypt=False;Password=mssql_p@ss";

        // 로그인아이디
        public static string LoginId { get; set; }

        // 회원 선택 팝업에서 대출화면으로 넘길 데이터를 정적프로퍼티 만들기
        public static string SelMemberIdx {  get; set; }
        public static string SelMemberName { get; set; }
        public static string SelBookIdx { get; set; }
        public static string SelBookName { get; set; }


        
        /* MD5 해시 알고리즘 암호화 */
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // 입력 문자열을 byte배열로 변한한 뒤 MD5 해시 처리
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder builder = new StringBuilder(); // 문자열을 쉽게 쓰게 만들어주는 클래스

            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2")); // x2 : 16진수 문자로 각 글자를 변환
            }

            return builder.ToString();
        }
    }
}
