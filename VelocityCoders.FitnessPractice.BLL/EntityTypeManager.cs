using System;
using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.DAL;


namespace VelocityCoders.FitnessPractice.BLL
{
    public static class EntityTypeManager
    {

        #region RETRIEVE SINGLE ITEM
        public static EntityType GetItem(int entityTypeId)
        {
            EntityType myEntityType = EntityTypeDAL.GetItem(entityTypeId);
            return myEntityType;
        }
        #endregion

        #region RETRIEVE COLLECTION BY ENTITY TYPE
        public static EntityTypeCollectionList GetCollection(EntityNames entityNameById, QuerySelectType queryId)
        {

            EntityTypeCollectionList entityTypeCollection = EntityTypeDAL.GetCollection((int)entityNameById, (int)queryId);
            return entityTypeCollection;
        }
        #endregion


        #region GET_COLLECTION W/OUT PARAMETER
        public static EntityTypeCollectionList GetCollection()
        {
            //== Call DAL to retrieve Collection
            return new EntityTypeCollectionList { };
        }

        #endregion


    }
}
