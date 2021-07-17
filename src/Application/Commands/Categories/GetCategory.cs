using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Categories
{
    public class GetCategory : IRequest<Category>
    {
        public int Id { get; set; }
    }

    public class GetCategoryHandler : IRequestHandler<GetCategory, Category>
    {
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IMapper _mapper;
        public GetCategoryHandler(ICategoryRepository CategoryRepository, IMapper mapper)
        {
            _CategoryRepository = CategoryRepository;
            _mapper = mapper;
        }

        public Task<Category> Handle(GetCategory request, CancellationToken cancellationToken)
        {
            var response = _CategoryRepository.Find(request.Id);
            return Task.FromResult(_mapper.Map<Category>(response));
        }
    }
}
