using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Users
{
    public class UpdateUser : IRequest<User>
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

    public class UpdateUserHandler : IRequestHandler<UpdateUser, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UpdateUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<User> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<User>(request);
            _userRepository.Update(entity);
            var response = _userRepository.Find(entity.Id);
            return Task.FromResult(_mapper.Map<User>(response));
        }
    }
}
