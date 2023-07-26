using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models.Request;
using Domain.Models;
using Shared.Result;

namespace Application.Interfaces
{
    public interface IEmailService : IDisposable
    {
        Task<Result<bool>> SendEmail(Email email, EmailCredentials credentials);        
    }
}