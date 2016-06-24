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
    public class TextAttachmentController : Controller
    {
        private readonly ITextFileService textService;
        private readonly ICardService cardService;

        public TextAttachmentController(ITextFileService ts, ICardService cs)
        {
            textService = ts;
            cardService = cs;
        }

        // GET: TextAttachment
        public PartialViewResult GetTexts(int cardId)
        {
            IEnumerable<MvcTextFile> attachedTexts = textService.GetAllEntities()
                .Where(e => e.CardId == cardId)
                .Select(bllEntity => bllEntity.ToMvcEntity(cardService));
            return PartialView(attachedTexts);
        }

        public FileResult DownloadText(int textId)
        {
            var audio = textService.GetEntityById(textId);
            FileInfo file = new FileInfo(Server.MapPath(audio.Path));
            if (file.Exists)
            {
                int formatPosition = audio.Path.LastIndexOf('.');
                string format = audio.Path.Substring(formatPosition + 1);
                return File(audio.Path, format, audio.Author + " - " + audio.Name + "." + format);
            }
            return null;
        }

        public ActionResult FindTextsByGivenParameters(string name, string author)
        {
            var bllResults = textService.GetTextsWithGivenParameters(name, author);
            var foundAudios = bllResults.Any()
                ? bllResults.Select(bllEntity => bllEntity.ToMvcEntity(cardService))
                : null;
            return PartialView(foundAudios);
        }
    }
}