using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayerInterface.BLLModel;
using EFModel;
using BusinessLogicLayerInterface.ServiceInterfaces;
using Unifile.Infrastructure;
using Unifile.Models;
using Unifile.Models.MvcModel;

namespace Unifile.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbContext db;
        private readonly IUserService userService;
        private readonly ICardService cardService;
        private readonly ICategoryService categoryService;

        private const int pageCapacity = 5;

        public HomeController(DbContext context, IUserService userService, ICardService cardService, ICategoryService categoryService)
        {
            db = context;
            this.userService = userService;
            this.cardService = cardService;
            this.categoryService = categoryService;
        }

        // GET: Home
        public ActionResult Index(string currentCategory = null, int pageNum = 1)
        {
            IEnumerable<MvcCard> cards;
            if (currentCategory != null && currentCategory != "All categories")
            {
                cards =
                    cardService.GetAllEntities()
                               .Select(bllEntity => bllEntity.ToMvcEntity(categoryService, userService))
                               .Where(card => card.Category == currentCategory);
            }
            else
            {
                cards =
                    cardService.GetAllEntities()
                               .Select(bllEntity => bllEntity.ToMvcEntity(categoryService, userService));
            }
            var cardsPerPage = cards.Skip((pageNum - 1) * pageCapacity).Take(pageCapacity);
            var viewModel = new CardsListViewModel()
            {
                Cards = cardsPerPage,
                PageInfo = new PageInfo()
                {
                    CurrentPageNumber = pageNum,
                    PageCapacity = pageCapacity,
                    TotalNumOfItems = cards.Count()
                },
                CurrentCategory = currentCategory
            };
            return View(viewModel);
        }

        public PartialViewResult CategoriesMenu()
        {
            var categories = new List<MvcCategory>();
            MvcCategory defaultCategory = new MvcCategory(){ Id = -1, Name = "All categories" };
            categories = categoryService.GetAllEntities().Select(bllEntity => bllEntity.ToMvcEntity()).ToList();
            categories.Add(defaultCategory);
            return PartialView(categories);
        }

        public ActionResult GetImg(string relativeFilePath)
        {
            if (!string.IsNullOrEmpty(relativeFilePath))
            {
                FileInfo file = new FileInfo(Server.MapPath(relativeFilePath));
                if (file.Exists)
                    return File(file.FullName, "text/plain", file.Name);
            }
            return Content("");
        }
    }
}