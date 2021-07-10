using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.User.Commands
{
    public class DeleteUserCommand : IRequest<Domain.Entities.User>
    {
        public int Id { get; set; }
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Domain.Entities.User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<Domain.Entities.User> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var response = _userRepository.Find(request.Id);
            _userRepository.Delete(response);
            return Task.FromResult(_mapper.Map<Domain.Entities.User>(response));
        }
    }
}
