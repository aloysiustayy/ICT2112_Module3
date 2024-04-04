using DomainLayer.Entity;
using DataSourceLayer.Data;
using DomainLayer.Interface;

namespace DataSourceLayer.Gateway
{
    public class CommunicationTDG : ICommunicationTDG
    {
        private readonly DataContext _context;

        public CommunicationTDG(DataContext context)
        {
            _context = context;
        }

        public void CreateZoomMeeting(CommsPlatformChat_SDM meeting)
        {
            _context.Communication.Add(meeting);
            _context.SaveChanges();
        }

        public void InsertZoomLink(CommsPlatformChat_SDM chatId)
        {
            _context.Communication.Add(chatId);
            _context.SaveChanges();
        }
    }
}
