using Application.Entities;
using Application.Interfaces.Repositories;
using Application.Features.Login.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Services.SessionServices;

namespace Application.Features.Login
{
    public class LoginUserService : IRequest<LoginResponse>
    {
        public string Name { get; set; }
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
