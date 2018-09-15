using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamStart.Interfaces;

namespace XamStart.Views
{
	public partial class Home : ContentPage, IHomePage
	{
		public Home ()
		{
			InitializeComponent ();
		}
	}
}