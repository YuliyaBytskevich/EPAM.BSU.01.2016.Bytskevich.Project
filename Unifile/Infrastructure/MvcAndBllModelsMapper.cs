using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLayerInterface.BLLModel;
using BusinessLogicLayerInterface.ServiceInterfaces;
using Unifile.Models;
using Unifile.Models.MvcModel;

namespace Unifile.Infrastructure
{
    public static class MvcAndBllModelsMapper
    {

        public static MvcRole ToMvcEntity(this BllRole role)
        {
            return (role == null)? null: new MvcRole()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
        }

        public static BllRole ToBllEntity(this MvcRole role)
        {
            return (role == null) ? null : new BllRole()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
        }

        public static MvcUser ToMvcEntity(this BllUser user, IRoleService roleService)
        {
            return (user == null) ? null : new MvcUser()
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                RoleName = roleService.GetEntityById(user.RoleId).Name
            };
        }

        public static BllUser ToBllEntity(this MvcUser user, IRoleService roleService)
        {
            return (user == null) ? null : new BllUser()
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                RoleId = roleService.GetRoleByName(user.RoleName).Id
            };
        }

        public static MvcCategory ToMvcEntity(this BllCategory category)
        {
            return (category == null) ? null : new MvcCategory()
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public static BllCategory ToBllEntity(this MvcCategory category)
        {
            return (category == null) ? null : new BllCategory()
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public static MvcAudioGenre ToMvcEntity(this BllAudioGenre genre)
        {
            return (genre == null) ? null : new MvcAudioGenre()
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }

        public static BllAudioGenre ToBllEntity(this MvcAudioGenre genre)
        {
            return (genre == null) ? null : new BllAudioGenre()
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }

        public static MvcCard ToMvcEntity(this BllCard card, ICategoryService categoryService, IUserService userService)
        {
            return (card == null) ? null : new MvcCard()
            {
                Id = card.Id,
                Title = card.Title,
                Category = categoryService.GetEntityById(card.CategoryId).Name,
                Author = userService.GetEntityById(card.AuthorId).Login,
                Description = card.Description,
                DateOfCreation = card.DateOfCreation.ToShortDateString(),
                Cover = card.Cover
            };
        }

        public static BllCard ToBllEntity(this MvcCard card, ICategoryService categoryService, IUserService userService)
        {
            return (card == null) ? null : new BllCard()
            {
                Id = card.Id,
                Title = card.Title,
                CategoryId = categoryService.GetCategoryByName(card.Category).Id,
                AuthorId = userService.GetUsersWithGivenParameters(card.Author).First().Id,
                Description = card.Description,
                DateOfCreation = DateTime.Parse(card.DateOfCreation),
                Cover = card.Cover
            };
        }

        public static MvcAudioFile ToMvcEntity(this BllAudioFile audio, IAudioGenreService genreService, ICardService cardService)
        {
            return (audio == null) ? null : new MvcAudioFile()
            {
                Id = audio.Id,
                Name = audio.Name,
                Author = audio.Author,
                Path = audio.Path,
                Genre = genreService.GetEntityById(audio.GenreId).Name,
                CardTitle = cardService.GetEntityById(audio.CardId).Title
            };
        }

        public static BllAudioFile ToBllEntity(this MvcAudioFile audio, IAudioGenreService genreService, ICardService cardService)
        {
            return (audio == null) ? null : new BllAudioFile()
            {
                Id = audio.Id,
                Name = audio.Name,
                Author = audio.Author,
                Path = audio.Path,
                GenreId = genreService.GetGenreByName(audio.Name).Id,
                CardId = cardService.GetCardsWithGivenParameters(audio.CardTitle).First().Id
            };
        }

        public static MvcImage ToMvcEntity(this BllImage image, ICardService cardService)
        {
            return (image == null) ? null : new MvcImage()
            {
                Id = image.Id,
                Name = image.Name,
                Path = image.Path,
                CardTitle = cardService.GetEntityById(image.CardId).Title
            };
        }

        public static BllImage ToBllEntity(this MvcImage image, ICardService cardService)
        {
            return (image == null) ? null : new BllImage()
            {
                Id = image.Id,
                Name = image.Name,
                Path = image.Path,
                CardId = cardService.GetCardsWithGivenParameters(image.CardTitle).First().Id
            };
        }

        public static MvcTextFile ToMvcEntity(this BllTextFile text, ICardService cardService)
        {
            return (text == null) ? null : new MvcTextFile()
            {
                Id = text.Id,
                Name = text.Name,
                Author = text.Author,
                Path = text.Path,
                CardTitle = cardService.GetEntityById(text.CardId).Title
            };
        }

        public static BllTextFile ToBllEntity(this MvcTextFile text, ICardService cardService)
        {
            return (text == null) ? null : new BllTextFile()
            {
                Id = text.Id,
                Name = text.Name,
                Author = text.Author,
                Path = text.Path,
                CardId = cardService.GetCardsWithGivenParameters(text.CardTitle).First().Id
            };
        }

    }
}