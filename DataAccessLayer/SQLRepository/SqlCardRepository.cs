using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterface;
using DataAccessLayerInterface.DALModel;
using DataAccessLayerInterface.RepositoryInterfaces;
using EFModel;

namespace DataAccessLayer.SQLRepository
{
    public class SqlCardRepository: ICardRepository
    {
        private readonly DbContext db;

        public SqlCardRepository(DbContext context)
        {
            db = context;
        }

        public IEnumerable<DalCard> GetAllEntities()
        {
            foreach (var card in db.Set<Card>()) yield return card.ToDalEntity(); 
        }

        public DalCard GetEntityById(int id)
        {
            Card found = db.Set<Card>().SingleOrDefault(x => x.Id == id);
            return found?.ToDalEntity();
        }

        public IEnumerable<DalCard> GetCardWithGivenParameters(DalCard sampleCard)
        {
            IQueryable<Card> query = db.Set<Card>()
                .Where(c =>
                    (string.IsNullOrEmpty(sampleCard.Title) || c.Title.Contains(sampleCard.Title)) &&
                    (string.IsNullOrEmpty(sampleCard.Description) || c.Description.Contains(sampleCard.Description)) &&
                    (sampleCard.DateOfCreation == default(DateTime) || c.DateOfCreation == sampleCard.DateOfCreation) &&
                    (sampleCard.AuthorId < 0 || c.AuthorId == sampleCard.AuthorId) &&
                    (sampleCard.CategoryId < 0 || c.CategoryId == sampleCard.CategoryId));
            foreach (var card in query) yield return card.ToDalEntity();
        }

        public void Create(DalCard newCard)
        {
            db.Set<Card>().Add(newCard.ToEfEntity());
        }

        public void Update(DalCard cardToBeUpdated)
        {
            Card entityFromDb = db.Set<Card>().SingleOrDefault(x => x.Id == cardToBeUpdated.Id);
            if (entityFromDb == null) return;
            entityFromDb.Title = cardToBeUpdated.Title;
            entityFromDb.CategoryId = cardToBeUpdated.CategoryId;
            entityFromDb.Description = cardToBeUpdated.Description;
            entityFromDb.DateOfCreation = cardToBeUpdated.DateOfCreation;
            entityFromDb.AuthorId = cardToBeUpdated.AuthorId;
            entityFromDb.Cover = cardToBeUpdated.Cover;
            entityFromDb.NegativeRate = cardToBeUpdated.NegativeRate;
            entityFromDb.PositiveRate = cardToBeUpdated.PositiveRate;
            db.Entry(entityFromDb).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Card toBeDeleted = db.Set<Card>().SingleOrDefault(x => x.Id == id);
            if (toBeDeleted != null)
                db.Set<Card>().Remove(toBeDeleted);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void AddCardMark(int cardId, int userId, bool markIsPositive)
        {
            db.Set<CardMark>().Add(new CardMark()
                {
                    CardId = cardId,
                    UserId = userId,
                    IsPositive = markIsPositive
                });
        }

        public void DeleteCardMark(int cardId, int userId)
        {
            IQueryable<CardMark> query = db.Set<CardMark>()
                .Where(c => (c.CardId == cardId) && (c.UserId == userId));
            db.Set<CardMark>().RemoveRange(query);
        }

        public bool CheckIfThisMarkWasAlreagyGiven(int cardId, int userId, bool markIsPositive)
        {
            IQueryable<CardMark> query = db.Set<CardMark>()
                .Where(c => (c.CardId == cardId)&&(c.UserId == userId)&&(c.IsPositive == markIsPositive));
            return query.Any();
        }

    }
}
