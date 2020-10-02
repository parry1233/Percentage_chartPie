using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NET_hw12_DrawPie
{
	public partial class Form1 : Form
	{
		private int Max_Height;
		private int Max_Width;
		private int Uni_Width;
		private double[] person;
		private Graphics g;
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.g = this.CreateGraphics();
			this.person = new double[2];
			this.Max_Height = 300;
			this.Max_Width = 350;
			this.Uni_Width = 80;
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			/*Rectangle r_deafult = new Rectangle(30, 122, 300, 300);
			SolidBrush brush_default = new SolidBrush(Color.White);
			g.FillPie(brush_default, r_deafult, 0, 360);*/
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			count(textBox1.Text, textBox2.Text);
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			count(textBox1.Text, textBox2.Text);
		}

		private void count(string male,string female)
		{
			try
			{
				person[0] = Convert.ToDouble(male);
			}
			catch (System.FormatException)
			{
				person[0] = 0;
			}
			catch (System.NullReferenceException)
			{
				person[0] = 0;
			}

			try
			{
				person[1] = Convert.ToDouble(female);
			}
			catch (System.FormatException)
			{
				person[1] = 0;
			}
			catch (System.NullReferenceException)
			{
				person[1] = 0;
			}

			double sum = this.person[0] + this.person[1];
			double percent_Male = this.person[0] / sum;
			double percent_Female = this.person[1] / sum;
			label3.Text = "Male(%) :" + (percent_Male * 100).ToString("0.0") + " %";
			label4.Text = "Female(%) :" + (percent_Female * 100).ToString("0.0") + " %";
			paint(percent_Male, percent_Female);
		}

		private void paint(double Pmale, double Pfemale)
		{
			this.Refresh();
			Rectangle r_deafult = new Rectangle(30, 122, 300, 300);
			SolidBrush brush_male = new SolidBrush(Color.Blue);
			SolidBrush brush_female = new SolidBrush(Color.Red);
			double male_start_angle = 0;
			double male_end_angle = 360 * Pmale;
			double female_start_angle = male_end_angle;
			double female_end_angle = 360*Pfemale;

			if (male_end_angle - male_start_angle == 0 && female_end_angle - female_start_angle == 0)
			{
				SolidBrush brush_default = new SolidBrush(Color.White);
				g.FillPie(brush_default, r_deafult, 0, 360);
			}
			else
			{
				g.FillPie(brush_male, r_deafult, Convert.ToInt32(male_start_angle), Convert.ToInt32(male_end_angle));
				g.FillPie(brush_female, r_deafult, Convert.ToInt32(female_start_angle), Convert.ToInt32(female_end_angle));
			}
		}
	}
}
