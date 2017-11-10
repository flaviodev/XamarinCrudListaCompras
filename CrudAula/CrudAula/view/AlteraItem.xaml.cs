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
    public partial class AlteraItem : ContentPage
    {
        private Item _item;
        private bool _inlcluir;

        public AlteraItem(object item, bool incluir)
        {
            InitializeComponent();
            _item = (Item)item;
            _inlcluir = incluir;

            PopulaCampos(_item);

            if (_inlcluir)
            {
                this.Title = "Novo Item";
            }
            else
            {
                this.Title = "Alterar Item";
            }

        }

        protected void SalvarClicked(Object sender, EventArgs e)
        {
            _item.Descricao = this.Descricao.Text;
            _item.Quantidade = this.Quantidade.Text;
            _item.Categoria = this.Categoria.Text;

            using (var dados = new ItemRepository())
            {
                if (_inlcluir)
                {
                    dados.Insert(_item);
                }
                else
                {
                    dados.Update(_item);
                }

                Navigation.PopAsync();
            }
        }

        private void PopulaCampos(Item item)
        {
            this.Descricao.Text = item.Descricao;
            this.Quantidade.Text = item.Quantidade;
            this.Categoria.Text = item.Categoria;
        }
    }
}