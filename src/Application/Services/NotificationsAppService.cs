using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Models.Request;
using Domain.Interfaces;
using Domain.Models;
using Shared.Result;

namespace Application.Services
{
    public class NotificationsAppService : INotificationsAppService
    {
        private readonly IEmailService _emailService;
        private readonly IEmailRepository _emailRepository;

        public NotificationsAppService(IEmailService emailService, IEmailRepository emailRepository)
        {
            _emailService = emailService;
            _emailRepository = emailRepository;
        }
        public async Task<Result<bool>> PostEmail(Email email)
        {
            EmailCredentials credentials = await _emailRepository.GetCredentials();
            return await _emailService.SendEmail(email, credentials);
        }


        private void Dispose(bool disposing)
        {
            _emailRepository.Dispose();
            _emailRepository.Dispose();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}