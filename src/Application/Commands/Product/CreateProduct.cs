using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Product
{
    public class CreateProduct : BaseProductCommand, IRequest<Domain.Entities.Product> { }

    public class CreateProductHandler : IRequestHandler<CreateProduct, Domain.Entities.Product>
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _mapper;
        public CreateProductHandler(IProductRepository ProductRepository, IMapper mapper)
        {
            _ProductRepository = ProductRepository;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.Product> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Product>(request);
            var response = await _ProductRepository.AddAsync(entity);
            return _mapper.Map<Domain.Entities.Product>(response);
        }
    }
}
