using Basket.API.Data;
using Basket.API.Models;
using BuildingBlocks.CQRS;

namespace Basket.API.Basket.CheckoutBasket
{
    public record CheckoutBasketCommand(ShoppingCart shopingcart) : ICommand<CheckoutBasketResult>;

    public record CheckoutBasketResult(bool IsSuccess);


    public class CheckoutBasketCommandHandler(IBasketRepository repository) : ICommandHandler<CheckoutBasketCommand, CheckoutBasketResult>
    {
        public Task<CheckoutBasketResult> Handle(CheckoutBasketCommand command, CancellationToken cancellationToken)
        {
            return Task.FromResult(new CheckoutBasketResult(true));
        }
    }
}
