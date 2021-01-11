using Application.Features.User.Responses;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.User.Commands
{
    public class CreateUserCommand : IRequest<Domain.Entities.User>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Domain.Entities.User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var sample = _mapper.Map<Domain.Entities.User>(request);
            var response = await _userRepository.AddAsync(sample);
            return _mapper.Map<UserResponse>(response);
        }
    }
}
