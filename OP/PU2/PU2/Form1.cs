using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PU2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string IsNullOrSpace(string s)
        {
            if (s == null || s.Trim() == string.Empty)
            {
                throw new ArgumentException("Ivedimas ne gali buti tuscias arba lygus null");
            }
            return s;

        }

        private DateTime IsDateValid(DateTime d)
        {
            DateTime curr = DateTime.Today;
            if (!(d.Day <= curr.Day && d.Month < curr.Month && d.Year < curr.Year))
            {
                throw new ArgumentException("Gimimo data negali buti didesni, nei esama");
            }
            return d;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Person p;
            try
            {
                p = new Person(IsNullOrSpace(this.textBox1.Text), IsNullOrSpace(this.textBox2.Text), IsDateValid(DateTime.Parse(this.textBox3.Text)));
                MessageBox.Show(p.PrintInfo(), "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                this.textBox1.Text = ""; this.textBox2.Text = ""; this.textBox3.Text = "";
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
