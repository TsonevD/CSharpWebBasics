using System.Linq;
using BattleCards.Data;
using BattleCards.Data.Models;
using BattleCards.Models.Cards;
using BattleCards.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public CardsController(ApplicationDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }
        [Authorize]
        public HttpResponse All()
        {
            var all = this.data.Cards
                .Select(x=>new AllCardsInputModel()
                {
                    CardId = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Attack = x.Attack,
                    Health = x.Health,
                    Image = x.ImageUrl,
                    Keyword = x.Keyword
                })
                .ToList();

            return View(all);
        }

        public HttpResponse Add() => View();

        [HttpPost]
        [Authorize]
        public HttpResponse Add(AddNewCadInputModel model)
        {
            var user = this.data.Users.FirstOrDefault(x => x.Id == this.User.Id);
            if (user == null)
            {
                return Unauthorized();
            }
            
            var errors = this.validator.ValidateNewCard(model);
            if (errors.Any())
            {
                return Error(errors);
            }
          
            var card = new Card()
            {
                Name = model.Name,
                Attack = model.Attack,
                Description = model.Description,
                Health = model.Health,
                ImageUrl = model.Image,
                Keyword = model.Keyword,
            };
            this.data.Cards.Add(card);

            this.data.UserCards.Add(new UserCard()
            {
                Card = card,
                User = user
            });

            this.data.SaveChanges();

            return Redirect("/Cards/All");
        }

        [Authorize]
        public HttpResponse Collection()
        {
            var myCollection = this.data.UserCards
                .Where(x => x.UserId == this.User.Id)
                .Select(x => new AllCardsInputModel()
                {
                    CardId = x.CardId,
                    Name = x.Card.Name,
                    Description = x.Card.Description,
                    Attack = x.Card.Attack,
                    Health = x.Card.Health,
                    Image = x.Card.ImageUrl,
                    Keyword = x.Card.Keyword
                }).ToList();

            return View(myCollection);
        }

        [Authorize]
        public HttpResponse AddToCollection(int cardId)
        {
            if (this.data.UserCards.Any(us => us.CardId == cardId && us.UserId == this.User.Id))
            {
                return this.Redirect("/Cards/All");
            }

            this.data.UserCards.Add(new UserCard
            {
                UserId = this.User.Id,
                CardId = cardId
            });
            
            this.data.SaveChanges();

            return Redirect("/Cards/Collection");
        }
        [Authorize]
        public HttpResponse RemoveFromCollection(int cardId)
        {
            var userCards = this.data.UserCards.FirstOrDefault(x => x.CardId == cardId && x.UserId == this.User.Id);

            this.data.UserCards.Remove(userCards);

            this.data.SaveChanges();

            return Redirect("/Cards/Collection");
        }

    }
}
