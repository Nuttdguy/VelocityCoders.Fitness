using System;
using System.Collections.Generic;
using System.ServiceModel.Activation;
using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.BLL;
using VelocityCoders.FitnessPractice.Services.DataContracts;
using VelocityCoders.FitnessPractice.Services.ServiceContracts;



namespace VelocityCoders.FitnessPractice.Services.REST
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class InstructorService : IInstructorService
    {

        #region SECTION 1 ||=======  GET INSTRUCTOR ITEM  =======||
        public InstructorDTO GetInstructorItem(string id)
        {
            Instructor tmpItem = InstructorManager.GetInstructorItem(id.ToInt());
            return itemToDto(tmpItem);
        }
        #endregion

        #region SECTION 2 ||=======  ASSOCIATE FITNESS CLASS TO INSTRUCTOR  =======||
        public int AddFitnessClass(string instructorId, string fitnessClassId)
        {
            return InstructorManager.AddFitnessClass(instructorId.ToInt(), fitnessClassId.ToInt());

        }

        #endregion

        #region SECTION 3 ||=======  DELETE ASSOCIATION BETWEEN INSTRUCTOR AND FITNESS CLASS
        public bool DeleteFitnessClass(string instructorFitnessClassId)
        {
            return InstructorManager.DeleteFitnessClass(instructorFitnessClassId.ToInt());
        }
        #endregion


        #region SECTION 3 ||=======  HYDRATE DTO/ITEM  =======||
        private InstructorDTO itemToDto(Instructor instructItem)
        {
            InstructorDTO dtoItem = new InstructorDTO
            {
                InstructorId = instructItem.InstructorId,
                FirstName = instructItem.FirstName,
                LastName = instructItem.LastName
            };

            return dtoItem;
        }


        private Instructor dtoToItem(InstructorDTO instructDto)
        {
            Instructor tmpItem = new Instructor
            {
                InstructorId = instructDto.InstructorId,
                FirstName = instructDto.FirstName,
                LastName = instructDto.LastName
            };

            return tmpItem;
        }

        #endregion

    }
}