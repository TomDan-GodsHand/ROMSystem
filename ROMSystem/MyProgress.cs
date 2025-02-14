using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMSystem
{
    public partial class MyProgress : UserControl
    {
        public MyProgress()
        {
            InitializeComponent();
        }
        public void SetFileName(string fileName)
        {
            textBox1.Text = fileName;
        }
        public IProgress<int> GetProgress()
        {
            var progress = new Progress<int>(value => progressBar1.Value = value);
            return progress;
        }

    }
}
