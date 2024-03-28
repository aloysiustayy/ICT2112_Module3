using DomainLayer.Entity;
using DataSourceLayer.Data;
using DomainLayer.Interface;

namespace DataSourceLayer.Gateway
{
    public class PhotoTDG : IPhotoTDG
    {
        private readonly DataContext _context;

        public PhotoTDG(DataContext context)
        {
            _context = context;
        }

        public List<Photo> GetAllPhotos()
        {
            return _context.Photos.ToList();
        }

        public Photo GetPhotoById(int photoId)
        {
            return _context.Photos.Find(photoId);
        }

        public void AddPhoto(Photo newPhoto)
        {
            _context.Photos.Add(newPhoto);
            _context.SaveChanges();
        }

        public void UpdatePhoto(Photo existingPhoto)
        {
            _context.Photos.Update(existingPhoto);
            _context.SaveChanges();
        }

        public void DeletePhoto(int photoId)
        {
            var existingPhoto = _context.Photos.Find(photoId);
            if (existingPhoto != null)
            {
                _context.Photos.Remove(existingPhoto);
                _context.SaveChanges();
            }
        }
    }
}
