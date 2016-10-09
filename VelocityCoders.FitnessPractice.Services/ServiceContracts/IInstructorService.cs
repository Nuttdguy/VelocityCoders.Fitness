using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel.Web;
using System.ServiceModel;
using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.Services.DataContracts;


namespace VelocityCoders.FitnessPractice.Services.ServiceContracts
{
    [ServiceContract]
    public interface IInstructorService
    {

        [Description("Get Instructor Item ")]
        [OperationContract]
        [WebGet(UriTemplate = "/Detail/{id}")]
        InstructorDTO GetInstructorItem(string id);

        [Description("Associate an Instructor with a fitness class. Returns InstructorFitnessClass Id.")]
        [OperationContract]
        [WebInvoke(UriTemplate = "/Detail/{instructorId}", Method = "PUT", RequestFormat = WebMessageFormat.Json)]
        int AddFitnessClass(string instructorId, string fitnessClassId);

        [Description("Delete association between instructor and fitness class.")]
        [OperationContract]
        [WebInvoke(UriTemplate = "/Detail/{instructorFitnessClassId}", Method = "DELETE", RequestFormat = WebMessageFormat.Json)]
        bool DeleteFitnessClass(string instructorFitnessClassId);

    }
}
