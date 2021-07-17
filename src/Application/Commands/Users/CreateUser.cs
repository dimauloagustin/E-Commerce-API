using Application.Features.User.Responses;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Users
{
    public class CreateUser : IRequest<User>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Pass { get; set; }
    }

    public class CreateUserHandler : IRequestHandler<CreateUser, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IHashService _hashService;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IHashService hashService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _hashService = hashService;
        }

        public async Task<User> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            request.Pass = _hashService.Hash(request.Pass);
            var entity = _mapper.Map<Domain.Entities.User>(request);
            var response = await _userRepository.AddAsync(entity);
            return _mapper.Map<User>(response);
        }
    }
}
