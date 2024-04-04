using System;
using System.Collections.Generic;
using DomainLayer.Interface;

namespace DomainLayer.Entity;
public class CommsPlatformChat_SDM
{
    private int chatId;
    private List<IMessage> messages;

    public CommsPlatformChat_SDM()
    {
        messages = new List<IMessage>();
    }

    [System.ComponentModel.DataAnnotations.Key]
    public string MeetingTopic { get; set; }
    public string MeetingDateTime { get; set; }
    public string MeetingDuration { get; set; }
    public string MeetingDescription { get; set; }
    public string ZoomLink { get; set; }


    // Stubbed implementation of updating chat details.
    public void UpdateCommsPlatformChatDetails()
    {
        
    }
}
