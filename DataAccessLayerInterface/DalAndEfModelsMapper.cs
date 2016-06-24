using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterface.DALModel;
using EFModel;

namespace DataAccessLayerInterface
{
    public static class DalAndEfModelsMapper
    {
        public static DalRole ToDalEntity(this Role role)
        {
            return (role == null)? null : new DalRole()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
        }

        public static Role ToEfEntiity(this DalRole role)
        {
            return (role == null) ? null : new Role()
            {
                Name = role.Name,
                Description = role.Description
            };
        }

        public static DalUser ToDalEntity(this User user)
        {
            return (user == null) ? null : new DalUser()
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                RoleId = user.RoleId
            };
        }

        public static User ToEfEntity(this DalUser user)
        {
            return (user == null) ? null : new User()
            {
                Login = user.Login,
                Password = user.Password,
                RoleId = user.RoleId
            };
        }

        public static DalCategory ToDalEntity(this Category category)
        {
            return (category == null) ? null : new DalCategory()
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public static Category ToEfEntity(this DalCategory category)
        {
            return (category == null) ? null : new Category()
            {
                Name = category.Name
            };
        }

        public static DalCard ToDalEntity(this Card card)
        {
            return (card == null) ? null : new DalCard()
            {
                Id = card.Id,
                Title = card.Title,
                CategoryId = card.CategoryId,
                Description = card.Description,
                DateOfCreation = card.DateOfCreation,
                AuthorId = card.AuthorId,
                Cover = card.Cover,
                PositiveRate = card.PositiveRate,
                NegativeRate = card.NegativeRate
            };
        }

        public static Card ToEfEntity(this DalCard card)
        {
            return (card == null) ? null : new Card()
            {
                Title = card.Title,
                CategoryId = card.CategoryId,
                Description = card.Description,
                DateOfCreation = card.DateOfCreation,
                AuthorId = card.AuthorId,
                Cover = card.Cover,
                PositiveRate = card.PositiveRate,
                NegativeRate = card.NegativeRate
            };
        }

        public static DalAudioGenre ToDalEntity(this AudioGenre genre)
        {
            return (genre == null) ? null : new DalAudioGenre()
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }

        public static AudioGenre ToEfEntity(this DalAudioGenre genre)
        {
            return (genre == null) ? null : new AudioGenre()
            {
                Name = genre.Name
            };
        }

        public static DalAudioFile ToDalEntity(this AudioFile audio)
        {
            return (audio == null) ? null : new DalAudioFile()
            {
                Id = audio.Id,
                Name = audio.Name,
                Author = audio.Author,
                Path = audio.Path,
                GenreId = audio.GenreId,
                CardId = audio.CardId
            };
        }

        public static AudioFile ToEfEntity(this DalAudioFile audio)
        {
            return (audio == null) ? null : new AudioFile()
            {
                Name = audio.Name,
                Author = audio.Author,
                Path = audio.Path,
                GenreId = audio.GenreId,
                CardId = audio.CardId
            };
        }

        public static DalImage ToDalEntity(this Image image)
        {
            return (image == null) ? null : new DalImage()
            {
                Id = image.Id,
                Name = image.Name,
                Path = image.Path,
                CardId = image.CardId
            };
        }

        public static Image ToEfEntity(this DalImage image)
        {
            return (image == null) ? null : new Image()
            {
                Name = image.Name,
                Path = image.Path,
                CardId = image.CardId
            };
        }

        public static DalTextFile ToDalEntity(this TextFile text)
        {
            return (text == null) ? null : new DalTextFile()
            {
                Id = text.Id,
                Name = text.Name,
                Author = text.Author,
                Path = text.Path,
                CardId = text.CardId
            };
        }

        public static TextFile ToEfEntity(this DalTextFile text)
        {
            return (text == null) ? null : new TextFile()
            {
                Name = text.Name,
                Author = text.Author,
                Path = text.Path,
                CardId = text.CardId
            };
        }
    }
}
