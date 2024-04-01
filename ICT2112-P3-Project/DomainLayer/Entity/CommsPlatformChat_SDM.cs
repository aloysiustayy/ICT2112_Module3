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

    // Get the chat ID
    private int getChatId()
    {
        return chatId;
    }

    // Set the chat ID
    private void setChatId(int chatId)
    {
        this.chatId = chatId;
    }

    // Get all messages
    private List<IMessage> getMessages()
    {
        return messages;
    }

    // Set all messages
    private void setMessages(List<IMessage> messages)
    {
        this.messages = messages ?? throw new ArgumentNullException(nameof(messages));
    }


    // Stubbed implementation of updating chat details.
    public void UpdateCommsPlatformChatDetails()
    {
        
    }

    public void RetrieveCommsPlatformChatDetails()
    {
        // Assuming LoadChatDetailsById() is a method that retrieves chat details.
        var loadedDetails = LoadChatDetailsById(this.chatId);

        if (loadedDetails != null)
        {
            // Update the current instance's properties with the loaded details.
            this.setChatId(loadedDetails.chatId);
            this.setMessages(loadedDetails.messages);
        }
    }

    // Placeholder for the actual loading operation.
    private CommsPlatformChat_SDM LoadChatDetailsById(int chatId)
    {
        // Implementation code to load the chat details from a database.
        // This would return a CommsPlatformChat_SDM instance with the data or null if not found.
        return new CommsPlatformChat_SDM(); // Placeholder return object.
    }
}
