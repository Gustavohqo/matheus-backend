using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Siteware.Domain.Entities;
using Siteware.Domain.Interfaces.Repositories;
using Siteware.Infra.Data.Repositories.Base;

namespace Siteware.Infra.Data.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(IDbConnection connection) : base(connection) { }

        #region QUERIES

        private readonly string SELECT_PRODUCTS = @"
            SELECT PRO.[Id],
                PRO.[Name],
                PRO.[Price],
                PRO.[CategoryId],
                PRO.[SaleId],
                PRO.[ImageSource],
                CTG.[Id],
                CTG.[Name]
            FROM [Product] PRO
            JOIN [Category] CTG ON CTG.Id = PRO.CategoryId
        ";
        
        private readonly string WHERE_BY_NAME = @" PRO.[Name] LIKE @searchTerm";

        private readonly string WHERE_BY_CATEGORY_ID = @" CTG.Id = @categoryId";

        private readonly string PAGINATE = @" OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY";

        private readonly string SELECT_PRODUCT_BY_ID = @"
            SELECT PRO.[Id],
                PRO.[Name],
                PRO.[Price],
                PRO.[CategoryId],
                PRO.[SaleId],
                PRO.[ImageSource],
                CTG.[Id],
                CTG.[Name],
                SAL.[Id],
                SAL.[Name]
            FROM [Product] PRO
            JOIN [Category] CTG ON CTG.Id = PRO.CategoryId
            LEFT JOIN [Sale] SAL ON SAL.Id = PRO.SaleId
            WHERE PRO.[Id] = @id;
        ";

        private readonly string INSERT_PRODUCT = @"
            INSERT INTO [Product]
                ([Name], [Price], [CategoryId], [SaleId], [ImageSource])
            VALUES
                (@name, @price, @categoryId, @saleId, @imageSource);
            SELECT CAST(SCOPE_IDENTITY() as int);
        ";

        private readonly string UPDATE_PRODUCT = @"
            UPDATE [dbo].[Product]
                SET [Name] = @name,
                    [Price] = @price,
                    [CategoryId] = @categoryId,
                    [SaleId] = @saleId,
                    [ImageSource] = @imageSource
            WHERE [Id] = @id;
        ";

        private readonly string DELETE_PRODUCT = @"
            DELETE FROM Product WHERE [Id] = @id;
        ";

        #endregion

        public IEnumerable<Product> GetAll(string searchTerm, string orderBy, string sortBy, int? offset, int? limit)
        {
            var whereSyntaxBuilder = new StringBuilder();
            var parameters = new DynamicParameters();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
               parameters.Add("@searchTerm", $"%{searchTerm}%");
               whereSyntaxBuilder.Append(WHERE_BY_NAME);
            }

            if (offset.HasValue && limit.HasValue)
            {
               whereSyntaxBuilder.Append(string.Format(PAGINATE, offset, limit));
            }

            var query = string.Format(SELECT_PRODUCTS, whereSyntaxBuilder.ToString());

            return Connection.Query<Product, Category, Product>(
               sql: query, 
               splitOn: "Id, Id", 
               map: (product, category) => {
                    product.Category = category;
                    return product;    
               },
               param: parameters
            );
        }

        public Product Get(int id)
        {
            return Connection.Query<Product, Category, Sale, Product>(
               sql: SELECT_PRODUCT_BY_ID, 
               splitOn: "Id, Id, Id, Id, Id", 
               map: (product, category, sale) => {
                    product.Category = category;
                    product.Sale = sale;
                    return product;
               },
               param: new { id }
            ).FirstOrDefault();
        }

        public Product Create(Product product)
        {
            var createdId = Connection.Query<int>(INSERT_PRODUCT, new { 
               name = product.Name,
               price = product.Price,
               saleId = product.SaleId,
               categoryId = product.CategoryId,
               imageSource = product.ImageSource,
            }).Single();

            product.Id = createdId;
            return product;
        }

        public void Update(int id, Product product)
        {
            Connection.Execute(UPDATE_PRODUCT, new
            {
               name = product.Name,
               price = product.Price,
               saleId = product.SaleId,
               categoryId = product.CategoryId,
               imageSource = product.ImageSource,
               id
            });
        }

        public void Delete(int id)
        {
            Connection.Execute(DELETE_PRODUCT, new { id });
        }
    }
}
