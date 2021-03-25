using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vestager.Domain.Interfaces.Repositories;
using Vestager.Domain.Interfaces.UnitOfWork;
using Vestager.Infra.Data;
using Vestager.Infra.Repositories;

namespace Vestager.Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        public UnitOfWork()
        {
            _context = new Context();
            Ajustes = new AjusteRepository(_context);
            Clientes = new ClienteRepository(_context);
            Locacoes = new LocacaoRepository(_context);
            Provas = new ProvaRepository(_context);
            Vestidos = new VestidoRepository(_context);
        }
        public UnitOfWork(Context context)
        {
            _context = context;
            Ajustes = new AjusteRepository(_context);
            Clientes = new ClienteRepository(_context);
            Locacoes = new LocacaoRepository(_context);
            Provas = new ProvaRepository(_context);
            Vestidos = new VestidoRepository(_context);
        }

        public IAjusteRepository Ajustes { get; set; }
        public IClienteRepository Clientes { get; set; }
        public ILocacaoRepository Locacoes { get; set; }
        public IProvaRepository Provas { get; set; }
        public IVestidoRepository Vestidos { get; set; }
        public void Save()
        {
            _context.SaveChanges();
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
