using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Users
{
    public class DeleteUser : IRequest<User>
    {
        public int Id { get; set; }
    }

    public class DeleteUserHandler : IRequestHandler<DeleteUser, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public DeleteUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<User> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            var response = _userRepository.Find(request.Id);
            _userRepository.Delete(response);
            return Task.FromResult(_mapper.Map<User>(response));
        }
    }
}
