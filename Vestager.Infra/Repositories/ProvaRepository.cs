using System;
using System.Collections.Generic;
using System.Text;
using Vestager.Domain.Entities;
using Vestager.Domain.Interfaces.Repositories;
using Vestager.Infra.Data;

namespace Vestager.Infra.Repositories
{
    public class ProvaRepository : BaseRepository<Prova>, IProvaRepository, IDisposable
    {
        public ProvaRepository(Context context) : base(context)
        {

        }
    }
}
