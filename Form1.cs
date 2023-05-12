using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Globalization;

namespace DateConverter
{
    public partial class Form1 : Form
    {
        PersianCalendar pc = new PersianCalendar();
        HijriCalendar hc = new HijriCalendar();
        GregorianCalendar gc = new GregorianCalendar();

        string date1;
        DateTime datetime = new DateTime();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            datetime = DateTime.Now;
            label16.Text = datetime.Year + " / " + datetime.Month + " / " + datetime.Day;
            label17.Text = hc.GetYear(datetime) + " / " + hc.GetMonth(datetime) + " / " + hc.GetDayOfMonth(datetime);
            label18.Text = pc.GetYear(datetime) + " / " + pc.GetMonth(datetime) + " / " + pc.GetDayOfMonth(datetime);

            for (int i = 0; i < 5; i++)
            {
                comboBox1.Items.Add(i);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" & comboBox1.Text != "" & comboBox1.Text != "")
            {
                date1 = comboBox3.Text + "/" + comboBox2.Text + "/" + comboBox1.Text;

                //تبدیل تاریخ شمسی به میلادی و قمری
                if (radioButton1.Checked)
                {
                    DateTime dt1 = pc.ToDateTime(int.Parse(comboBox3.Text), int.Parse(comboBox2.Text), int.Parse(comboBox1.Text), 0, 0, 0, 0);
                    label1.Text = date1;
                    label9.Text = hc.GetYear(dt1) + "/" + hc.GetMonth(dt1) + "/" + hc.GetDayOfMonth(dt1);
                    label10.Text = dt1.Year + "/" + dt1.Month + "/" + dt1.Day;
                }

                //تبدیل تاریخ قمری به شمسی و میلادی
                if (radioButton2.Checked)
                {
                    DateTime dt2 = hc.ToDateTime(int.Parse(comboBox3.Text), int.Parse(comboBox2.Text), int.Parse(comboBox1.Text), 0, 0, 0, 0);
                    label1.Text = pc.GetYear(dt2) + "/" + pc.GetMonth(dt2) + "/" + pc.GetDayOfMonth(dt2);
                    label9.Text = date1;
                    label10.Text = dt2.Year + "/" + dt2.Month + "/" + dt2.Day;
                }

                //تبدیل تاریخ میلادی به شمسی و قمری
                if (radioButton3.Checked)
                {
                    DateTime dt = Convert.ToDateTime(date1);
                    label1.Text = pc.GetYear(dt) + "/" + pc.GetMonth(dt) + "/" + pc.GetDayOfMonth(dt);
                    label9.Text = hc.GetYear(dt) + "/" + hc.GetMonth(dt) + "/" + hc.GetDayOfMonth(dt);
                    label10.Text = dt.Year + "/" + dt.Month + "/" + dt.Day;
                }
            }
        }

        private void about_Click(object sender, EventArgs e)
        {
            MessageBox.Show("برنامه نویس: سید سجاد ائمی", "درباره", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}