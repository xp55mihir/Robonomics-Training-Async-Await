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
        // The program was written following instructions from the Youtube tutorial below:
        // https://www.youtube.com/watch?app=desktop&v=C5VhaxQWcpE
        // Minor changes from the program written in the video include changing variable names, 
        // using verbatim literal to specify file location, and commenting. 


        // Function that counts the number of characters in a specified text file,
        // and returns that number as an integer value.
        private int CharacterCounter()
        {
            int numChar = 0; // Declares variable to store number of characters as an integer value.
            using (StreamReader reader = new StreamReader(@"C:\Users\Mihir\Desktop\Robonomics Internship\Email.txt"))
            {
                string extract = reader.ReadToEnd(); // Stores entire file content in a string.
                numChar = extract.Length; // Stores number of string characters.
                Thread.Sleep(5000); // Pauses for 5 seconds.
            }

            return numChar; // Returns number of string characters.
        }

        // Function that uses async await as part of its execution and 
        // displays processing status, when "Process File" button is clicked.
        private async void Button_PF_Click(object sender, EventArgs e)
        {
            Task<int> task = new Task<int>(CharacterCounter);
            task.Start(); // task executes CharacterCounter function.
            // User can interact with the form while task is executing the fucntion.

            Counter.Text = "Processing file. Please wait ..."; // Diplays processing file status.
            int count = await task; // When execution of the code reaches this point, the application
            // will wait until task is completed. Number of characters is stored in count variable.
            Counter.Text = count.ToString() + " characters in file."; // Displays number of characters in file.
        }
    }
}
