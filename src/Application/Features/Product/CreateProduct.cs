using Application.Features.Product.Responses;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Product
{
    public class CreateProduct : BaseProduct, IRequest<ProductResponse> { }

    public class CreateProductHandler : IRequestHandler<CreateProduct, ProductResponse>
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _mapper;
        public CreateProductHandler(IProductRepository ProductRepository, IMapper mapper)
        {
            _ProductRepository = ProductRepository;
            _mapper = mapper;
        }

        public async Task<ProductResponse> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Product>(request);
            var response = await _ProductRepository.AddAsync(entity);
            return _mapper.Map<ProductResponse>(response);
        }
    }
}
