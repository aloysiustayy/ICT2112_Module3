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

        //Placeholder for Chat DB for now
        public List<Photo> CreateChat()
        {
            return _context.Photos.ToList();
        }

        public List<Photo> InsertChat()
        {
            return _context.Photos.ToList();
        }

        public List<Photo> UpdateChat()
        {
            return _context.Photos.ToList();
        }

        public List<Photo> DeleteChat()
        {
            return _context.Photos.ToList();
        }
    }
}
