namespace ChrisPieShop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ChrisPieShopDbContext _chrisPieShopDbContext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(ChrisPieShopDbContext chrisPieShopDbContext, IShoppingCart shoppingCart)
        {
            _chrisPieShopDbContext = chrisPieShopDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            //adding the order with its details
            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Pie.PieId,
                    Price = shoppingCartItem.Pie.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _chrisPieShopDbContext.Orders.Add(order);
            _chrisPieShopDbContext.SaveChanges();
        }
    }
}
