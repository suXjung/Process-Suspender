using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace bsj_007
{
	// Token: 0x02000004 RID: 4
	public partial class frm1 : Form
	{
		// Token: 0x06000007 RID: 7 RVA: 0x000020F4 File Offset: 0x000002F4
		public frm1()
		{
			this.InitializeComponent();
			this.textBox1.Click += this.tb1_click;
			this.t.Interval = 100;
			this.t.Tick += this.tessd;
			new ToolTip().SetToolTip(this.checkBox1, "이 옵션을 활성화 하면 입력된 이름의 첫 번째 프로세스를 자동으로 서스펜드 시킵니다.");
			new ToolTip().SetToolTip(this.checkBox2, "이 옵션을 활성화 하면 입력된 이름의 첫 번째 프로세스를 항상 서스펜드 시킵니다.");
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002170 File Offset: 0x00000370
		private void Button1Click(object sender, EventArgs e)
		{
			if (this.button1.Text == "Waiting..")
			{
				this.textBox1.Enabled = true;
				this.checkBox1.Enabled = true;
				this.checkBox2.Enabled = false;
				this.button1.Text = "Suspend";
				this.button1.ForeColor = Color.Black;
				this.t.Stop();
				this.i = 0;
				return;
			}
			if (this.button1.Text == "Resume")
			{
				try
				{
					process.ResumeProcess(this.gp.Id);
					base.Close();
				}
				catch
				{
					return;
				}
				this.button1.ForeColor = Color.Black;
				this.button1.Text = "Suspend";
				this.textBox1.Enabled = true;
				this.checkBox1.Enabled = true;
				this.checkBox2.Enabled = false;
				return;
			}
			if (this.textBox1.Text != string.Empty)
			{
				if (this.checkBox1.CheckState == CheckState.Checked)
				{
					this.gp = null;
					this.button1.Text = "Waiting..";
					this.button1.ForeColor = Color.Blue;
					this.textBox1.Enabled = false;
					this.checkBox1.Enabled = false;
					this.checkBox2.Enabled = false;
					this.t.Start();
					return;
				}
				Process[] processesByName = Process.GetProcessesByName(this.textBox1.Text);
				if (processesByName.Length != 1)
				{
					this.button1.ForeColor = Color.Red;
					return;
				}
				this.gp = processesByName[0];
				try
				{
					for (; ; )
					{
						if (this.checkBox2.CheckState == CheckState.Checked)
						{
							process.SuspendProcess(processesByName[0].Id);
						}
					}
				}
				catch
				{
				}
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000028D8 File Offset: 0x00000AD8
		private void tb1_click(object sender, EventArgs e)
		{
			if (this.textBox1.ForeColor == Color.Gray)
			{
				this.textBox1.ForeColor = Color.Black;
				this.textBox1.Text = string.Empty;
				this.button1.Enabled = true;
				this.checkBox1.Enabled = true;
				this.checkBox2.Enabled = true;
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002940 File Offset: 0x00000B40
		private void tessd(object sender, EventArgs e)
		{
			this.i++;
			try
			{
				Process[] processesByName = Process.GetProcessesByName(this.textBox1.Text);
				if (processesByName.Length != 1)
				{
					return;
				}
				this.gp = processesByName[0];
				this.t.Stop();
				this.i = 0;
				process.SuspendProcess(processesByName[0].Id);
				this.button1.ForeColor = Color.ForestGreen;
				this.button1.Text = "Resume";
			}
			catch
			{
			}
			if (this.i == 500)
			{
				this.i = 0;
				this.t.Stop();
				this.button1.Text = "Suspend";
				this.textBox1.Enabled = true;
				this.checkBox1.Enabled = true;
				this.checkBox2.Enabled = true;
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x0000207F File Offset: 0x0000027F
		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://www.youtube.com/channel/UCn7seSVRA84bGyPaitLIsxg");
		}

		// Token: 0x04000003 RID: 3
		private int i;

		// Token: 0x04000004 RID: 4
		private Process gp;

		// Token: 0x04000005 RID: 5
		private Timer t = new Timer();
	}
}
