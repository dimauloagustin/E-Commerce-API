using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Product

{
    public class GetProducts : IRequest<List<Domain.Entities.Product>>
    {
        public int PageSize { get; set; } = 20;
        public int PageIndex { get; set; } = 0;
        public List<int> IncludedCategories { get; set; }
    }

    public class GetProductsHandler : IRequestHandler<GetProducts, List<Domain.Entities.Product>>
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _mapper;
        public GetProductsHandler(IProductRepository ProductRepository, IMapper mapper)
        {
            _ProductRepository = ProductRepository;
            _mapper = mapper;
        }

        public Task<List<Domain.Entities.Product>> Handle(GetProducts request, CancellationToken cancellationToken)
        {
            var query = _ProductRepository.All();

            if (request.IncludedCategories != null)
                query = query.Where(q => request.IncludedCategories.Contains(q.CategoryId));

            var response = query.Skip(request.PageIndex * request.PageSize).Take(request.PageSize).Select(r => _mapper.Map<Domain.Entities.Product>(r)).ToList();
            return Task.FromResult(response);
        }
    }
}
