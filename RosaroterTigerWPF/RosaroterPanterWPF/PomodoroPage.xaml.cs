﻿using System;
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
			} else {
				PlayActive = false;
				StartButton.Background = new ImageBrush(new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/Play.png")));
			}
		}
		private void EndButton_MouseUp(object sender, MouseButtonEventArgs e)
		{

			new PopUp().Show();

		}
	}
}
