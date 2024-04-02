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
            Console.WriteLine("1");
            var meetingDetails = new CommsPlatformChat_SDM
            {
                ChatDescription = Request.Form["ChatDescription"],
                MeetingTopic = Request.Form["MeetingTopic"],
                MeetingDateTime = DateTime.Now.ToString(),
                MeetingDuration = int.Parse(Request.Form["MeetingDuration"]),
                MeetingDescription = Request.Form["MeetingDescription"],
                ZoomLink = Request.Form["ZoomLink"]
            };
            if (!ModelState.IsValid)
            {
                Console.WriteLine("2");
                return View(meetingDetails); // Return with errors
            }
            Console.WriteLine("3");
            try
            {
                Console.WriteLine("4");
                Console.WriteLine(meetingDetails);
                _communicationControl.CreateZoomMeeting(meetingDetails);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                // Log the exception
                ModelState.AddModelError("", "An error occurred while scheduling the meeting.");
                return View(meetingDetails);
            }
        }
        public IActionResult MeetingScheduledSuccessfully()
        {
            // Return a view that shows a success message or information after scheduling a meeting
            return View();
        }
    }
}
