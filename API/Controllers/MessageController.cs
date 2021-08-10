using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Entities.Database;
using Entities.Dtos;
using Entities.Query;
using BL;
using NetTopologySuite;
using System.Security.Claims;

namespace API.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase {
        private readonly TutorManager _tutorManager;
        private readonly UserManager<User> _userManager;
        private readonly MessageManager _messageManager;
        private readonly IMapper _mapper;

        public MessageController(TutorManager tutorManager, UserManager<User> userManager, MessageManager messageManager, IMapper mapper) {
            _tutorManager = tutorManager;
            _userManager = userManager;
            _messageManager = messageManager;
            _mapper = mapper;
        }


        [Authorize("Tutor")]
        [HttpPut("approve")]
        public async Task<IActionResult> ApproveFollowRequest(string followRequestId, bool approve = true) {
            string tutorId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Tutor tutor = await _tutorManager.FindByIdAsync(tutorId);
            if (tutor == null) return BadRequest();

            FollowRequest request = await _messageManager.DeleteFollowRequest(followRequestId);
            if (request == null || request.ReceiverId != tutorId) return BadRequest();

            User targetUser = await _userManager.FindByIdAsync(request.SenderId);
            if (targetUser == null) return BadRequest();

            if (approve) {
                tutor.MyContacts.Add(targetUser);
                targetUser.MyContacts.Add(tutor);

                _tutorManager.SaveChanges();
                await _userManager.UpdateAsync(targetUser);
            }
            
            return Ok();
        }


        [Authorize]
        [HttpPut("request")]
        public async Task<IActionResult> RequestFollowTutor([FromRoute] string tutorId) {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            User user = await _userManager.FindByIdAsync(userId);
            if (user == null) return BadRequest();

            Tutor tutor = await _tutorManager.FindByIdAsync(tutorId);
            if (tutor == null) return BadRequest();

            FollowRequest checkExists = await _messageManager.GetTutorFollowRequestsByUserId(userId);
            if(checkExists != null) return BadRequest();

            await _messageManager.AddFollowRequest(new() {
                SenderId = userId,
                ReceiverId = tutorId
            });
            return Ok();
        }
    }
}