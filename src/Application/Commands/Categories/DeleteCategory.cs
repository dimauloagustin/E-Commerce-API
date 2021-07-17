using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Categories
{
    public class DeleteCategory : IRequest<Category>
    {
        public int Id { get; set; }
    }

    public class DeleteCategoryHandler : IRequestHandler<DeleteCategory, Category>
    {
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IMapper _mapper;
        public DeleteCategoryHandler(ICategoryRepository CategoryRepository, IMapper mapper)
        {
            _CategoryRepository = CategoryRepository;
            _mapper = mapper;
        }

        public Task<Category> Handle(DeleteCategory request, CancellationToken cancellationToken)
        {
            var response = _CategoryRepository.Find(request.Id);
            _CategoryRepository.Delete(response);
            return Task.FromResult(_mapper.Map<Category>(response));
        }
    }
}
