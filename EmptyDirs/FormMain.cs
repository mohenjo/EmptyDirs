using System.Diagnostics;
using System.Text;

namespace EmptyDirs
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            TextBoxRootPath.Text = Globals.CurrentRootPath;
        }



        private void ListViewMain_Resize(object sender, EventArgs e)
        {
            ResizeListView();
        }


        private void ButtonSelectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new()
            {
                SelectedPath = Globals.CurrentRootPath
            };
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selected = folderBrowserDialog.SelectedPath;
                DirectoryInfo di = new(selected);
                if (di.Parent == null) // is Root
                {
                    MessageBox.Show("최상위 폴더는 선택할 수 없습니다.");
                }
                else
                {
                    Globals.CurrentRootPath = folderBrowserDialog.SelectedPath;
                    TextBoxRootPath.Text = Globals.CurrentRootPath;
                }
            }
        }

        private void ButtonDisplay_Click(object sender, EventArgs e)
        {
            string previousText = ButtonDisplay.Text;
            ButtonDisplay.Text = "폴더 정보를 읽는 중입니다. 잠시 기다려 주세요.";
            ButtonDisplay.Enabled = false;
            ButtonDisplay.Refresh();
            ListViewMain.Enabled = false;
            DisplayContents();
            ButtonDisplay.Text = previousText;
            ButtonDisplay.Enabled = true;
            ListViewMain.Enabled = true;
        }


        private void ListViewMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListView.SelectedListViewItemCollection item = ListViewMain.SelectedItems;
            string path = item[0].Text;
            if (Directory.Exists(path))
            {
                ProcessStartInfo startInfo = new(fileName: "explorer.exe", arguments: path);
                Process.Start(startInfo);
            }
            else
            {
                MessageBox.Show($"'{path}' 폴더에 접근할 수 없습니다.");
            }
        }

        /// <summary>
        /// 폼 크기 변경 시 리스트 뷰의 컬럼을 조정
        /// </summary>
        private void ResizeListView()
        {
            if (ListViewMain.Items.Count > 0)
            {
                ListViewMain.BeginUpdate();
                ListViewMain.Columns[1].Width = -2;
                ListViewMain.Columns[2].Width = -1;
                ListViewMain.Columns[0].Width = ListViewMain.Width - ListViewMain.Columns[1].Width - ListViewMain.Columns[2].Width;
                ListViewMain.EndUpdate();
            }
            else
            {
                ListViewMain.BeginUpdate();
                ListViewMain.Columns[0].Width = 120;
                ListViewMain.Columns[1].Width = 120;
                ListViewMain.Columns[2].Width = 120;
                ListViewMain.EndUpdate();
            }
        }

        /// <summary>
        /// 리스트 뷰에 하위 디렉토리 속성을 출력
        /// </summary>
        private void DisplayContents()
        {
            ListViewMain.Items.Clear();
            ResizeListView();

            DirectoryStatus ds = new(Globals.CurrentRootPath);
            ds.GetDirtoryStatus();

            ListViewMain.BeginUpdate();

            foreach (string dir in ds.AllDirectories)
            {
                Status itemStatus = ds.Statuses[dir];
                if (itemStatus == Status.Empty || itemStatus == Status.ContainsEmpty)
                {
                    ListViewItem lvi = new(dir);
                    lvi.SubItems.Add(itemStatus == Status.Empty ? "빈 폴더" : "빈 폴더 포함");
                    DirectoryInfo di = new(dir);
                    lvi.SubItems.Add(di.Attributes.ToString());
                    ListViewMain.Items.Add(lvi);
                    if (di.Attributes != FileAttributes.Directory)
                    {
                        lvi.ForeColor = SystemColors.GrayText;
                    }
                    else
                    {
                        lvi.ForeColor = SystemColors.WindowText;
                    }
                }
            }
            ResizeListView();

            ListViewMain.EndUpdate();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = "EmptyDirs";
            string description = "Search Empty Directories";
            string author = "Haennim Park";
#pragma warning disable CS8602 // null 가능 참조에 대한 역참조입니다.
            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
#pragma warning restore CS8602 // null 가능 참조에 대한 역참조입니다.
            StringBuilder sb = new();
            sb.AppendLine($"- Title: {title}");
            sb.AppendLine($"- Description: {description}");
            sb.AppendLine($"- Author: {author}");
            sb.AppendLine($"- Version: {version}");
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("권한 등의 이유로 접근이 불가능한 디렉토리가 포함될 경우 실행 경로의 log.txt에 로그됩니다:");
            sb.AppendLine();
            sb.AppendLine(".NET System.IO.FileAttributes 열거형의 Directory(일반 디렉토리)가 아닌 경우 회색으로 표시됩니다.");
   
            string msg = sb.ToString();

            MessageBox.Show(msg, this.Text, MessageBoxButtons.OK);
        }
    }
}