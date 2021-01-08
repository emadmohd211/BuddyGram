using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Buddiegram.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeetupTab : ContentPage
    {
        public MeetupTab()
        {
            InitializeComponent();
        }

        async void RefButtonClicked(object sender, EventArgs e)
        {
            // Navigation.PopModalAsync(true);
            await Navigation.PushAsync(new ContactList());
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem;

          //  if (item.Equals("PROFILE"))
            {
                await Navigation.PushAsync(new EventMainPage());
            }

            // Your code here
        }
    }
}