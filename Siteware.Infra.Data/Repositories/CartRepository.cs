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
    public class CartRepository : BaseRepository, ICartRepository
    {
        public CartRepository(IDbConnection connection) : base(connection) { }

        #region QUERIES

        private readonly string SELECT_CART_BY_ID = @"           
            SELECT CAT.[Id],
                PRC.[Id],
                PRC.[CartId],
                PRC.[ProductId],
                PRC.[Quantity],
                PRO.[Id],
                PRO.[Name],
                PRO.[Price],
                PRO.[CategoryId],
                PRO.[SaleId],
                PRO.[ImageSource],
                SAL.[Id],
                SAL.[Name],
                SAL.[Type],
                SAL.[Value],
                SAL.[Quantity]
            FROM [Cart] CAT
            LEFT JOIN [ProductCart] PRC ON CAT.Id = PRC.CartId
            LEFT JOIN [Product] PRO ON PRC.ProductId = PRO.Id
            LEFT JOIN [Sale] SAL ON SAL.Id = PRO.SaleId
            WHERE CAT.[Id] = @id
        ";

        #endregion

        public Cart Get(int id)
        {
            var cartDic = new Dictionary<int, Cart>();

            Connection.Query<Cart, ProductCart, Product, Sale, Cart>(
               sql: SELECT_CART_BY_ID, 
               splitOn: "Id, Id, Id, Id", 
               map: (cart, productCart, product, sale) => {

                    if (!cartDic.TryGetValue(cart.Id, out Cart cartAlias))
                    {
                        cartAlias = cart;
                        cartAlias.ProductsCart = new List<ProductCart>();
                        cartDic.Add(cart.Id, cartAlias);
                    }

                   if (product != null)
                   {
                       product.Sale = sale;
                       productCart.Product = product;
                       cartAlias.ProductsCart.Add(productCart);
                   }

                    return cartAlias;
               },
               param: new { id }
            );
            return cartDic.Values.FirstOrDefault();
        }
    }
}
