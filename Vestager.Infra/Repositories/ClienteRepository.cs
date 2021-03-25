using System;
using System.Collections.Generic;
using System.Text;
using Vestager.Domain.Entities;
using Vestager.Domain.Interfaces.Repositories;
using Vestager.Infra.Data;

namespace Vestager.Infra.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository, IDisposable
    {
        public ClienteRepository(Context context) : base(context)
        {

        }
    }
}
