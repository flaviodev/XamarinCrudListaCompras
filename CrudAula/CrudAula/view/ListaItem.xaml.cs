using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CrudListaDeCompra.model;

namespace CrudListaDeCompra.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaItem : ContentPage
    {
        public ListaItem()
        {
            InitializeComponent();
            this.AtualizarLista();
        }


        private void AtualizarLista()
        {
            using (var dados = new ItemRepository())
            {
                this.Lista.ItemsSource = dados.Listar();
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AlteraItem(new Item(), true));
        }


        protected override void OnAppearing()
        {
            this.AtualizarLista();
        }

        private void Lista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new ConsultaItem(Lista.SelectedItem));
        }
    }
}