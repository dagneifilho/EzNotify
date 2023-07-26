using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.SecurityToken.Model;
using Domain.Interfaces;
using Domain.Models;
using MongoDB.Driver;

namespace Infra.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly IMongoDbContext _context;
        private readonly IMongoCollection<EmailCredentials> _credentials;
        public EmailRepository(IMongoDbContext context){
            _context = context;
            _credentials = _context.GetCollection<EmailCredentials>("credentials");
        }
        public async Task<EmailCredentials> GetCredentials()
        {
            
            return await _credentials.Find(c=>c.Type == "email").FirstOrDefaultAsync();
        }


        #region Dispose
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}