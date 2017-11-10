using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace CrudListaDeCompra.model
{
    class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Quantidade { get; set; }
        public string Categoria { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1} = {2}", Categoria, Descricao, Quantidade); ;
        }
    }
}
