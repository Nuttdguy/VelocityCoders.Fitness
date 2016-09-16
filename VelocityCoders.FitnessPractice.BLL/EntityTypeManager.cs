using System;
using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.DAL;


namespace VelocityCoders.FitnessPractice.BLL
{
    public static class EntityTypeManager
    {

        #region SECTION 1 ||=======  GET ITEM  =======||

        #region ||=======  [METHOD] GET ITEM | BY ENTITY-TYPE-ID  =======||
        public static EntityType GetItem(int entityTypeId)
        {
            BrokenRuleCollection saveBrokenRules = new BrokenRuleCollection();

            //=======  CHECKS FOR A VALID INTEGER  =======\\
            if (entityTypeId <= 0)
            {
                saveBrokenRules.Add("Entity Type", "Invalid ID: " + entityTypeId.ToString());

                throw new BLLException("There was an error retrieving Entity Type.", saveBrokenRules);
            }

            //=======  RETRIEVE RECORD FROM DAL  =======\\
            EntityType item = EntityTypeDAL.GetItem(entityTypeId);

            //=======  VALIDATE AN OBJECT WAS RETURNED  =======\\
            if (item == null)
            {
                saveBrokenRules.Add("Entity Type", "Could not retrieve record with ID: " + entityTypeId.ToString());

                throw new BLLException("Error: No record found.", saveBrokenRules);
            }
            else
                return item;
        }

        #endregion

        #endregion


        #region SECTION 2 ||=======  GET COLLECTION  =======||

        #region  ||=======  [METHOD] GET COLLECTION | BY EMPLOYEE-TYPE  =======||

        public static EntityTypeCollectionList GetCollection(EntityIdEnum employeeType, SelectEnum entityType)
        {

            EntityTypeCollectionList entityTypeCollection = EntityTypeDAL.GetCollection(employeeType, entityType);
            return entityTypeCollection;
        }

        #region  ||=======  [METHOD] GET COLLECTION | BY EMPLOYEE-TYPE  =======||

        public static EntityTypeCollectionList GetCollection(int entityId)
        {

            EntityTypeCollectionList entityTypeCollection = EntityTypeDAL.GetCollection(entityId);
            return entityTypeCollection;
        }
        #endregion

        #endregion

        #region  ||=======  [METHOD] GET COLLECTION | ALL  =======||
        public static EntityTypeCollectionList GetCollection()
        {

            EntityTypeCollectionList entityTypeCollection = EntityTypeDAL.GetCollection();
            return entityTypeCollection;
        }

        #endregion

        #endregion


        #region SECTION 3 ||======= INSERT / UPDATE  =======||

        #region ||=======  [METHOD] INSERT INTO / UPDATE | BY ENTITY-ID, ENTITY-TYPE-CLASS  =======||
        public static int Save(int entityId, EntityType entityTypeToSave)
        {
            BrokenRuleCollection saveBrokenRules = new BrokenRuleCollection();

            if (entityId <= 0)
                saveBrokenRules.Add("Entity", "Invalid ID for Entity Relationship.");

            if (string.IsNullOrEmpty(entityTypeToSave.EntityTypeName))
                saveBrokenRules.Add("Entity Type Name", "Name is required");

            if (saveBrokenRules.Count > 0)
            {
                throw new BLLException("There was an error saving Entity Type.", saveBrokenRules);
            }
            else
            {
                return EntityTypeDAL.Save(entityId, entityTypeToSave);
            }
        }


        #endregion

        #endregion


        #region SECTION 4 ||=======  DELETE  =======||

        #region ||=======  [METHOD] DELETE ITEM  =======||
        public static bool Delete(int entityTypeId)
        {
            if (entityTypeId > 0)
                return EntityTypeDAL.Delete(entityTypeId);
            else
                throw new BLLException("Delete failed. Entity Type ID is invalid: " + entityTypeId.ToString());
        }

        #endregion

        #endregion

    }
}
