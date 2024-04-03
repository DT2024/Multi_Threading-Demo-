using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Week11.Threads
{
    public partial class MultiThread : Form
    {
        public MultiThread()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
     
           

            listBox1.Items.Clear();

           
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Text area cannot be empty. Please enter a number!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!int.TryParse(textBox1.Text, out int id))
            {
                MessageBox.Show("Please enter a valid number! it should be an integer value", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int num = Convert.ToInt32(textBox1.Text); //getting user input
            Task task1 = Task.Run(() => DoTask(num)); //just calling 
        }
     

        public int Fibonacci(int n) //fibonacci method
        {
            if (n <= 1)
            {
                return n;
            }
            int a = 0;
            int b = 1;
            int c = 0;

            for (int i = 2; i <= n; i++)
            {
                c = b + a;
                a = b;
                b = c;

            }
            return c;

        }
        private void DoTask(int n)
        {
            int num = Convert.ToInt32(textBox1.Text);
            for (int i = 0; i < num; i++)
            {
                int result = Fibonacci(i);
                // Update the UI using BeginInvoke to marshal the call to the UI thread
                BeginInvoke(new Action(() =>
                {
                    listBox1.Items.Add(result);
                }));

                Thread.Sleep(100); // Simulate work by sleeping for 0.1 seconds
            }

        }
    }
}
