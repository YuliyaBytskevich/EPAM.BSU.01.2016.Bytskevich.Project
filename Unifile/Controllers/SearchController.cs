using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayerInterface.BLLModel;
using BusinessLogicLayerInterface.ServiceInterfaces;
using Unifile.Infrastructure;

namespace Unifile.Controllers
{
    public class SearchController : Controller
    {

        private readonly ICardService cardService;
        private readonly ICategoryService categoryService;
        private readonly IUserService userService;

        public SearchController(ICardService cs, ICategoryService cts, IUserService us)
        {
            cardService = cs;
            categoryService = cts;
            userService = us;
        }

        public ActionResult VariableSearch()
        {
            return View();
        }

        public ActionResult FindByCardTitle(string title)
        {
            var bllResults = cardService.GetCardsWithGivenParameters(title);
            var foundCards = bllResults.Any()
                ? bllResults.Select(bllEntity => bllEntity.ToMvcEntity(categoryService, userService))
                : null;
            return PartialView(foundCards);
        }

        public ActionResult FindByGivenParameters(string title, string category, string descriptionKeywords , string author , DateTime? dateOfCreation)
        {
            int categoryId;
            if (category == "")
                categoryId = -1;
            else
            {
                var categoryEntity = categoryService.GetCategoryByName(category);
                if (categoryEntity == null)
                    return PartialView(null);
                categoryId = categoryEntity.Id;
            }
            int authorId;
            if (author == "")
                authorId = -1;
            else
            {
                var userEntities = userService.GetUsersWithGivenParameters(author);
                if (userEntities == null)
                    return PartialView(null);
                authorId = userEntities.First().Id;
            }
            if (dateOfCreation == null)
                dateOfCreation = default(DateTime);
            var bllResults = cardService.GetCardsWithGivenParameters(title, descriptionKeywords, dateOfCreation.Value, categoryId, authorId);
            var foundCards = bllResults.Any()
                ? bllResults.Select(bllEntity => bllEntity.ToMvcEntity(categoryService, userService))
                : null;
            return PartialView(foundCards);
        }

    }
}