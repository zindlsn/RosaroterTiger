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
    /// Interaction logic for PomodoroPage.xaml
    /// </summary>
    public partial class PomodoroPage : Page
    {
		private bool PlayActive = false;
		public PomodoroPage()
        {
            InitializeComponent();
        }
        
        private void StartButton_MouseEnter(object sender, EventArgs e)
        {
            StartButton.Opacity = 1;
        }

        private void StartButton_MouseLeave(object sender, EventArgs e)
        {
            StartButton.Opacity = .5;
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
		private void CheckTask_MouseEnter(object sender, EventArgs e)
		{
		//	CheckTask.Opacity = 1;
		}

		private void CheckTask_MouseLeave(object sender, EventArgs e)
		{
		//	CheckTask.Opacity = .5;
		}
		private void StartTask_MouseEnter(object sender, EventArgs e)
		{
		//	StartTask.Opacity = 1;
		}

		private void StartTask_MouseLeave(object sender, EventArgs e)
		{

		}

		private void EndButton_MouseEnter(object sender, EventArgs e)
		{
			EndButton.Opacity = 1;
		}

		private void EndButton_MouseLeave(object sender, EventArgs e)
		{
			EndButton.Opacity = .5;
		}
		private void StartButton_MouseUp(object sender, MouseButtonEventArgs e)
		{
			model.StartTimer();
			if (!PlayActive)
			{
				PlayActive = true;
				StartButton.Background = new ImageBrush(new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/Pause.png")));
			}
            else {
				PlayActive = false;
				StartButton.Background = new ImageBrush(new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/Play.png")));
			}
		}

        private void AddButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Window addWindow = new AddGoalWindow();
            addWindow.Show();
        }

        private void StartTask_DoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void EndButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            new AddComment().Show();
        }

        private void TextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        int selectedlabel =1;

        private void CheckTask_MouseUp(object sender, MouseButtonEventArgs e)
        {
            selectedlabel = 2;
        }

        private void StartTask_MouseUp(object sender, MouseButtonEventArgs e)
        {
            selectedlabel = 3;
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
           // MessageBox.Show(((Task)e.NewValue).ToString());
        }

        private void EditButton_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void TreeView_MouseUp(object sender, MouseButtonEventArgs e)
        {

            if (selectedlabel == 3)
            {
                MessageBox.Show("Done");

            }
            else if (selectedlabel == 2)
            {
                MessageBox.Show("Start");

            }
        }
    }
}
