using Application.Features.User.Responses;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.User.Commands
{
    public class CreateUserCommand : IRequest<UserResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.User>(request);
            var response = await _userRepository.AddAsync(entity);
            return _mapper.Map<UserResponse>(response);
        }
    }
}
