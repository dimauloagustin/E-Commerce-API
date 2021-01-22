using Application.Interfaces.Repositories;
using Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Services.SessionServices
{
    public class SessionService
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public Session GetSession(User user)
        {
            Session session = _sessionRepository.Find(s => s.UserId == user.Id);

            if (session == null)
            {
                session = new Session()
                {
                    UserId = user.Id,
                    ExpireDate = DateTime.Now,
                    Token = Convert.ToBase64String(Guid.NewGuid().ToByteArray())
                };
                _sessionRepository.Add(session);
            }
            else
            {
                session.ExpireDate = DateTime.Now;
                _sessionRepository.Update(session);
            }

            return session;
        }
    }
}