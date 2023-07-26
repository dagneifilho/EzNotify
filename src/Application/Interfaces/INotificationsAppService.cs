using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models.Request;
using Shared.Result;

namespace Application.Interfaces
{
    public interface INotificationsAppService : IDisposable
    {
        Task<Result<bool>> PostEmail(Email email);
    }
}