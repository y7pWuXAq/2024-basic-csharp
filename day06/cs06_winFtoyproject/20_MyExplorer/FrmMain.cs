using System.Diagnostics;

namespace _20_MyExplorer
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        /* 폼 로드 이벤트 핸들러(가장 기본! 이벤트 중 가장 먼저 실행) */
        private void FrmMain_Load(object sender, EventArgs e)
        {
            TreeNode root = TrvFolder.Nodes.Add("내 컴퓨터");

            string[] drives = Directory.GetLogicalDrives(); // 내 컴퓨터 논리 드라이브를 가져오기
            foreach (var drive in drives)
            {
                TreeNode node = root.Nodes.Add(drive);
                node.Nodes.Add("..."); // 최초의 상태로 Setup
            }

            // LsvFile.View = View.LargeIcon;
        }

        /* 열기 버튼 이벤트 핸들러 */
        private void BtnOpen_Click(object sender, EventArgs e)
        {

        }

        /* 트리노드 확장,축소 아이콘 클릭 직전 이벤트 핸들러 */
        private void TrvFolder_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode current = e.Node;
            // MessageBox.Show(current.FullPath); // 되는지 확인하려고!

            // 폼이 로드 된 후 최초의 상태라면,
            if (current.Nodes.Count == 1 && current.Nodes[0].Text.Equals("..."))
            {
                current.Nodes.Clear(); // "..." 삭제
                // FullPath, ]내 컴퓨터\C:\] 에서 [C\]만 남김
                String path = current.FullPath.Substring(current.FullPath.IndexOf("\\") + 1);

                try // 예외처리!
                {
                    string[] directories = Directory.GetDirectories(path);
                    foreach (var directory in directories)
                    {
                        // Debug.WriteLine(directory); // 디버그 할 때만 사용하는 코드
                        TreeNode newNode = current.Nodes.Add(directory.Substring(directory.LastIndexOf("\\") + 1));
                        newNode.ImageIndex = 1; // 미선택 시 폴더 이미지는 1번
                        newNode.SelectedImageIndex = 2;
                        newNode.Nodes.Add("...");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "경고!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /* 트리노드 선택 후 이벤트 핸들러 */
        private void TrvFolder_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // 폴더에서 노드 선택하면 리스트뷰에 파일 표시
            TreeNode current = e.Node;
            if (e.Node == null) return;

            string path = current.FullPath.Replace("\\\\", "\\");
            // MessageBox.Show(path); // 잘 실행 되는지 확인! 디버그로 확인 or 메세지 박스 활용
            TxtPath.Text = path.Substring(path.IndexOf("\\") + 1); // [내 컴퓨터\] 를 제거

            try // 예외처리
            {
                LsvFile.Items.Clear(); // 다른 폴더에 있던 이전 파일 정보를 초기화

                // 현재 폴더의 하위폴더 정보 디스플레이
                string[] directoies = Directory.GetDirectories(TxtPath.Text);
                foreach (var directory in directoies)
                {
                    DirectoryInfo info = new DirectoryInfo(directory);

                    // 리스트뷰 컬럼 순서 : 이름, 수정한 날짜, 유형, 크기 순으로 리스트뷰 아이템 생성
                    // 문자열 빈값 : "", string.Empty
                    ListViewItem item = new ListViewItem(new string[] { info.Name, info.LastWriteTime.ToString(), "파일 폴더", string.Empty });
                    item.ImageIndex = 1; // 리스트뷰의 폴더 이미지 인덱스
                    LsvFile.Items.Add(item);
                }

                // 파일 리스트업
                string[] files = Directory.GetFiles(TxtPath.Text); // 현재 폴더의 파일 정보 가져오기
                foreach (var file in files)
                {
                    FileInfo info = new FileInfo(file);
                    ListViewItem item = new ListViewItem(new string[] { info.Name, info.LastWriteTime.ToString(), info.Extension, info.Length.ToString() });
                    item.ImageIndex = GetImageIndex(info.Extension);
                    LsvFile.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "경고!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* 이미지 인덱스 함수 */
        private int GetImageIndex(string extension)
        {
            // 아이콘 리스트 : 3 실행파일, 4 일반파일, 5 txt 파일
            var index = -1;
            switch (extension)
            {
                case ".exe":
                    index = 3;
                    break;
                case ".txt":
                    index = 5;
                    break;
                default:
                    index = 4;
                    break;
            }
            return index;
        }

        /* 리스트뷰 마우스 클릭 이벤트 핸들러 */
        private void LsvFile_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // 컨텍스트 메뉴는 오른쪽 버튼에서만 동작
                CmsFiles.Show(LsvFile, e.Location); // 마우스 클릭한 위치에 창 띄우기
            }
        }
    }
}
