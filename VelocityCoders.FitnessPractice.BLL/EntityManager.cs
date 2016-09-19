using System;
using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityCoders.FitnessPractice.BLL
{
    public static class EntityManager
    {

        #region SECTION 1 ||=======  GET ITEM  =======||
        public static Entity GetItem(int entityId)
        {
            return EntityDAL.GetItem(entityId);
        }

        #endregion

        #region SECTION 2 ||=======  GET COLLECTION =======||

        #region ||=======  [METHOD] GET COLLECTION | ALL  =======||
        public static EntityCollectionList GetCollection()
        {
            return EntityDAL.GetCollection();
        }
        #endregion

        #region ||=======  [METHOD] GET COLLECTION | BY ENTITY-ID  =======||
        public static EntityCollectionList GetCollection(int entityId)
        {
            EntityCollectionList entityCollection = EntityDAL.GetCollection(entityId);
            return entityCollection;
        }

        #endregion

        #endregion

        #region SECTION 3 ||=======  DELETE ITEM  =======||
        #region ||=======  DELETE ENTITY ITEM | BY ENTITY-ID  =======||
        public static bool Delete(int entityId)
        {
            return EntityDAL.DeleteItem(entityId);
        }
        #endregion

        #endregion

        #region SECTION 4 ||=======  SAVE ITEM  =======||

        #region ||========  SAVE ENTITY ITEM  =======||
        public static void Save(int entityId, Entity entity)
        {
            EntityDAL.Save(entityId, entity);
        }
        #endregion

        #endregion
    }
}
