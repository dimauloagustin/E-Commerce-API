using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Category.Commands
{
    public class CreateCategoryCommand : IRequest<Domain.Entities.Category>
    {
        [Required]
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Domain.Entities.Category>
    {
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IMapper _mapper;
        public CreateCategoryCommandHandler(ICategoryRepository CategoryRepository, IMapper mapper)
        {
            _CategoryRepository = CategoryRepository;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Category>(request);
            var response = await _CategoryRepository.AddAsync(entity);
            return _mapper.Map<Domain.Entities.Category>(response);
        }
    }
}
