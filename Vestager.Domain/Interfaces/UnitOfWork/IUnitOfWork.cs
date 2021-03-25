using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vestager.Domain.Interfaces.Repositories;

namespace Vestager.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAjusteRepository Ajustes { get; }
        IClienteRepository Clientes { get; }
        ILocacaoRepository Locacoes { get; }
        IProvaRepository Provas {get;}
        IVestidoRepository Vestidos { get; }
        void Save();
        Task<int> SaveAsync();
    }
}
