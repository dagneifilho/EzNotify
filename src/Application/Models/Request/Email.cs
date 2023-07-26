using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static Shared.Validation.ValidationAttributes;

namespace Application.Models.Request
{
    public class Email
    {
        [JsonProperty("to")]
        [EmailAddress]
        [Required]
        public string To {get;set;}
        [JsonProperty("subject")]
        [Required]
        public string Subject {get;set;}
        [JsonProperty("content")]
        [Required]
        public string Content {get;set;}
        [JsonProperty("cc")]
        [ListEmailAddress(Required = false, ErrorMessage = "At least one of the informed email addresses is not valid.")]
        public string? Cc {get;set;}
        [JsonProperty("htmlContent")]
        public bool HtmlContent {get;set;} = false;
    }
}