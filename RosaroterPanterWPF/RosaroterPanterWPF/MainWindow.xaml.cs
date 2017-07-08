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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Page HomePage;
        Page ReviewPage;
        Page PomodoroPage;

        public MainWindow()
        {
            InitializeComponent();
            HomePage = new HomePage();
            ReviewPage = new ReviewPage();
            PomodoroPage = new PomodoroPage();
            MainFrame.NavigationService.Navigate(new HomePage());

        }

        private void LoadReviewPage(object sender, EventArgs e)
        {
            MainFrame.NavigationService.Navigate(ReviewPage);
            PomodoroButton.Visibility = Visibility.Visible;
            ReviewButton.Visibility = Visibility.Hidden;
            HomeButton.Visibility = Visibility.Visible;
            BigPomodoroButton.Visibility = Visibility.Hidden;
            StartButton.Visibility = Visibility.Hidden;
        }

        private void LoadHomePage(object sender, EventArgs e)
        {
            MainFrame.NavigationService.Navigate(HomePage);
            PomodoroButton.Visibility = Visibility.Hidden;
            ReviewButton.Visibility = Visibility.Visible;
            HomeButton.Visibility = Visibility.Hidden;
            BigPomodoroButton.Visibility = Visibility.Visible;
            StartButton.Visibility = Visibility.Visible;
        }

        private void LoadPomodoroPage(object sender, EventArgs e)
        {
            MainFrame.NavigationService.Navigate(PomodoroPage);
            PomodoroButton.Visibility = Visibility.Hidden;
            ReviewButton.Visibility = Visibility.Visible;
            HomeButton.Visibility = Visibility.Visible;
            BigPomodoroButton.Visibility = Visibility.Hidden;
            StartButton.Visibility = Visibility.Hidden;
        }

        private void HomeButton_MouseEnter(object sender, EventArgs e)
        {
            HomeButton.Opacity = 1;
        }

        private void HomeButton_MouseLeave(object sender, EventArgs e)
        {
            HomeButton.Opacity = .5;
        }

        private void ReviewButton_MouseEnter(object sender, EventArgs e)
        {
            ReviewButton.Opacity = 1;
        }

        private void ReviewButton_MouseLeave(object sender, EventArgs e)
        {
            ReviewButton.Opacity = .5;
        }

        private void PomodoroButton_MouseEnter(object sender, EventArgs e)
        {
            PomodoroButton.Opacity = 1;
        }

        private void PomodoroButton_MouseLeave(object sender, EventArgs e)
        {
            PomodoroButton.Opacity = .5;
        }

        private void BigPomodoroButton_MouseEnter(object sender, EventArgs e)
        {
            BigPomodoroButton.Opacity = 1;
        }

        private void BigPomodoroButton_MouseLeave(object sender, EventArgs e)
        {
            BigPomodoroButton.Opacity = .75;
        }

        private void StartButton_MouseEnter(object sender, EventArgs e)
        {
            StartButton.Opacity = 1;
        }

        private void StartButton_MouseLeave(object sender, EventArgs e)
        {
            StartButton.Opacity = .5;
        }
        //private void addbutton_mouseenter(object sender, eventargs e)
        //{
        //    addbutton.opacity = 1;
        //}

        //private void AddButton_MouseLeave(object sender, EventArgs e)
        //{
        //	AddButton.Opacity = .5;
        //}
        //private void EditButton_MouseEnter(object sender, EventArgs e)
        //{
        //	EditButton.Opacity = 1;
        //}

        //private void EditButton_MouseLeave(object sender, EventArgs e)
        //{
        //	EditButton.Opacity = .5;
        //}
        //private void DeleteButton_MouseEnter(object sender, EventArgs e)
        //{
        //	DeleteButton.Opacity = 1;
        //}

        //private void DeleteButton_MouseLeave(object sender, EventArgs e)
        //{
        //	DeleteButton.Opacity = .5;
        //}
    }

}
