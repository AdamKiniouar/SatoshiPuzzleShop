
using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Data;
using ShopOnline.Api.Entities;
using ShopOnline.Api.Repositories.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ShopOnlineDbContext shopOnlineDbContext;

        public ShoppingCartRepository(ShopOnlineDbContext shopOnlineDbContext)
        {
            this.shopOnlineDbContext = shopOnlineDbContext;
        }

        private async Task<bool> CartItemExists(int cartId, int productId)
        {
            return await shopOnlineDbContext.CartItems.AnyAsync(c => c.CartId == cartId &&
                                                                     c.ProductId == productId);
        }
        public async Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto)
        {
            if (await CartItemExists(cartItemToAddDto.CartId, cartItemToAddDto.ProductId) == false)
            {
                var item = await shopOnlineDbContext.Products
                    .Where(p => p.Id == cartItemToAddDto.ProductId)
                    .Select(p => new CartItem
                    {
                        CartId = cartItemToAddDto.CartId,
                        ProductId = p.Id,
                        Qty = cartItemToAddDto.Qty
                    })
                    .SingleOrDefaultAsync();

                if (item != null)
                {
                    var result = await shopOnlineDbContext.CartItems.AddAsync(item);
                    await shopOnlineDbContext.SaveChangesAsync();
                    return result.Entity;
                }
            }

            return null;

        }

        public async Task<CartItem> DeleteItem(int id)
        {
            var item = await this.shopOnlineDbContext.CartItems.FindAsync(id);

            if (item != null)
            {
                this.shopOnlineDbContext.CartItems.Remove(item);
                await this.shopOnlineDbContext.SaveChangesAsync();
            }
            
            return item;

        }

        public async Task<CartItem> GetItem(int id)
        {
            var result = await this.shopOnlineDbContext.CartItems
                .Where(ci => ci.Id == id)
                .Select(ci => new CartItem
                {
                    Id = ci.Id,
                    ProductId = ci.ProductId,
                    Qty = ci.Qty,
                    CartId = ci.CartId
                })
                .SingleOrDefaultAsync();

            if (result == null)
            {
                // handle the case where no matching CartItem was found
                // e.g. throw an exception, return a default value, etc.
            }

            return result;
        }

        public async Task<IEnumerable<CartItem>> GetItems(int userId)
        {
            return await (from cart in this.shopOnlineDbContext.Carts
                          join cartItem in this.shopOnlineDbContext.CartItems
                          on cart.Id equals cartItem.CartId
                          where cart.UserId == userId
                          select new CartItem
                          {
                              Id = cartItem.Id,
                              ProductId = cartItem.ProductId,
                              Qty = cartItem.Qty,
                              CartId = cartItem.CartId
                          }).ToListAsync();
        }

        public async Task<CartItem> UpdateQty(int id, CartItemQtyUpdateDto cartItemQtyUpdateDto)
        {
            var item = await this.shopOnlineDbContext.CartItems.FindAsync(id);

            if (item != null)
            {
                item.Qty = cartItemQtyUpdateDto.Qty;
                await this.shopOnlineDbContext.SaveChangesAsync();
                return item;
            }

            return null;
        }
    }
}
