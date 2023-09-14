using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DAL
{
    public class ContentRepository
    {
        public int UploadImageInDataBase(HttpPostedFileBase file, Image image)
        {

            image.Images = ConvertToBytes(file);
            var images = new Image
            {
                Name = image.Name,
                Images = image.Images
            };
            var ctx = new NewsEntities();
            ctx.Image.Add(images);
            int i = ctx.SaveChanges();
            if (i == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
    }
}
