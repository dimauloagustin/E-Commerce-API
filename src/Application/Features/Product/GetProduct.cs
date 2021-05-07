using Application.Features.Product.Responses;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Product
{
    public class GetProduct : IRequest<ProductResponse>
    {
        public int Id { get; set; }
    }

    public class GetProductHandler : IRequestHandler<GetProduct, ProductResponse>
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _mapper;
        public GetProductHandler(IProductRepository ProductRepository, IMapper mapper)
        {
            _ProductRepository = ProductRepository;
            _mapper = mapper;
        }

        public Task<ProductResponse> Handle(GetProduct request, CancellationToken cancellationToken)
        {
            var response = _ProductRepository.Find(request.Id);
            return Task.FromResult(_mapper.Map<ProductResponse>(response));
        }
    }
}
