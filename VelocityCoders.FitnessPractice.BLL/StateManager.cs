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
            BrokenRuleCollection saveBrokenRules = new BrokenRuleCollection();

            if (stateId <= 0)
            {
                saveBrokenRules.Add("Error", "Invalid State ID: " + stateId);
                throw new BLLException("Error", saveBrokenRules);
            }

            State stateItem = StateDAL.GetItem(stateId);

            if (stateItem == null)
            {
                saveBrokenRules.Add("No records were found. ");
                throw new BLLException("Error", saveBrokenRules);
            }

            return stateItem;
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
