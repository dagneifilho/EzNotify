using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Models
{
    public class EmailCredentials
    {
        [BsonElement("_id")]
        public ObjectId Id {get;set;}
        [BsonElement("type")]
        public string Type {get;set;}
        [BsonElement("user")]
        public string User {get;set;}
        [BsonElement("password")]
        public string Password{get;set;}
        
    }
}