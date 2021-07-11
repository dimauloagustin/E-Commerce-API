using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Categories
{
    public class UpdateCategory : IRequest<Category>
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }

    public class UpdateCategoryHandler : IRequestHandler<UpdateCategory, Category>
    {
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IMapper _mapper;
        public UpdateCategoryHandler(ICategoryRepository CategoryRepository, IMapper mapper)
        {
            _CategoryRepository = CategoryRepository;
            _mapper = mapper;
        }

        public Task<Category> Handle(UpdateCategory request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Category>(request);
            _CategoryRepository.Update(entity);
            var response = _CategoryRepository.Find(entity.Id);
            return Task.FromResult(_mapper.Map<Category>(response));
        }
    }
}