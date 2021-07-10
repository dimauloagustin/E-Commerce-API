using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.User.Commands
{
    public class GetUserCommand : IRequest<Domain.Entities.User>
    {
        public int Id { get; set; }
    }

    public class GetUserCommandHandler : IRequestHandler<GetUserCommand, Domain.Entities.User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<Domain.Entities.User> Handle(GetUserCommand request, CancellationToken cancellationToken)
        {
            var response = _userRepository.Find(request.Id);
            return Task.FromResult(_mapper.Map<Domain.Entities.User>(response));
        }
    }
}
