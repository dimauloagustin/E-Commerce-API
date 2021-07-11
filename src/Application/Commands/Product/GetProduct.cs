using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Product
{
    public class GetProduct : IRequest<Domain.Entities.Product>
    {
        public int Id { get; set; }
    }

    public class GetProductHandler : IRequestHandler<GetProduct, Domain.Entities.Product>
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _mapper;
        public GetProductHandler(IProductRepository ProductRepository, IMapper mapper)
        {
            _ProductRepository = ProductRepository;
            _mapper = mapper;
        }

        public Task<Domain.Entities.Product> Handle(GetProduct request, CancellationToken cancellationToken)
        {
            var response = _ProductRepository.Find(request.Id);
            return Task.FromResult(_mapper.Map<Domain.Entities.Product>(response));
        }
    }
}
