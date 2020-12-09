using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Siteware.Domain.Entities;
using Siteware.Domain.Interfaces.Repositories;
using Siteware.Infra.Data.Repositories.Base;

namespace Siteware.Infra.Data.Repositories
{
    public class SaleRepository : BaseRepository, ISaleRepository
    {
        public SaleRepository(IDbConnection connection) : base(connection) { }


        #region QUERIES

        private readonly string SELECT_SALES = @"
            SELECT [Id],
                [Name],
                [Type],
                [Value],
                [Quantity]
            FROM [Sale]
        ";

        #endregion

        public IEnumerable<Sale> GetAll()
        {
            return Connection.Query<Sale>(SELECT_SALES);
        }
    }
}
