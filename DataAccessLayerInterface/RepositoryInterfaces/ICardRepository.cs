using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterface.DALModel;

namespace DataAccessLayerInterface.RepositoryInterfaces
{
    public interface ICardRepository : IRepository<DalCard>
    {
        IEnumerable<DalCard> GetCardWithGivenParameters(DalCard sampleCard);
        void AddCardMark(int cardId, int userId, bool markIsPositive);
        void DeleteCardMark(int cardId, int userId);
        bool CheckIfThisMarkWasAlreagyGiven(int cardId, int userId, bool markIsPositive);
    }
}
