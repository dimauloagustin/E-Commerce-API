using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Category.Commands
{
    public class DeleteCategoryCommand : IRequest<Domain.Entities.Category>
    {
        public int Id { get; set; }
    }

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Domain.Entities.Category>
    {
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IMapper _mapper;
        public DeleteCategoryCommandHandler(ICategoryRepository CategoryRepository, IMapper mapper)
        {
            _CategoryRepository = CategoryRepository;
            _mapper = mapper;
        }

        public Task<Domain.Entities.Category> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = _CategoryRepository.Find(request.Id);
            _CategoryRepository.Delete(response);
            return Task.FromResult(_mapper.Map<Domain.Entities.Category>(response));
        }
    }
}
