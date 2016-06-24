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
    public class AudioAttachmentController : Controller
    {
        private readonly IAudioFileService audioService;
        private readonly ICardService cardService;
        private readonly IAudioGenreService genreService;

        public AudioAttachmentController(IAudioFileService afs, ICardService cs, IAudioGenreService gs)
        {
            audioService = afs;
            cardService = cs;
            genreService = gs;
        }

        // GET: AudioAttachment
        public PartialViewResult GetAudios(int cardId)
        {
            IEnumerable<MvcAudioFile> attachedAudios = 
                audioService.GetAllEntities()
                            .Where(e => e.CardId == cardId)
                            .Select(bllEntity => bllEntity.ToMvcEntity(genreService, cardService));
            return PartialView(attachedAudios);
        }

        public FileResult PlayAudio(int audioId)
        {
            string virtualPath = audioService.GetEntityById(audioId).Path;
            FileInfo file = new FileInfo(Server.MapPath(virtualPath));
            if (file.Exists)
            {
                FileStream stream = new FileStream(file.FullName, FileMode.Open);
                return File(stream, "mp3");
            }
            return null;
        }

        public FileResult DownloadAudio(int audioId)
        {
            var audio = audioService.GetEntityById(audioId);
            FileInfo file = new FileInfo(Server.MapPath(audio.Path));
            if (file.Exists)
            {
                int formatPosition = audio.Path.LastIndexOf('.');
                string format = audio.Path.Substring(formatPosition + 1);
                return File(audio.Path, format, audio.Author + " - " + audio.Name + "." + format);
            }
            return null;
        }

        public ActionResult FindAudiosByGivenParameters(string name, string author, string genre)
        {
            int genreId;
            if (genre == "")
                genreId = -1;
            else
            {
                var genreEntity = genreService.GetGenreByName(genre);
                if (genreEntity == null)
                    return PartialView(null);
                genreId = genreEntity.Id;
            }
            var bllResults = audioService.GetAudiosWithGivenParameters(name, author, genreId, -1);
            var foundAudios = bllResults.Any()
                ? bllResults.Select(bllEntity => bllEntity.ToMvcEntity(genreService, cardService))
                : null;
            return PartialView(foundAudios);
        }
    }
}