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
    public class ProductCartRepository : BaseRepository, IProductCartRepository
    {
        public ProductCartRepository(IDbConnection connection) : base(connection) { }

        #region QUERIES

        private readonly string INSERT_PRODUCT_CART = @"
            INSERT INTO [ProductCart]
                ([ProductId], [CartId], [Quantity])
            VALUES
                (@productId, @cartId, @quantity);
            SELECT CAST(SCOPE_IDENTITY() as int);
        ";

        private readonly string UPDATE_PRODUCT_CART = @"
            UPDATE [ProductCart]
                SET [Quantity] = @quantity
            WHERE [Id] = @id
        ";

        private readonly string DELETE_PRODUCT_CART = @"
            DELETE FROM [ProductCart]
            WHERE [Id] = @id 
        ";

        #endregion

        public ProductCart Create(ProductCart productCart)
        {
            var createdId = Connection.Query<int>(INSERT_PRODUCT_CART, new { 
               quantity = productCart.Quantity,
               productId = productCart.ProductId,
               cartId = productCart.CartId,
            }).Single();

            productCart.Id = createdId;
            return productCart;
        }

        public void Update(int id, ProductCart productCart)
        {
            Connection.Execute(UPDATE_PRODUCT_CART, new
            {
                id,
                quantity = productCart.Quantity,
            });
        }

        public void Delete(int id)
        {
            Connection.Execute(DELETE_PRODUCT_CART, new { id });
        }
    }
}
