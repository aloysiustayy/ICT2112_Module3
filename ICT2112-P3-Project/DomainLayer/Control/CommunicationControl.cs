﻿using DomainLayer.Entity;
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

        public void CreateZoomMeeting(
            string MeetingTopic,
            string MeetingDateTime,
            string MeetingDuration,
            string MeetingDescription,
            string MeetingLink)
        {
            CommsPlatformChat_SDM meeting = new CommsPlatformChat_SDM();
            meeting.MeetingTopic = MeetingTopic;
            meeting.MeetingDateTime = MeetingDateTime;
            meeting.MeetingDuration = MeetingDuration;
            meeting.MeetingDescription = MeetingDescription;
            meeting.ZoomLink = MeetingLink;

            _communicationDbContext.CreateZoomMeeting(meeting);
        }
    }
}
