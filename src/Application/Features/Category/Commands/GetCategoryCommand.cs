using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Category.Commands
{
    public class GetCategoryCommand : IRequest<Domain.Entities.Category>
    {
        public int Id { get; set; }
    }

    public class GetCategoryCommandHandler : IRequestHandler<GetCategoryCommand, Domain.Entities.Category>
    {
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IMapper _mapper;
        public GetCategoryCommandHandler(ICategoryRepository CategoryRepository, IMapper mapper)
        {
            _CategoryRepository = CategoryRepository;
            _mapper = mapper;
        }

        public Task<Domain.Entities.Category> Handle(GetCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = _CategoryRepository.Find(request.Id);
            return Task.FromResult(_mapper.Map<Domain.Entities.Category>(response));
        }
    }
}
