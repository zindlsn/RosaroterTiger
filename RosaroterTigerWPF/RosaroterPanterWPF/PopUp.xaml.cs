using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RosaroterTigerWPF
{
	/// <summary>
	/// Interaktionslogik für PopUp.xaml
	/// </summary>
	public partial class PopUp : Window
	{
		public PopUp()
		{
			InitializeComponent();
		}

        private void Submit(object sender, EventArgs e)
        {
            new ColorPicker().Show();
            this.Close();
        }
            
	}
}
