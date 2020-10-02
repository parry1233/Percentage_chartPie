using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace NET_hw12_ChartPie
{
	public partial class Form1 : Form
	{
		private double[] person;// series Y
		private string[] name;//series X
		private Series series;
		public Form1()
		{
			InitializeComponent();
			series = new Series();
			person = new double[2];
			person[0] = 0;
			person[1] = 0;
			name = new string[] { "Male", "Female" };
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
			chart1.Series.Clear();
			//count male
			try
			{
				this.person[0] = Convert.ToDouble(male);
			}
			catch (System.NullReferenceException)
			{
				this.person[0] = 0;
			}
			catch (System.FormatException)
			{
				this.person[0] = 0;
			}

			//count female
			try
			{
				this.person[1] = Convert.ToDouble(female);
			}
			catch (System.NullReferenceException)
			{
				this.person[1] = 0;
			}
			catch (System.FormatException)
			{
				this.person[1] = 0;
			}
			series.ChartType = SeriesChartType.Pie;
			series.Points.DataBindXY( this.name , this.person);
			//series.Points.DataBindY(this.person);-->show pie only, no data binding
			chart1.Series.Add(series);
			chart1.Series[0].Points[0]["PieLabelStyle"] = "Disabled";
			chart1.Series[0].Points[1]["PieLabelStyle"] = "Disabled";

			double sum = this.person[0] + this.person[1];
			double percent_Male = this.person[0] / sum*100;
			double percent_Female = this.person[1] / sum*100;
			label3.Text = "Male(%) :" + percent_Male.ToString("0.0") +" %";
			label4.Text = "Female(%) :" + percent_Female.ToString("0.0") +" %";
		}
	}
}
