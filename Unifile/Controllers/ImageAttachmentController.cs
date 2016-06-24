using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayerInterface.ServiceInterfaces;
using Unifile.Infrastructure;
using Unifile.Models.MvcModel;

namespace Unifile.Controllers
{
    public class ImageAttachmentController : Controller
    {
        private readonly ICardService cardService;
        private readonly IImageService imageService;

        public ImageAttachmentController(ICardService cs, IImageService ims)
        {
            cardService = cs;
            imageService = ims;
        }

        // GET: ImageAttachment
        public PartialViewResult GetImages(int cardId)
        {
            IEnumerable<MvcImage> attachedImages = imageService.GetAllEntities()
                .Where(e => e.CardId == cardId)
                .Select(bllEntity => bllEntity.ToMvcEntity(cardService));
            return PartialView(attachedImages);
        }

        public FileResult ShowImage(int imageId)
        {
            string virtualPath = imageService.GetEntityById(imageId).Path;
            FileInfo file = new FileInfo(Server.MapPath(virtualPath));
            if (file.Exists)
            {
                FileStream stream = new FileStream(file.FullName, FileMode.Open);
                int formatPosition = file.FullName.LastIndexOf('.');
                string format = file.FullName.Substring(formatPosition + 1);
                return File(stream, format);
            }
            return null;
        }

        public FileResult DownloadImage(int imageId)
        {
            var img = imageService.GetEntityById(imageId);
            FileInfo file = new FileInfo(Server.MapPath(img.Path));
            if (file.Exists)
            {
                int formatPosition = img.Path.LastIndexOf('.');
                string format = img.Path.Substring(formatPosition + 1);
                return File(img.Path, format, img.Name + "." + format);
            }
            return null;
        }

        public ActionResult FindImagesByGivenParameters(string name)
        {
            var bllResults = imageService.GetImagesWithGivenParameters(name);
            var foundAudios = bllResults.Any()
                ? bllResults.Select(bllEntity => bllEntity.ToMvcEntity(cardService))
                : null;
            return PartialView(foundAudios);
        }
    }
}