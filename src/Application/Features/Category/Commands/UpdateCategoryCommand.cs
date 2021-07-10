using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Category.Commands
{
    public class UpdateCategoryCommand : IRequest<Domain.Entities.Category>
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Domain.Entities.Category>
    {
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IMapper _mapper;
        public UpdateCategoryCommandHandler(ICategoryRepository CategoryRepository, IMapper mapper)
        {
            _CategoryRepository = CategoryRepository;
            _mapper = mapper;
        }

        public Task<Domain.Entities.Category> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Category>(request);
            _CategoryRepository.Update(entity);
            var response = _CategoryRepository.Find(entity.Id);
            return Task.FromResult(_mapper.Map<Domain.Entities.Category>(response));
        }
    }
}
