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
    /// Interaction logic for ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : Window
    {
        public ColorPicker()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // red
            model.PickColor(new Color(0xF0, 0xB7, 0xB7));
            Close();
        }

        private void PastBrown_Click(object sender, RoutedEventArgs e)
        {
            model.PickColor(new Color(0xF0, 0xD3, 0xB7));
            Close();
        }

        private void PastYellow_Click(object sender, RoutedEventArgs e)
        {
            model.PickColor(new Color(0xFF, 0xEF, 0xC3));
            Close();
        }

        private void PastGreen_Click(object sender, RoutedEventArgs e)
        {
            model.PickColor(new Color(0xEC, 0xFF, 0xC3));
            Close();
        }

        private void PastBlueGreen_Click(object sender, RoutedEventArgs e)
        {
            model.PickColor(new Color(0xC3, 0xFF, 0xDE));
            Close();
        }

        private void PastMintBlue_Click(object sender, RoutedEventArgs e)
        {
            model.PickColor(new Color(0xC3, 0xFF, 0xFA));
            Close();
        }

        private void PastBlue_Click(object sender, RoutedEventArgs e)
        {
            model.PickColor(new Color(0xC3, 0xE6, 0xFF));
            Close();
        }

        private void PastPurple_Click(object sender, RoutedEventArgs e)
        {
            model.PickColor(new Color(0xCE, 0xC3, 0xFF));
            Close();
        }

        private void PastPink_Click(object sender, RoutedEventArgs e)
        {
            model.PickColor(new Color(0xFA, 0xC3, 0xFF));
            Close();
        }
    }
}
