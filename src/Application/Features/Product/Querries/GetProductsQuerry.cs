﻿using Application.Features.Product.Responses;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Product.Querries
{
    public class GetProductsQuerry : IRequest<List<ProductResponse>>
    {
        public int PageSize { get; set; } = 20;
        public int PageIndex { get; set; } = 0;
    }

    public class GetProductCommandHandler : IRequestHandler<GetProductsQuerry, List<ProductResponse>>
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _mapper;
        public GetProductCommandHandler(IProductRepository ProductRepository, IMapper mapper)
        {
            _ProductRepository = ProductRepository;
            _mapper = mapper;
        }

        public Task<List<ProductResponse>> Handle(GetProductsQuerry request, CancellationToken cancellationToken)
        {
            var response = _ProductRepository.All().Skip(request.PageIndex * request.PageSize).Take(request.PageSize).Select(r => _mapper.Map<ProductResponse>(r)).ToList();
            return Task.FromResult(response);
        }
    }
}
