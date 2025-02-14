using Spire.Xls.Core;

namespace ROMSystem
{
    public partial class Form1 : Form
    {
        Dictionary<string, bool> FileSuccess = new();
        SemaphoreSlim semaphore = new(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ThreadMaxNum"])); // 限制并发数为 5
        private Dictionary<string, ProgressBar> progressBars = new();
        public Form1()
        {
            InitializeComponent();
        }

        private async Task StartProcess(string[] fileNames)
        {
            await Task.Delay(1);
                       FileSuccess = fileNames.Distinct().ToDictionary(fileName => fileName, _ => false);

            foreach (var file in fileNames)
            {
                MyProgress myProgress = new();
                myProgress.SetFileName(file);
                var progress =  myProgress.GetProgress();
                flowLayoutPanel.Controls.Add(myProgress);
                // 启动任务
                Task.Run(()=>processFile(file,progress));
            }
        }
          private async Task processFile(string file, IProgress<int> progress)
        {
            try
            {
                bool success = await pdfToExcel.Transform(file,progress);
                if (success)
                {
                    lock (FileSuccess)
                    {
                        FileSuccess[file] = true;
                    }
                }

            }
            catch
            {
            }
        }

        private void ExcelOutButton_Click(object sender, EventArgs e)
        {

        }

        private void PDFInButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//
            dialog.Title = "选择文件";
            dialog.Filter = "PDF文件(*.pdf)|*.pdf";
            string[] fileNames = { };
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileNames = dialog.FileNames;
            }
            else
                return;
            if (fileNames.Count() == 0)
                return;

            StartProcess(fileNames);
        }
    }
}
