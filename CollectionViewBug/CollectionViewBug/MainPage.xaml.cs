using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace CollectionViewBug
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(true)]
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			var existingItems = new List<string>
			{
				$"Current Item 1 {DateTime.Now}",
				$"Current Item 2 {DateTime.Now}",
				$"Current Item 3 {DateTime.Now}",
				$"Current Item 4 {DateTime.Now}",
			};

			CollectionSource = new ObservableCollection<string>(existingItems);
			InitializeComponent();
			BindingContext = this;
		}

		public ObservableCollection<string> CollectionSource { get; set; }

		private void Button_OnClicked(object sender, EventArgs e)
		{
			var newItems = new List<string>
			{
				$"New Item 1 {DateTime.Now}",
				$"New Item 2 {DateTime.Now}",
				$"New Item 3 {DateTime.Now}",
				$"New Item 4 {DateTime.Now}",
			};

			Device.BeginInvokeOnMainThread(() =>
			{
				CollectionSource.Clear();

				foreach (var newValue in newItems)
				{
					CollectionSource.Add(newValue);
				}
			});


		}
	}
}
