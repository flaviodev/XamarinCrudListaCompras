using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace CrudListaDeCompra.model
{
    class ItemRepository : IDisposable
    {
        private SQLite.Net.SQLiteConnection _conexao;

        public ItemRepository()
        {
            var config = DependencyService.Get<IConfig>();
            _conexao = new SQLite.Net.SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DiretorioDB, "banco_item.db3"));
            _conexao.CreateTable<Item>();
        }

        public void Insert (Item item)
        {
            _conexao.Insert(item);
        }

        public void Update(Item item)
        {
            _conexao.Update(item);
        }

        public void Delete(Item item)
        {
            _conexao.Delete(item);
        }

        public List<Item> Listar()
        {
            return _conexao.Table<Item>().OrderBy(i => i.Categoria).OrderBy(i => i.Descricao).ToList();
        }

        public Item ObterPeloId(int id)
        {
            return _conexao.Table<Item>().FirstOrDefault(i => i.Id == id);

        }

        public void Dispose()
        {
            _conexao.Dispose();
        }
    }

}
