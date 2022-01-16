using System;
using Comman.Dapper;
using Comman.Data.Model.DB;

namespace Comman.Data.Repository
{
    public class LoginRepository : DapperRepository<Login, Guid>
    {
        public LoginRepository(IRepositoryContext context) : base(context)
        {

        }
    }
}