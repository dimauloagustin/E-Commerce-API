using Application.Features.Product.Responses;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Product

{
    public class GetProducts : IRequest<List<ProductResponse>>
    {
        public int PageSize { get; set; } = 20;
        public int PageIndex { get; set; } = 0;
        public List<int> IncludedCategories { get; set; }
    }

    public class GetProductsHandler : IRequestHandler<GetProducts, List<ProductResponse>>
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _mapper;
        public GetProductsHandler(IProductRepository ProductRepository, IMapper mapper)
        {
            _ProductRepository = ProductRepository;
            _mapper = mapper;
        }

        public Task<List<ProductResponse>> Handle(GetProducts request, CancellationToken cancellationToken)
        {
            var query = _ProductRepository.All();

            if (request.IncludedCategories != null)
                query = query.Where(q => request.IncludedCategories.Contains(q.CategoryId));

            var response = query.Skip(request.PageIndex * request.PageSize).Take(request.PageSize).Select(r => _mapper.Map<ProductResponse>(r)).ToList();
            return Task.FromResult(response);
        }
    }
}
