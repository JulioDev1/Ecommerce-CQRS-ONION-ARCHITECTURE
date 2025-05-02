using MediatR;

namespace DigitalProducts.Application.Queries.Cart.ProductCart.QueryHandler
{
    public class GetUserCartRequest : IRequest<long>
    {
        public GetUserCartRequest(long userid)
        {
            this.userid = userid;
        }

        public long userid { get; set; }
    }
}
