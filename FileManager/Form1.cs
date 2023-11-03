using Microsoft.VisualBasic.FileIO;
using System.IO;
using System.Reflection;

namespace FileManager
{
    public partial class Form1 : Form
    {
        string path;
        string bufferedFile;
        string bufferedFilePath;
        bool cut = false;
        public Form1()
        {
            InitializeComponent(); listBoxDrives.Items.AddRange(DriveInfo.GetDrives().ToList().Select(drive => drive.Name.Split('\\')[0]).ToArray());
            buttonDelete.Enabled = false;
            buttonCopy.Enabled = false;
            buttonCut.Enabled = false;
            buttonPaste.Enabled = false;
        }

        private void listBoxDrives_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxDrives.SelectedIndex == -1)
            {
                return;
            }
            if (textBoxFilter.Text == null)
            {
                return;
            }
            if (File.Exists($"{path}\\{listBoxDrives.SelectedItem}"))
            {
                return;
            }
            path += $"{listBoxDrives.SelectedItem}\\";
            UpdateCurrent();
        }

        private void UpdateCurrent()
        {
            listBoxDrives.Items.Clear();
            if (path == "" || path == "\\")
            {
                path = "";
                labelPath.Text = path;
                listBoxDrives.Items.AddRange(DriveInfo.GetDrives().ToList().Select(drive => drive.Name.Split('\\')[0]).ToArray());
                return;
            }
            List<string> list = new List<string>();
            try
            {
                list = Directory.GetDirectories(path).ToList();
            }
            catch
            { }
            foreach (var item in list)
            {
                if (textBoxFilter.Text == "")
                {
                    listBoxDrives.Items.Add(item.Split('\\').Last());
                }
                else
                {
                    if (item.Split('\\').Last().Contains(textBoxFilter.Text))
                    {
                        listBoxDrives.Items.Add(item.Split('\\').Last());
                    }
                }
            }
            try
            {
                list = Directory.GetFiles(path).ToList();
            }
            catch
            {
                list = new List<string>();
            }
            foreach (var item in list)
            {
                if (textBoxFilter.Text == "")
                {
                    listBoxDrives.Items.Add(item.Split('\\').Last());
                }
                else
                {
                    if (item.Split('\\').Last().Contains(textBoxFilter.Text))
                    {
                        listBoxDrives.Items.Add(item.Split('\\').Last());
                    }
                }
            }
            labelPath.Text = path;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (path == "")
                return;
            List<string> tmp = path.Split('\\').ToList();
            if (tmp.Last() == "")
                tmp.RemoveAt(tmp.Count - 1);
            tmp.RemoveAt(tmp.Count - 1);
            path = string.Join('\\', tmp);
            path += '\\';
            UpdateCurrent();
        }

        private void listBoxDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonDelete.Enabled = listBoxDrives.SelectedIndex != -1;
            buttonCopy.Enabled = listBoxDrives.SelectedIndex != -1;
            buttonCut.Enabled = listBoxDrives.SelectedIndex != -1;
            if (listBoxDrives.SelectedIndex == -1)
            {
                labelSelected.Text = "None!";
                return;
            }
            labelSelected.Text = listBoxDrives.SelectedItem.ToString();
        }

        private void UpdateSelectedProperties()
        {
            string selectedPath = $"{path}{listBoxDrives.SelectedItem}";
            listBoxSelectedProperties.Items.Clear();
            if (selectedPath == "" || selectedPath == null)
            {
                return;
            }
            List<DriveInfo> drives = DriveInfo.GetDrives().ToList();
            DriveInfo currentDrive = null;
            try
            {
                currentDrive = drives.Find(drive => string.Equals(drive.Name.Remove(selectedPath.Length, 1), selectedPath));
            }
            catch (Exception ex) { }
            if (currentDrive != null)
            {
                listBoxSelectedProperties.Items.Add($"Full name: {currentDrive.Name}");
                listBoxSelectedProperties.Items.Add($"Total size: {Math.Round((double)currentDrive.TotalSize / (1024 * 1024 * 1024), 3)}(GB)");
                listBoxSelectedProperties.Items.Add($"Drive type: {currentDrive.DriveType}");
                listBoxSelectedProperties.Items.Add($"File system: {currentDrive.DriveFormat}");
                listBoxSelectedProperties.Items.Add($"Free space: {Math.Round((double)currentDrive.AvailableFreeSpace / (1024 * 1024 * 1024), 3)}(GB)");
                return;
            }
            if (File.Exists(selectedPath))
            {
                FileInfo fileInfo = new FileInfo(selectedPath);
                listBoxSelectedProperties.Items.Add($"Full name: {fileInfo.FullName}");
                listBoxSelectedProperties.Items.Add($"Creation date: {fileInfo.CreationTime.ToShortDateString()}");
                listBoxSelectedProperties.Items.Add($"Extension: {fileInfo.Extension}");
                listBoxSelectedProperties.Items.Add($"Last change date: {fileInfo.LastWriteTime.ToShortDateString()}");
                double fileSize = fileInfo.Length;
                if (fileSize < 512)
                {
                    listBoxSelectedProperties.Items.Add($"Size: {fileSize}(B)");
                }
                else if (fileSize < 1024 * 512)
                {
                    listBoxSelectedProperties.Items.Add($"Size: {Math.Round(fileSize / 1024, 2)}(KB)");
                }
                else if (fileSize < 1024 * 1024 * 512)
                {
                    listBoxSelectedProperties.Items.Add($"Size: {Math.Round(fileSize / (1024 * 1024), 2)}(MB)");
                }
                else
                {
                    listBoxSelectedProperties.Items.Add($"Size: {Math.Round(fileSize / (1024 * 1024 * 1024), 2)}(GB)");
                }
                return;
            }
            if (Directory.Exists(selectedPath))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(selectedPath);
                listBoxSelectedProperties.Items.Add($"Full name: {directoryInfo.FullName}");
                listBoxSelectedProperties.Items.Add($"Creation date: {directoryInfo.CreationTime.ToShortDateString()}");
                listBoxSelectedProperties.Items.Add($"Last change date: {directoryInfo.LastWriteTime.ToShortDateString()}");
                listBoxSelectedProperties.Items.Add($"Parent: {directoryInfo.Parent}");
                double dirSize = GetDirectorySize(selectedPath);
                if (dirSize < 512)
                {
                    listBoxSelectedProperties.Items.Add($"Size: {dirSize}(B)");
                }
                else if (dirSize < 1024 * 512)
                {
                    listBoxSelectedProperties.Items.Add($"Size: {Math.Round(dirSize / 1024, 2)}(KB)");
                }
                else if (dirSize < 1024 * 1024 * 512)
                {
                    listBoxSelectedProperties.Items.Add($"Size: {Math.Round(dirSize / (1024 * 1024), 2)}(MB)");
                }
                else
                {
                    listBoxSelectedProperties.Items.Add($"Size: {Math.Round(dirSize / (1024 * 1024 * 1024), 2)}(GB)");
                }
                return;
            }
        }

        private double GetDirectorySize(string selectedPath)
        {
            double size = 0;
            try
            {
                foreach (var file in Directory.GetFiles(selectedPath))
                {
                    FileInfo fileInfo = new FileInfo(file);
                    size += fileInfo.Length;
                }
                foreach (var dir in Directory.GetDirectories(selectedPath))
                {
                    size += GetDirectorySize(dir);
                }
            }
            catch (Exception ex) { }
            return size;
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            if (bufferedFile == null)
            {
                return;
            }
            bufferedFile = listBoxDrives.SelectedItem.ToString();
            labelBuffer.Text = bufferedFile;
            bufferedFilePath = $"{path}{listBoxDrives.SelectedItem}";
            cut = false;
            buttonPaste.Enabled = true;
        }

        private void buttonPaste_Click(object sender, EventArgs e)
        {
            if (path == "")
            {
                return;
            }
            Thread newThread = new Thread(Paste);
            List<object> list = new List<object>() { bufferedFilePath, path, cut };
            newThread.Start(list);
        }
        public void Paste(object param)
        {
            if (bufferedFile == null)
            {
                return;
            }
            List<object> list = (List<object>)param;
            string source = (string)list[0];
            string dest = (string)list[1];
            bool cut = (bool)list[2];

            if (File.Exists(source))
            {
                File.Copy(source, $"{dest}{source.Split('\\').Last()}");
                if (cut)
                {
                    File.Delete(source);
                    bufferedFilePath = "";
                    bufferedFile = "None!";
                    cut = false;
                }
            }
            else
            {
                Directory.CreateDirectory($"{dest}{source.Split('\\').Last()}");
                CopyAll(source, $"{dest}{source.Split('\\').Last()}");

                if (cut)
                {
                    DeleteDir(source);
                    bufferedFilePath = "";
                    bufferedFile = "None!";
                    cut = false;
                }
            }

            labelBuffer.Invoke(() => labelBuffer.Text = bufferedFile);
            buttonPaste.Invoke(() => buttonPaste.Enabled = cut);
            listBoxDrives.Invoke(() => UpdateCurrent());
        }

        public void DeleteDir(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return;
            }
            if (!Directory.Exists(path))
            {
                return;
            }
            foreach (var file in Directory.GetFiles(path))
            {
                File.Delete(file);
            }
            foreach (var subDir in Directory.GetDirectories(path))
            {
                DeleteDir(subDir);
            }
            Directory.Delete(path);
        }

        public void CopyAll(string source, string dest)
        {
            foreach (var file in Directory.GetFiles(source))
            {
                File.Copy(file, $"{dest}\\{file.Split('\\').Last()}");
            }
            foreach (var dir in Directory.GetDirectories(source))
            {
                Directory.CreateDirectory($"{dest}\\{dir.Split('\\').Last()}");
                CopyAll(dir, $"{dest}\\{dir.Split('\\').Last()}");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (bufferedFile == null)
            {
                return;
            }
            string source = $"{path}{listBoxDrives.SelectedItem}";
            Thread new_thread = new Thread(Delete);
            new_thread.Start(source);
        }

        private void Delete(object obj)
        {
            string source = (string)obj;
            if (File.Exists(source))
            {
                File.Delete(source);
            }
            else
            {
                DeleteDir(source);
            }
            listBoxDrives.Invoke(() => UpdateCurrent());
        }

        private void buttonCut_Click(object sender, EventArgs e)
        {
            bufferedFile = listBoxDrives.SelectedItem.ToString();
            labelBuffer.Text = bufferedFile;
            bufferedFilePath = $"{path}{listBoxDrives.SelectedItem}";
            cut = true;
            buttonPaste.Enabled = true;
        }

        private void buttonProperties_Click(object sender, EventArgs e)
        {
            if (listBoxDrives.SelectedIndex == -1)
            {
                return;
            }
            UpdateSelectedProperties();
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            UpdateCurrent();
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            switch (clicked.Tag)
            {
                case "asc":
                    SortAsc();
                    break;
                case "desc":
                    SortDesc();
                    break;
            }
        }

        private void SortAsc()
        {
            List<string> elements = new List<string>();
            foreach (var element in listBoxDrives.Items)
            {
                elements.Add(element.ToString());
            }
            elements.Sort();
            listBoxDrives.Items.Clear();
            listBoxDrives.Items.AddRange(elements.ToArray());
        }
        private void SortDesc()
        {
            List<string> elements = new List<string>();
            foreach (var element in listBoxDrives.Items)
            {
                elements.Add(element.ToString());
            }
            elements.Sort();
            elements.Reverse();
            listBoxDrives.Items.Clear();
            listBoxDrives.Items.AddRange(elements.ToArray());
        }
    }
}