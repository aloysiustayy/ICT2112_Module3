using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Entity;
using DomainLayer.Interface;

namespace DomainLayer.Control
{
    public class PhotoControl
    {
        private readonly IPhotoTDG _photoDbContext;

        public PhotoControl(IPhotoTDG photoDbContext)
        {
            _photoDbContext = photoDbContext;
        }

        public List<Photo> RetrieveAllPhoto()
        {
            return _photoDbContext.GetAllPhotos();
        }

        public void AddPhoto(Photo newPhoto)
        {
            _photoDbContext.AddPhoto(newPhoto);
        }
    }
}
