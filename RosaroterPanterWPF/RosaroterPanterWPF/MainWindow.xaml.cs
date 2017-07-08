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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RosaroterPanterWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
        }

        private void HomeButton_MouseEnter(object sender, EventArgs e)
        {
            HomeButton.Opacity = 1;
        }

        private void HomeButton_MouseLeave(object sender, EventArgs e)
        {
            HomeButton.Opacity = .5;
        }
    }

}
