using Application.Interfaces.Repositories;
using Application.Features.Login.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Services.SessionServices;
using System.ComponentModel.DataAnnotations;
using Application.Interfaces.Services;

namespace Application.Features.Login
{
    public class LoginUserService : IRequest<LoginResponse>
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Pass { get; set; }
    }

    public class LoginUserServiceHandler : IRequestHandler<LoginUserService, LoginResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHashService _hashService;
        private readonly SessionService _sessionService;

        public LoginUserServiceHandler(IUserRepository userRepository, SessionService sessionService, IHashService hashService)
        {
            _userRepository = userRepository;
            _sessionService = sessionService;
            _hashService = hashService;
        }

        public Task<LoginResponse> Handle(LoginUserService request, CancellationToken cancellationToken)
        {
            Domain.Entities.User user = _userRepository.Find(e => e.Name == request.Name);

            if (user == null)
                return Task.FromResult(new LoginResponse() { LogResult = "user not found" });

            if (!_hashService.Verify(request.Pass,user.Pass))
                return Task.FromResult(new LoginResponse() { LogResult = "user and pass doesnt match" });

            return Task.FromResult(new LoginResponse() { LogResult = "Valid", Token = _sessionService.GetSession(user).Token });
        }
    }
}
