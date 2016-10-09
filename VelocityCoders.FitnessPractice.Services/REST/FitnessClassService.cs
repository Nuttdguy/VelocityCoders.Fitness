using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.BLL;
using VelocityCoders.FitnessPractice.Services.DataContracts;
using VelocityCoders.FitnessPractice.Services.ServiceContracts;

namespace VelocityCoders.FitnessPractice.Services.REST
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class FitnessClassService : IFitnessClassService
    {

        #region SECTION 1 ||=======  GET SINGLE FITNESS ITEM  =======||
        public FitnessClassDTO GetFitnessItem(string fcId)
        {
            FitnessClass tmpItem = FitnessClassManager.GetFitnessClassItem(fcId.ToInt());
            return itemToDto(tmpItem);
        }

        #endregion

        #region SECTION 2 ||=======  GET COLLECTION OF FITNESS ITEMS  =======||


        public FitnessClassDTOCollection GetFitnessCollection()
        {
            FitnessClassCollectionList tmpCollect = FitnessClassManager.GetFitnessClassCollection();
            return itemToDtoCollection(tmpCollect);
        }

        public FitnessClassDTOCollection GetFitnessCollectionById(string instructId)
        {
            FitnessClassCollectionList tmpCollect = FitnessClassManager.GetFitnessClassCollection(instructId.ToInt());
            return itemToDtoCollection(tmpCollect);
        }

        #endregion

        #region SECTION 3 ||=======  SAVE SINGLE FITNESS ITEM  =======||
        public int SaveFitnessItem(FitnessClassDTO dtoFitnessClass)
        {
            int saveId = FitnessClassManager.SaveItem(dtoToItem(dtoFitnessClass));
            return saveId;
        }

        #endregion

        #region SECTION 4 ||=======  DELETE SINGLE FITNESS ITEM  =======||
        public int DeleteFitnessItem(string fcId)
        {
            int deleteId = FitnessClassManager.DeleteItem(fcId.ToInt());
            return deleteId;
        }

        #endregion


        #region SECTION 5 ||=======  HYDRATE DATA  =======||

        #region ||=======  DTO TO ITEM | [ INCOMING ]  =======||
        private static FitnessClass dtoToItem(FitnessClassDTO dtoFitnessClass)
        {
            FitnessClass tmpItem = new FitnessClass
            {
                FitnessClassId = dtoFitnessClass.FitnessClassId,
                FitnessClassName = dtoFitnessClass.FitnessClassName,
                Description = dtoFitnessClass.Description
            };

            return tmpItem;
            
        }
        #endregion

        #region ||=======  ITEM TO DTO | [ OUTGOING ]  =======||
        private static FitnessClassDTO itemToDto(FitnessClass itemToDto)
        {
            FitnessClassDTO tmpDtoItem = new FitnessClassDTO
            {
                FitnessClassId = itemToDto.FitnessClassId,
                FitnessClassName = itemToDto.FitnessClassName,
                Description = itemToDto.Description
            };
            return tmpDtoItem;
        }
        #endregion

        #region ||=======  ITEM TO DTO COLLECTION | [ OUTGOING ]  =======||
        private FitnessClassDTOCollection itemToDtoCollection(FitnessClassCollectionList fcCollection)
        {
            FitnessClassDTOCollection tmpCollect = new FitnessClassDTOCollection();

            if (fcCollection != null)
            {
                foreach(FitnessClass item in fcCollection)
                {
                    tmpCollect.Add(itemToDto(item));
                }
            }

            return tmpCollect;
        }

        #endregion

        #endregion

    }
}