using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.DAL;


namespace VelocityCoders.FitnessPractice.BLL
{
    public static class StateManager
    {

        #region SECTION 1 ||=======  GET ITEM  =======||
        #region ||=======  GET ITEM | BY STATE-ID  =======||
        public static State GetItem(int stateId)
        {
            return StateDAL.GetItem(stateId);
        }
        #endregion
        #endregion

        #region SECTION 2 ||=======  GET COLLECTION  =======||
        #region ||=======  GET COLLECTION | ALL =======||
        public static StateCollection GetCollection()
        {
            return StateDAL.GetCollection();
        }
        #endregion
        #endregion

    }
}
