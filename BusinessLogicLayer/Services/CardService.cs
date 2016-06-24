using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BusinessLogicLayerInterface;
using BusinessLogicLayerInterface.BLLModel;
using BusinessLogicLayerInterface.ServiceInterfaces;
using DataAccessLayerInterface.RepositoryInterfaces;

namespace BusinessLogicLayer.Services
{
    public class CardService: ICardService
    {
        private readonly ICardRepository cardRepository;

        public CardService(ICardRepository repository)
        {
            cardRepository = repository;
        }

        public IEnumerable<BllCard> GetAllEntities()
        {
            return cardRepository.GetAllEntities().Select(dalEntity => dalEntity.ToBllEntity());
        }

        public BllCard GetEntityById(int id)
        {
            return cardRepository.GetEntityById(id).ToBllEntity();
        }

        public IEnumerable<BllCard> GetCardsWithGivenParameters(string title = null, string description = null, DateTime dateOfCreation = default(DateTime), int categoryId = -1, int authorId = -1)
        {
            BllCard sampleCard = new BllCard()
            {
                Title = title,
                Description = description,
                DateOfCreation = dateOfCreation,
                CategoryId = categoryId,
                AuthorId = authorId,
            };
            var dalResult = cardRepository.GetCardWithGivenParameters(sampleCard.ToDalEntity());
            return dalResult?.Select(dalEntity => dalEntity.ToBllEntity());
        }

        public void Create(BllCard entity)
        {
            cardRepository.Create(entity.ToDalEntity());
            cardRepository.SaveChanges();
        }

        public void Create(string title, string description, DateTime dateOfCreation, string cover, int categoryId, int authorId)
        {
            BllCard newCard = new BllCard()
            {
                Title = title,
                Description = description,
                DateOfCreation = dateOfCreation,
                Cover = cover,
                CategoryId = categoryId,
                AuthorId = authorId
            };
            cardRepository.Create(newCard.ToDalEntity());
            cardRepository.SaveChanges();
        }

        public void Update(BllCard entity)
        {
            cardRepository.Update(entity.ToDalEntity());
            cardRepository.SaveChanges();
        }

        public void Delete(int entityId)
        {
            cardRepository.Delete(entityId);
            cardRepository.SaveChanges();
        }

        public bool CheckIfAlreadyMarkedPositively(int cardId, int userId)
        {
            return cardRepository.CheckIfThisMarkWasAlreagyGiven(cardId, userId, true);
        }

        public bool CheckIfAlreadyMarkedNegatively(int cardId, int userId)
        {
            return cardRepository.CheckIfThisMarkWasAlreagyGiven(cardId, userId, false);
        }

        public void EstimateCard(int cardId, int userId, bool markIsPositive)
        {
            if (markIsPositive)
            {
                GetEntityById(cardId).PositiveRate++;
                cardRepository.AddCardMark(cardId, userId, true);
            }
            else
            {
                GetEntityById(cardId).NegativeRate--;
                cardRepository.AddCardMark(cardId, userId, false);
            }
        }

    }
}
