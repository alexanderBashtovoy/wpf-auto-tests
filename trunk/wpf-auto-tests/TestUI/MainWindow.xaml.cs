using System;
using System.Windows;

namespace TestUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void ButtonClick(object sender, RoutedEventArgs e)
		{
			SomeTexBox.Text = "Habrahabr";
		}

		private void ButtonClick2(object sender, RoutedEventArgs e)
		{
			SomeTexBox.Text = DateTime.Now.ToString();
		}
	}
}
