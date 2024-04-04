using DomainLayer.Entity;
using DomainLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Control
{
    public class CommunicationControl
    {
        private readonly ICommunicationTDG _communicationDbContext;

        public CommunicationControl(ICommunicationTDG communicationDbContext)
        {
            _communicationDbContext = communicationDbContext;
        }

        public void CreateChat(CommsPlatformChat_SDM chatId)
        {
            _communicationDbContext.CreateChat(chatId);
        }
        public void RetrieveChat(CommsPlatformChat_SDM chatId)
        {
            _communicationDbContext.ReadChat(chatId);
        }

        public void DeleteChat(CommsPlatformChat_SDM chatId)
        {
            _communicationDbContext.DeleteChat(chatId);
        }

        public void CreateZoomMeeting(
            string chatDescription,
            string MeetingTopic,
            string MeetingDateTime,
            string MeetingDuration,
            string MeetingDescription,
            string MeetingLink)
        {
            CommsPlatformChat_SDM meeting = new CommsPlatformChat_SDM();
            meeting.ChatDescription = chatDescription;
            meeting.MeetingTopic = MeetingTopic;
            meeting.MeetingDateTime = MeetingDateTime;
            meeting.MeetingDuration = MeetingDuration;
            meeting.MeetingDescription = MeetingDescription;
            meeting.ZoomLink = MeetingLink;

            _communicationDbContext.CreateZoomMeeting(meeting);
        }

        public void RetrieveZoomMeeting()
        {
            //For GM to retrieve Zoom meeting
        }

        public void AddMessages()
        {
            //For GM to add messages
        }
    }
}
