using System;
using System.Collections.Generic;
using BusinessLogicLayerInterface.BLLModel;

namespace BusinessLogicLayerInterface.ServiceInterfaces
{
    public interface ICardService: IEntityService<BllCard>
    {
        IEnumerable<BllCard> GetCardsWithGivenParameters(string title = null, 
                                                         string description = null, 
                                                         DateTime dateOfCreation = default(DateTime),
                                                         int categoryId = -1,
                                                         int authorId = -1);

        void Create(string title, string description, DateTime dateOfCreation, string cover, int categoryId, int authorId);
        bool CheckIfAlreadyMarkedPositively(int cardId, int userId);
        bool CheckIfAlreadyMarkedNegatively(int cardId, int userId);
        void EstimateCard(int cardId, int userId, bool markIsPositive);
    }
}
