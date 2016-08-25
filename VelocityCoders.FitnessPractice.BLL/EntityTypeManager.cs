using System;
using VelocityCoders.FitnessPractice.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityCoders.FitnessPractice.BLL
{
    public static class EntityTypeManager
    {

        #region RETRIEVE SINGLE ITEM
        public static EntityType GetItem(int EntityTypeId)
        {
            //== Call DAL to retrieve item by Id
            return new EntityType { };
        }
        #endregion

        #region RETRIEVE COLLECTION
        public static EntityTypeCollectionList GetCollection(EntityEnum entityName)
        {
            //== Call DAL to retrieve Collection
            return new EntityTypeCollectionList { };
        }

        #endregion


    }
}
