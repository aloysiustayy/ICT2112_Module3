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

        public void createZoomMeeting(int chatId,
            string chatDescription,
            string MeetingTopic,
            string MeetingDateTime,
            int MeetingDuration,
            string MeetingDescription,
            string MeetingLink)
        {

            Console.WriteLine("Chat ID: " + chatId);

            CommsPlatformChat_SDM newCommsPlatformChat_SDM = new CommsPlatformChat_SDM{
                ChatId = chatId,
                ChatDescription = chatDescription,
                MeetingTopic = MeetingTopic,
                MeetingDateTime = MeetingDateTime,
                MeetingDuration = MeetingDuration,
                MeetingDescription = MeetingDescription,
                ZoomLink = MeetingLink
            };

            // Call the method to create the MedicationCounselling record in the database
            //Not Working
            //_communicationDbContext.createZoomMeeting(newCommsPlatformChat_SDM);
        }

        public void CreateZoomMeeting(CommsPlatformChat_SDM chatId)
        {
            _communicationDbContext.InsertZoomLink(chatId);
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
