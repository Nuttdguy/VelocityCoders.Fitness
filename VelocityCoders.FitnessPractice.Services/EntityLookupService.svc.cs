using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using VelocityCoders.FitnessPractice.Services.ServiceContracts;
using VelocityCoders.FitnessPractice.Services.DataContracts;
using VelocityCoders.FitnessPractice.Services.Faults;
using VelocityCoders.FitnessPractice.BLL;
using VelocityCoders.FitnessPractice.Models;


namespace VelocityCoders.FitnessPractice.Services
{

    public class EntityLookupService : IEntityLookupService
    {

        #region SECTION 1 ||=======  GET  =======||
        public EntityDTOCollection GetEntityCollection()
        {
            EntityCollectionList entityCollection = EntityManager.GetCollection();
            return HydrateEntityDTO(entityCollection);
        }

        public EntityTypeDTO GetEntityType(int entityTypeId)
        {
            EntityType entityType = EntityTypeManager.GetItem(entityTypeId);
            return HydrateEntityTypeDTO(entityType);
        }

        public EntityTypeDTOCollection GetEntityTypeCollection(int entityId)
        {
            EntityTypeCollectionList entityTypeCollection = EntityTypeManager.GetCollection(entityId);
            return HydrateEntityTypeDTO(entityTypeCollection);
        }

        #endregion

        #region SECTION 2 ||=======  SAVE & DELETE  =======||

        public void DeleteEntityType(int entityTypdId)
        {
            if (entityTypdId > 0)
            {
                try
                {
                    if (!EntityTypeManager.Delete(entityTypdId))
                        throw new FaultException<EntityLookupServiceFault>(
                            new EntityLookupServiceFault("No records were affected."), "Delete Failed.");
                }
                catch (BLLException ex)
                {
                    throw new FaultException<EntityLookupServiceFault>(
                        new EntityLookupServiceFault(ex.Message), "Validation failed.");
                }
            }
            else
                throw new FaultException<EntityLookupServiceFault>(
                    new EntityLookupServiceFault("EntityTypeId wsa not valid."), "Validation failed");
        }

        public void SaveEntityType(EntityTypeDTO entityTypeToSave)
        {
            if (entityTypeToSave != null)
            {
                if (entityTypeToSave.EntityId > 0)
                {
                    if (string.IsNullOrEmpty(entityTypeToSave.EntityTypeName))
                        throw new FaultException<EntityLookupServiceFault>(
                            new EntityLookupServiceFault("EntityType value is required."), "Validation failed");
                    else
                    {
                        try
                        {
                            EntityTypeManager.Save(entityTypeToSave.EntityId, HydrateEntityType(entityTypeToSave));
                        }
                        catch (BLLException ex)
                        {
                            throw new FaultException<EntityLookupServiceFault>(
                                new EntityLookupServiceFault(ex.Message), "Save failed.");
                        }
                    }
                }
                else
                    throw new FaultException<EntityLookupServiceFault>(
                        new EntityLookupServiceFault("Entity Id is required."), "Validation failed");
            }
            else
                throw new FaultException<EntityLookupServiceFault>(
                    new EntityLookupServiceFault("EntityType Object was invalid"), "Validation failed");
        }

        #endregion

        #region SECTION 3 ||=======  HYDRATE OBJECTS  =======||

        #region COLLECTION ENTITY BO TO DTO
        private EntityDTOCollection HydrateEntityDTO(EntityCollectionList entityCollection)
        {
            EntityDTOCollection tempCollection = new EntityDTOCollection();

            if (entityCollection != null && entityCollection.Count > 0)
            {
                foreach (Entity item in entityCollection)
                {
                    if (!string.IsNullOrEmpty(item.EntityName))
                    {
                        EntityDTO temp = new EntityDTO()
                        {
                            EntityId = item.EntityId,
                            EntityName = item.EntityName
                        };

                        if (!string.IsNullOrEmpty(item.DisplayName))
                            temp.DisplayName = item.DisplayName;

                        tempCollection.Add(temp);
                    }
                    else
                        tempCollection.Add(new EntityDTO { EntityId = item.EntityId });
                }
            }
            return tempCollection;
        }

        #endregion

        #region ITEM ENTITY TYPE BO TO DTO
        private EntityTypeDTO HydrateEntityTypeDTO(EntityType entityType)
        {
            EntityTypeDTO tempItem = new EntityTypeDTO();

            if (entityType != null)
            {
                tempItem.EntityTypeId = entityType.EntityTypeId;

                if (!string.IsNullOrEmpty(entityType.EntityTypeName))
                    tempItem.EntityTypeName = entityType.EntityTypeName;
                if (!string.IsNullOrEmpty(entityType.DisplayName))
                    tempItem.DisplayName = entityType.DisplayName;
            }
            return tempItem;
        }

        #endregion

        #region COLLECTION ENTITY TYPE BO TO DTO
        private EntityTypeDTOCollection HydrateEntityTypeDTO(EntityTypeCollectionList entityTypeCollection)
        {
            EntityTypeDTOCollection tempCollection = new EntityTypeDTOCollection();

            if (entityTypeCollection != null && entityTypeCollection.Count > 0)
            {
                foreach (EntityType item in entityTypeCollection)
                {
                    if (!string.IsNullOrEmpty(item.EntityTypeName))
                    {
                        EntityTypeDTO temp = new EntityTypeDTO()
                        {
                            EntityTypeId = item.EntityTypeId,
                            EntityTypeName = item.EntityTypeName
                        };

                        if (!string.IsNullOrEmpty(item.DisplayName))
                            temp.DisplayName = item.DisplayName;

                        tempCollection.Add(temp);
                    }
                    else
                        tempCollection.Add(new EntityTypeDTO { EntityTypeId = item.EntityTypeId });
                }
            }
            return tempCollection;
        }

        #endregion

        #region ITEM ENTITY TYPE DTO TO BO
        private EntityType HydrateEntityType(EntityTypeDTO entityTypeDTO)
        {
            EntityType tempItem = new EntityType();

            if (entityTypeDTO != null)
            {
                tempItem.EntityTypeId = entityTypeDTO.EntityTypeId;

                if (!string.IsNullOrEmpty(entityTypeDTO.EntityTypeName))
                    tempItem.EntityTypeName = entityTypeDTO.EntityTypeName;

                if (!string.IsNullOrEmpty(entityTypeDTO.DisplayName))
                    tempItem.DisplayName = entityTypeDTO.DisplayName;
            }
            return tempItem;
        }

        #endregion

        #endregion

    }
}
