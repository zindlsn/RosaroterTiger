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

namespace RosaroterTigerWPF
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void AddButton_MouseEnter(object sender, EventArgs e)
        {
            AddButton.Opacity = 1;
        }

        private void AddButton_MouseLeave(object sender, EventArgs e)
        {
            AddButton.Opacity = .5;
        }
        private void EditButton_MouseEnter(object sender, EventArgs e)
        {
            EditButton.Opacity = 1;
        }

        private void EditButton_MouseLeave(object sender, EventArgs e)
        {
            EditButton.Opacity = .5;
        }
        private void DeleteButton_MouseEnter(object sender, EventArgs e)
        {
            DeleteButton.Opacity = 1;
        }

        private void DeleteButton_MouseLeave(object sender, EventArgs e)
        {
            DeleteButton.Opacity = .5;
        }

        private void AddButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            EditGoalWindow addWindow = new EditGoalWindow();
            addWindow.Show();
        }

        private void DeleteButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            model.RemoveSelectedGoal();
        }

        private void EditButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            model.EditGoal();
            EditGoalWindow editWindow = new EditGoalWindow();
            editWindow.Show();

        }
    }
}
