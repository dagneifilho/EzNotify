using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Enum;
using Application.Interfaces;
using Application.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Shared.Result;

namespace WebApi.Controllers
{
    [Route("notifications")]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationsAppService _notificationsAppService;
        public NotificationsController(INotificationsAppService notificationsAppService) {
            _notificationsAppService = notificationsAppService;
        }
        [HttpPost("email")]
        public async Task<IActionResult> PostEmail([FromBody] Email email)
        {
            if(!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            Result<bool> result = await _notificationsAppService.PostEmail(email);
            if (result.ResultType.Equals(ResultType.CreatedResult))
                return new StatusCodeResult(201);
            return new StatusCodeResult(500);
        }
    }
}