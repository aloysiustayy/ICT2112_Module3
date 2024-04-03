using DomainLayer.Control;
using DomainLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;


namespace PresentationLayer.Controllers
{
    public class CommunicationController : Controller
    {
        private readonly CommunicationControl _communicationControl;

        public CommunicationController(CommunicationControl communicationControl)
        {
            _communicationControl = communicationControl;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateZoomTable()
        {
            var meetingDetails = new CommsPlatformChat_SDM
            {
                ChatDescription = Request.Form["ChatDescription"],
                MeetingTopic = Request.Form["MeetingTopic"],
                MeetingDateTime = DateTime.Now.ToString(),
                MeetingDuration = Request.Form["MeetingDuration"],
                MeetingDescription = Request.Form["MeetingDescription"],
                ZoomLink = Request.Form["ZoomLink"]
            };
            try
            {
                Console.WriteLine(meetingDetails);
                _communicationControl.CreateZoomMeeting(
                    meetingDetails.ChatDescription,
                    meetingDetails.MeetingTopic,
                    meetingDetails.MeetingDateTime,
                    meetingDetails.MeetingDuration,
                    meetingDetails.MeetingDescription,
                    meetingDetails.ZoomLink
                );
                if (!ModelState.IsValid)
                {
                    return View(meetingDetails); // Return with errors
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                // Log the exception
                ModelState.AddModelError("", "An error occurred while scheduling the meeting.");
                return View(meetingDetails);
            }
        }
    }
}
