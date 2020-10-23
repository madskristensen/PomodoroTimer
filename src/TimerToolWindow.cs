using Microsoft.VisualStudio.Shell;

using System;
using System.Runtime.InteropServices;

namespace Pomodoro
{
	[Guid("cd936ab2-f814-48d0-aec5-a3993e2cbb90")]
	public class TimerToolWindow : ToolWindowPane
	{

		public TimerToolWindow() : base(null)
		{
			Caption = "Pomodoro Timer";
			Content = new TimerToolWindowControl();
		}
	}
}
