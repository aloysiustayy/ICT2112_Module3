using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Entity;

namespace DomainLayer.Interface
{
    public interface IPhotoTDG
    {
        public List<Photo> GetAllPhotos();

        public Photo GetPhotoById(int photoId);

        public void AddPhoto(Photo newPhoto);

        public void UpdatePhoto(Photo existingPhoto);
        
        public void DeletePhoto(int photoId);
    }
}
