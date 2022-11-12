using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejer2_2Michelle.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Listado : ContentPage
    {
        public Listado()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            list.ItemsSource = await new Service.Service().GetSignatures();
        }

        private void list_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}