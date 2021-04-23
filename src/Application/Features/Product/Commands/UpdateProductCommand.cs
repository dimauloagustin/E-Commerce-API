using Application.Features.Product.Responses;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Product.Commands
{
    public class UpdateProductCommand : BaseProductCommand, IRequest<ProductResponse>
    {
        [Required]
        public int Id { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductResponse>
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _mapper;
        public UpdateProductCommandHandler(IProductRepository ProductRepository, IMapper mapper)
        {
            _ProductRepository = ProductRepository;
            _mapper = mapper;
        }

        public Task<ProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Product>(request);
            _ProductRepository.Update(entity);
            var response = _ProductRepository.Find(entity.Id);
            return Task.FromResult(_mapper.Map<ProductResponse>(response));
        }
    }
}
