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
using BL;
using System.Security.Claims;

namespace API.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase {
        private readonly TutorManager _tutorManager;
        private readonly UserManager<User> _userManager;
        private readonly MessageManager _messageManager;

        public MessageController(TutorManager tutorManager, UserManager<User> userManager, MessageManager messageManager) {
            _tutorManager = tutorManager;
            _userManager = userManager;
            _messageManager = messageManager;
        }


        [Authorize("Tutor")]
        [HttpPut("approve/{followRequestId}")]
        public async Task<IActionResult> ApproveFollowRequest([FromRoute] string followRequestId, bool approve = true) {
            string tutorId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Tutor tutor = await _tutorManager.FindByIdAsync(tutorId);
            if (tutor == null) return BadRequest(new { Error = "A tutor account with your Id could not be found." });

            FollowRequest request = await _messageManager.GetSingleRequestById(followRequestId);
            if (request == null || request.ReceiverId != tutorId) return BadRequest();
            request = await _messageManager.DeleteFollowRequest(followRequestId);

            User targetUser = await _userManager.FindByIdAsync(request.SenderId);
            if (targetUser == null) return BadRequest(new { Error = "A user with this Id could not be found." });

            if (approve) {
                tutor.MyContacts.Add(targetUser);
                targetUser.MyContacts.Add(tutor);

                _tutorManager.SaveChanges();
                await _userManager.UpdateAsync(targetUser);
            }

            string userName = (targetUser.FirstName != null && targetUser.LastName != null)
                ? string.Format("{0} {1}", targetUser.FirstName, targetUser.LastName)
                : targetUser.Id;

            return Ok(new { Results = string.Format("Request from {0} to follow you approved.", userName) });
        }


        [Authorize]
        [HttpPut("request/{tutorId}")]
        public async Task<IActionResult> RequestFollowTutor([FromRoute] string tutorId) {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            User user = await _userManager.FindByIdAsync(userId);
            if (user == null) return BadRequest(new { Error = "An account with your Id could not be found." });

            Tutor tutor = await _tutorManager.FindByIdAsync(tutorId);
            if (tutor == null) return BadRequest(new { Error = "A tutor with this Id could not be found." });

            FollowRequest checkExists = await _messageManager.GetTutorFollowRequestsByUserId(userId);
            if (checkExists != null) return BadRequest(new { Error = "You already have a pending request." });

            await _messageManager.AddFollowRequest(new() {
                SenderId = userId,
                ReceiverId = tutorId
            });

            string tutorName = (tutor.FirstName != null && tutor.LastName != null)
                ? string.Format("{0} {1}", tutor.FirstName, tutor.LastName)
                : tutorId;

            return Ok(new { Results = string.Format("Request to follow {0} sent.", tutorName)});
        }
    }
}