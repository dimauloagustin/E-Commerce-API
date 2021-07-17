using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Categories
{
    public class CreateCategory : IRequest<Category>
    {
        [Required]
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }

    public class CreateCategoryHandler : IRequestHandler<CreateCategory, Category>
    {
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IMapper _mapper;
        public CreateCategoryHandler(ICategoryRepository CategoryRepository, IMapper mapper)
        {
            _CategoryRepository = CategoryRepository;
            _mapper = mapper;
        }

        public async Task<Category> Handle(CreateCategory request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Category>(request);
            var response = await _CategoryRepository.AddAsync(entity);
            return _mapper.Map<Category>(response);
        }
    }
}
