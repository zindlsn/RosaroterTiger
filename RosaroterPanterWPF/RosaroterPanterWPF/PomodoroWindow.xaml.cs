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
using System.Windows.Shapes;

namespace RosaroterTigerWPF
{
	/// <summary>
	/// Interaktionslogik für PomodoroWindow.xaml
	/// </summary>
	public partial class PomodoroWindow : Window
	{
		public PomodoroWindow()
		{
			InitializeComponent();
			//PomodoroViewModel pomodoroViewModel = new PomodoroViewModel();
		}



		private void HomeButton_MouseEnter(object sender, EventArgs e)
		{
			HomeButton.Opacity = 1;
		}

		private void HomeButton_MouseLeave(object sender, EventArgs e)
		{
			HomeButton.Opacity = .5;
		}
		private void StartButton_MouseEnter(object sender, EventArgs e)
		{
			StartButton.Opacity = 1;
		}

		private void StartButton_MouseLeave(object sender, EventArgs e)
		{
			StartButton.Opacity = .5;
		}
			private void ReviewButton_MouseEnter(object sender, EventArgs e)
		{
			ReviewButton.Opacity = 1;
		}

		private void ReviewButton_MouseLeave(object sender, EventArgs e)
		{
			ReviewButton.Opacity = .5;
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
	}
}
