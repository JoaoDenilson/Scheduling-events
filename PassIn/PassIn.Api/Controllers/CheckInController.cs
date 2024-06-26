﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.Checkings.DoCheckin;
using PassIn.Application.UseCases.Checkins.DoCheckin;
using PassIn.Communication.Responses;

namespace PassIn.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckInController : ControllerBase
    {
        private readonly IDoAttendeeCheckinUseCase doAttendeeCheckinUseCase;

        public CheckInController(IDoAttendeeCheckinUseCase doAttendeeCheckinUseCase)
        {
            this.doAttendeeCheckinUseCase = doAttendeeCheckinUseCase;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status409Conflict)]
        public IActionResult CheckIn([FromQuery] Guid attendeeId)
        {
            var response = doAttendeeCheckinUseCase.Execute(attendeeId);

            return Created(string.Empty, response);
        }
    }
}
