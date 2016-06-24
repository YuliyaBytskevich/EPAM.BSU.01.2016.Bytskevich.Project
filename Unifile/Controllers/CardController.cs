using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayerInterface.ServiceInterfaces;
using Unifile.Infrastructure;
using Unifile.Models;
using Unifile.Models.MvcModel;

namespace Unifile.Controllers
{
    public class CardController : Controller
    {
        private readonly IUserService userService;
        private readonly ICardService cardService;
        private readonly ICategoryService categoryService;

        public CardController(IUserService us, ICardService cs, ICategoryService cts)
        {
            userService = us;
            cardService = cs;
            categoryService = cts;
        }
        
        // GET: Card
        public ActionResult Index(int cardId)
        {
            var viewModel = cardService.GetEntityById(cardId).ToMvcEntity(categoryService, userService);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult EditCard(int cardId)
        {
            ViewBag.Categories = categoryService.GetAllEntities().Select(bll => bll.ToMvcEntity());
            var toBeEdited = cardService.GetEntityById(cardId);
            return toBeEdited == null ? (ActionResult) HttpNotFound() : View(toBeEdited.ToMvcEntity(categoryService, userService));
        }

        [HttpPost]
        public ActionResult EditCard(MvcCard card)
        {
            cardService.Update(card.ToBllEntity(categoryService, userService));
            return RedirectToAction("Index", "Home");
        }

    }
}