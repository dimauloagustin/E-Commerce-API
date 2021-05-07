﻿using Application.Features.Product.Responses;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Product
{
    public class DeleteProduct : BaseProduct, IRequest<ProductResponse>
    {
        public int Id { get; set; }
    }

    public class DeleteProductHandler : IRequestHandler<DeleteProduct, ProductResponse>
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _mapper;
        public DeleteProductHandler(IProductRepository ProductRepository, IMapper mapper)
        {
            _ProductRepository = ProductRepository;
            _mapper = mapper;
        }

        public Task<ProductResponse> Handle(DeleteProduct request, CancellationToken cancellationToken)
        {
            var response = _ProductRepository.Find(request.Id);
            _ProductRepository.Delete(response);
            return Task.FromResult(_mapper.Map<ProductResponse>(response));
        }
    }
}
