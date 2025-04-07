using MediatR;

namespace DigitalProducts.Application.Commands.Product.DeleteProductHandler
{
    public class DeleteProductRequest : IRequest<Unit>
    {
        public long AdminId { get; set; }
        public long ProductId { get; set; }
    }
}
