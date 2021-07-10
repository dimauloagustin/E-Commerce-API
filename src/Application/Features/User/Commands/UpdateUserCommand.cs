using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.User.Commands
{
    public class UpdateUserCommand : IRequest<Domain.Entities.User>
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Pass { get; set; }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Domain.Entities.User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<Domain.Entities.User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.User>(request);
            _userRepository.Update(entity);
            var response = _userRepository.Find(entity.Id);
            return Task.FromResult(_mapper.Map<Domain.Entities.User>(response));
        }
    }
}
