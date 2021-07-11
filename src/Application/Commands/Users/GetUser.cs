using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Users
{
    public class GetUser : IRequest<User>
    {
        public int Id { get; set; }
    }

    public class GetUserHandler : IRequestHandler<GetUser, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<User> Handle(GetUser request, CancellationToken cancellationToken)
        {
            var response = _userRepository.Find(request.Id);
            return Task.FromResult(_mapper.Map<User>(response));
        }
    }
}
