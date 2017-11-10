
using SQLite.Net.Interop;

namespace CrudListaDeCompra.model
{
    public interface IConfig
    {
        string DiretorioDB { get; }

        ISQLitePlatform Plataforma { get; }
    }
}
