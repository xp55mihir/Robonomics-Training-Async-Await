using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Async_Await_Program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int CharacterCounter()
        {
            int numChar = 0;
            using (StreamReader reader = new StreamReader(@"C:\Users\Mihir\Desktop\Robonomics Internship\Email.txt"))
            {
                string extract = reader.ReadToEnd();
                numChar = extract.Length;
                Thread.Sleep(5000);
            }

            return numChar;
        }

        private async void Button_PF_Click(object sender, EventArgs e)
        {
            Task<int> task = new Task<int>(CharacterCounter);
            task.Start();

            Counter.Text = "Processing file. Please wait ...";
            int count = await task;
            Counter.Text = count.ToString() + " characters in file.";
        }
    }
}
