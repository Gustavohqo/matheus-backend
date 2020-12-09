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
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(IDbConnection connection) : base(connection) { }


        #region QUERIES

        private readonly string SELECT_CATEGORIES = @"
            SELECT [Id], [Name]
            FROM Category
        ";

        #endregion

        public IEnumerable<Category> GetAll()
        {
            return Connection.Query<Category>(SELECT_CATEGORIES);
        }
    }
}
