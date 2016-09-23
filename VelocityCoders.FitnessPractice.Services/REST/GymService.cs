using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.BLL;
using System.ServiceModel.Activation;
using VelocityCoders.FitnessPractice.Services.DataContracts;
using VelocityCoders.FitnessPractice.Services.ServiceContracts;


namespace VelocityCoders.FitnessPractice.Services.REST
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class GymService : IGymService
    {
        #region ||=======  GET GYM ITEM |  BY GYM-ID  =======|| 
        public GymDTO GetGym(string gymId)
        {
            Gym gymObj = GymManager.GetItem(gymId.ToInt());
            return GymItemToDTO(gymObj);
        }
        #endregion

        #region ||=======  GET GYM COLLECTION |  ALL  =======||
        public GymDTOCollection GetGymCollection()
        {
            GymCollection gymList = GymManager.GetCollection();
            return GymCollectionToDTO(gymList);
        }
        #endregion

        #region ||=======  SAVE GYM ITEM |  BY GYM-ID  =======||
        public GymDTO SaveGym(GymDTO gymToSave)
        {
            int gymId = GymManager.SaveItem(DTOToGym(gymToSave));

            Gym updateItem = GymManager.GetItem(gymId);
            return GymItemToDTO(updateItem);
        }
        #endregion

        #region ||=======  DELETE GYM ITEM | BY GYM-ID  ======||
        public bool DeleteGym(string gymId)
        {
            return GymManager.DeleteItem(gymId.ToInt());
        }
        #endregion

        //==============================================================

        #region SECTION ?? ||=======  HYDATE OBJECTS AND DTO  =======||
        
        #region ||=======  GYM DTO TO GYM ITEM  =======||
        private Gym DTOToGym(GymDTO gymDTO)
        {
            Gym tmpObj = new Gym();

            if (gymDTO != null)
            {
                tmpObj.GymId = gymDTO.GymId;

                if (!string.IsNullOrEmpty(gymDTO.GymName))
                    tmpObj.GymName = gymDTO.GymName;

                if (!string.IsNullOrEmpty(gymDTO.GymAbbreviation))
                    tmpObj.GymAbbreviation = gymDTO.GymAbbreviation;

                if (!string.IsNullOrEmpty(gymDTO.Website))
                    tmpObj.Website = gymDTO.Website;

                if (!string.IsNullOrEmpty(gymDTO.Description))
                    tmpObj.Description = gymDTO.Description;
            }
            return tmpObj;
        }
        #endregion

        #region ||=======  GYM COLLECTION TO GYM DTO COLLECTION  =======||
        private GymDTOCollection GymCollectionToDTO(GymCollection gymCollection)
        {
            GymDTOCollection tmpList = new GymDTOCollection();

            if (gymCollection != null)
            {
                foreach (Gym item in gymCollection)
                {
                    tmpList.Add(GymItemToDTO(item));
                }
            }
            return tmpList;
        }
        #endregion

        #region ||=======  GYM ITEM TO GYM DTO ITEM  =======||
        public GymDTO GymItemToDTO(Gym gymObj)
        {
            GymDTO tmpItem = new GymDTO();

            if (gymObj != null)
            {
                tmpItem.GymId = gymObj.GymId;

                if (!string.IsNullOrEmpty(gymObj.GymName))
                    tmpItem.GymName = gymObj.GymName;

                if (!string.IsNullOrEmpty(gymObj.GymAbbreviation))
                    tmpItem.GymAbbreviation = gymObj.GymAbbreviation;

                if (!string.IsNullOrEmpty(gymObj.Website))
                    tmpItem.Website = gymObj.Website;

                if (!string.IsNullOrEmpty(gymObj.Description))
                    tmpItem.Description = gymObj.Description;
            }
            return tmpItem;
        }
        #endregion

        #endregion
    }
}

