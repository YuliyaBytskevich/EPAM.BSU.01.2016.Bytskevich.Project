using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayerInterface.BLLModel;
using DataAccessLayerInterface.DALModel;
using DataAccessLayerInterface.RepositoryInterfaces;

namespace BusinessLogicLayerInterface
{
    public static class BllAndDalModelsMapper
    {
        public static BllRole ToBllEntity(this DalRole role)
        {
            return (role == null)? null: new BllRole()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
        }

        public static DalRole ToDalEntity(this BllRole role)
        {
            return (role == null) ? null : new DalRole()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
        }

        public static BllUser ToBllEntity(this DalUser user)
        {
            return (user == null) ? null : new BllUser()
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                RoleId = user.RoleId
            };
        }

        public static DalUser ToDalEntity(this BllUser user)
        {
            return (user == null) ? null : new DalUser()
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                RoleId = user.RoleId
            };
        }

        public static BllCategory ToBllEntity(this DalCategory category)
        {
            return (category == null) ? null : new BllCategory()
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public static DalCategory ToDalEntity(this BllCategory category)
        {
            return (category == null) ? null : new DalCategory()
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public static BllCard ToBllEntity(this DalCard card)
        {
            return (card == null) ? null : new BllCard()
            {
                Id = card.Id,
                Title = card.Title,
                Description = card.Description,
                DateOfCreation = card.DateOfCreation,
                Cover = card.Cover,
                AuthorId = card.AuthorId,
                CategoryId = card.CategoryId,
                PositiveRate = card.PositiveRate,
                NegativeRate = card.NegativeRate
            };
        }

        public static DalCard ToDalEntity(this BllCard card)
        {
            return (card == null) ? null : new DalCard()
            {
                Id = card.Id,
                Title = card.Title,
                Description = card.Description,
                DateOfCreation = card.DateOfCreation,
                Cover = card.Cover,
                AuthorId = card.AuthorId,
                CategoryId = card.CategoryId,
                PositiveRate = card.PositiveRate,
                NegativeRate = card.NegativeRate
            };
        }

        public static BllAudioGenre ToBllEntity(this DalAudioGenre genre)
        {
            return (genre == null) ? null : new BllAudioGenre()
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }

        public static DalAudioGenre ToDalEntity(this BllAudioGenre genre)
        {
            return (genre == null) ? null : new DalAudioGenre()
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }

        public static BllAudioFile ToBllEntity(this DalAudioFile audio)
        {
            return (audio == null) ? null : new BllAudioFile()
            {
                Id = audio.Id,
                Name = audio.Name,
                Author = audio.Author,
                Path = audio.Path,
                GenreId = audio.GenreId,
                CardId = audio.CardId
            };
        }

        public static DalAudioFile ToDalEntity(this BllAudioFile audio)
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

        public static BllImage ToBllEntity(this DalImage image)
        {
            return (image == null) ? null : new BllImage()
            {
                Id = image.Id,
                Name = image.Name,
                Path = image.Path,
                CardId = image.CardId
            };
        }

        public static DalImage ToDalEntity(this BllImage image)
        {
            return (image == null) ? null : new DalImage()
            {
                Id = image.Id,
                Name = image.Name,
                Path = image.Path,
                CardId = image.CardId
            };
        }

        public static BllTextFile ToBllEntity(this DalTextFile text)
        {
            return (text == null) ? null : new BllTextFile()
            {
                Id = text.Id,
                Name = text.Name,
                Author = text.Author,
                Path = text.Path,
                CardId = text.CardId
            };
        }

        public static DalTextFile ToDalEntity(this BllTextFile text)
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

    }
}
