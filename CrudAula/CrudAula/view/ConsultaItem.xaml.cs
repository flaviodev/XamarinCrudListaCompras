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
    public partial class ConsultaItem : ContentPage
    {
        private Item _item;

        public ConsultaItem(object item)
        {
            InitializeComponent();

            _item = (Item)item;

            PopulaCampos(_item);
        }

        private void PopulaCampos(Item item)
        {
            this.Descricao.Text = item.Descricao;
            this.Quantidade.Text = item.Quantidade;
            this.Categoria.Text = item.Categoria;
        }

        private void EditarClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AlteraItem(_item, false));
        }

        private void ExcluirClicked(object sender, EventArgs e)
        {
            using (var dados = new ItemRepository())
            {
                dados.Delete(_item);
                Navigation.PopAsync();
            }
        }

        protected override void OnAppearing()
        {
            using (var dados = new ItemRepository())
            {
                _item = dados.ObterPeloId(_item.Id);
                PopulaCampos(_item);
            }

        }
    }
}