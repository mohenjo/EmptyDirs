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
                    MessageBox.Show("�ֻ��� ������ ������ �� �����ϴ�.");
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
            ButtonDisplay.Text = "���� ������ �д� ���Դϴ�. ��� ��ٷ� �ּ���.";
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
                MessageBox.Show($"'{path}' ������ ������ �� �����ϴ�.");
            }
        }

        /// <summary>
        /// �� ũ�� ���� �� ����Ʈ ���� �÷��� ����
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
        /// ����Ʈ �信 ���� ���丮 �Ӽ��� ���
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
                    lvi.SubItems.Add(itemStatus == Status.Empty ? "�� ����" : "�� ���� ����");
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
#pragma warning disable CS8602 // null ���� ������ ���� �������Դϴ�.
            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
#pragma warning restore CS8602 // null ���� ������ ���� �������Դϴ�.
            StringBuilder sb = new();
            sb.AppendLine($"- Title: {title}");
            sb.AppendLine($"- Description: {description}");
            sb.AppendLine($"- Author: {author}");
            sb.AppendLine($"- Version: {version}");
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("���� ���� ������ ������ �Ұ����� ���丮�� ���Ե� ��� ���� ����� log.txt�� �α׵˴ϴ�:");
            sb.AppendLine();
            sb.AppendLine(".NET System.IO.FileAttributes �������� Directory(�Ϲ� ���丮)�� �ƴ� ��� ȸ������ ǥ�õ˴ϴ�.");
   
            string msg = sb.ToString();

            MessageBox.Show(msg, this.Text, MessageBoxButtons.OK);
        }
    }
}