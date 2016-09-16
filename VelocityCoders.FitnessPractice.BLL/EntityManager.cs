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
            EntityCollectionList entityTypeCollection = EntityDAL.GetCollection(entityId);
            return entityTypeCollection;
        }

        #endregion

        #endregion



    }
}
