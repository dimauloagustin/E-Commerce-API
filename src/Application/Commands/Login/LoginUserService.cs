using Application.Interfaces.Repositories;
using Application.Features.Login.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Services.SessionServices;
using System.ComponentModel.DataAnnotations;

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
        private readonly SessionService _sessionService;
        public LoginUserServiceHandler(IUserRepository userRepository, SessionService sessionService)
        {
            _userRepository = userRepository;
            _sessionService = sessionService;
        }

        public Task<LoginResponse> Handle(LoginUserService request, CancellationToken cancellationToken)
        {
            Domain.Entities.User user = _userRepository.Find(e => e.Name == request.Name && e.Pass == request.Pass);

            if (user == null)
                return Task.FromResult(new LoginResponse() { LogResult = "user and pass doesnt match" });

            return Task.FromResult(new LoginResponse() { LogResult = "Valid", Token = _sessionService.GetSession(user).Token });
        }
    }
}
