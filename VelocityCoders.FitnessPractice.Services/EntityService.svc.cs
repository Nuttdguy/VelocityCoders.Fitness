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
   
    public class EntityService : IEntityService
    {

        #region SECTION 1 ||=======  GET  =======||

        #region ||=======  GET ENTITY | BY ENTITY-ID  =======||
        public EntityDTO GetEntity(int entityId)
        {
            Entity entity = EntityManager.GetItem(entityId);
            return HydrateEntityDTO(entity);
        }
        #endregion

        #region ||=======  GET ENTITY COLLECTION | ALL  =======||
        public EntityDTOCollection GetEntityCollection()
        {
            EntityCollectionList entityCollection = EntityManager.GetCollection();
            return HydrateEntityDTO(entityCollection);
        }
        #endregion


        #endregion

        #region SECTION 2 ||=======  SAVE & DELETE  =======||

        #region ||=======  DELETE | BY ENTITY-ID  =======||
        public void DeleteEntity(int entityId)
        {
            if (entityId > 0)
            {
                try
                {
                    if (!EntityManager.Delete(entityId))
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
                    new EntityLookupServiceFault("EntityId was not valid."), "Validation failed");
        }

        #endregion

        #region ||=======  SAVE ENTITY  =======||
        public void SaveEntity(EntityDTO entityToSave)
        {
            if (entityToSave != null)
            {

                if (string.IsNullOrEmpty(entityToSave.EntityName))
                    throw new FaultException<EntityLookupServiceFault>(
                        new EntityLookupServiceFault("Entity value is required."), "Validation failed");
                else
                {
                    try
                    {
                        EntityManager.Save(entityToSave.EntityId, HydrateEntity(entityToSave));
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
                    new EntityLookupServiceFault("Entity Object was invalid"), "Validation failed");
        }

        #endregion

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

                        if (!string.IsNullOrEmpty(item.Description))
                            temp.Description = item.Description;

                        tempCollection.Add(temp);
                    }
                    else
                        tempCollection.Add(new EntityDTO { EntityId = item.EntityId });
                }
            }
            return tempCollection;
        }

        #endregion

        #region ITEM ENTITY BO TO DTO
        private EntityDTO HydrateEntityDTO(Entity entity)
        {
            EntityDTO tempItem = new EntityDTO();

            if (entity != null)
            {
                tempItem.EntityId = entity.EntityId;

                if (!string.IsNullOrEmpty(entity.EntityName))
                    tempItem.EntityName = entity.EntityName;
                if (!string.IsNullOrEmpty(entity.DisplayName))
                    tempItem.DisplayName = entity.DisplayName;
                if (!string.IsNullOrEmpty(entity.Description))
                    tempItem.Description = entity.Description;
            }
            return tempItem;
        }

        #endregion

        #region ITEM ENTITY TYPE DTO TO BO
        private Entity HydrateEntity(EntityDTO entityDTO)
        {
            Entity tempItem = new Entity();

            if (entityDTO != null)
            {
                tempItem.EntityId = entityDTO.EntityId;

                if (!string.IsNullOrEmpty(entityDTO.EntityName))
                    tempItem.EntityName = entityDTO.EntityName;

                if (!string.IsNullOrEmpty(entityDTO.DisplayName))
                    tempItem.DisplayName = entityDTO.DisplayName;

                if (!string.IsNullOrEmpty(entityDTO.Description))
                    tempItem.Description = entityDTO.Description;
            }
            return tempItem;
        }

        #endregion

        #endregion
    }
}
