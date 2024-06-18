using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace HellMouse
{
	public class TrayIconContainer : Form
	{
		public NotifyIcon _trayIcon;

		public TrayIconContainer() : base()
		{
			InitializeComponent();
		}



		protected override void OnLoad(EventArgs e)
		{
			Visible = false;
			ShowInTaskbar = false;
			base.OnLoad(e);
		}


		private void InitializeComponent()
		{
			var components = new System.ComponentModel.Container();
			_trayIcon = new NotifyIcon(components);
			SuspendLayout();
			_trayIcon.Icon = SystemIcons.Application;
			_trayIcon.Text = "HellMouse";
			_trayIcon.Visible = true;
			_trayIcon.ContextMenuStrip = new();
			_trayIcon.ContextMenuStrip.Items.Add("Exit app", null, (sender, eventArgs) => Application.Exit());
			ResumeLayout(false);
		}
	}
}
