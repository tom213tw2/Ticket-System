using System;
using Comman.Dapper;
using Comman.Data.Model.DB;

namespace Comman.Data.Repository
{
    public class TicketRepository:DapperRepository<Ticket, Guid>
    {
        public TicketRepository(IRepositoryContext context) : base(context)
        {

        }
    }
}