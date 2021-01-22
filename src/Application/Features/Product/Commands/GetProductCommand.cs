using Application.Features.Product.Responses;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Product.Commands
{
    public class GetProductCommand : IRequest<ProductResponse>
    {
        public int Id { get; set; }
    }

    public class GetProductCommandHandler : IRequestHandler<GetProductCommand, ProductResponse>
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _mapper;
        public GetProductCommandHandler(IProductRepository ProductRepository, IMapper mapper)
        {
            _ProductRepository = ProductRepository;
            _mapper = mapper;
        }

        public Task<ProductResponse> Handle(GetProductCommand request, CancellationToken cancellationToken)
        {
            var response = _ProductRepository.Find(request.Id);
            return Task.FromResult(_mapper.Map<ProductResponse>(response));
        }
    }
}
