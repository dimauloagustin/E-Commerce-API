using Application.Services.Login.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Login
{
    public class LoginUserService : IRequest<LoginResponse>
    {
        public string User { get; set; }
        public string Pass { get; set; }
    }

    public class LoginUserServiceHandler : IRequestHandler<LoginUserService, LoginResponse>
    {
        public LoginUserServiceHandler() { }

        public Task<LoginResponse> Handle(LoginUserService request, CancellationToken cancellationToken)
        {
            string token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            return Task.FromResult(new LoginResponse() { Token = token });
        }
    }
}
