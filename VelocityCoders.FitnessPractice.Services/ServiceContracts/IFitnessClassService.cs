using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ComponentModel;
using VelocityCoders.FitnessPractice.Services.DataContracts;


namespace VelocityCoders.FitnessPractice.Services.ServiceContracts
{
    [ServiceContract]
    public interface IFitnessClassService
    {

        [Description("Get Fitness Class Item By Id")]
        [OperationContract]
        [WebGet(UriTemplate = "/Class/{fcId}", ResponseFormat = WebMessageFormat.Json)]
        FitnessClassDTO GetFitnessItem(string fcId);





        [Description("Get Fitness Collection")]
        [OperationContract]
        [WebGet(UriTemplate = "/Class/List/", ResponseFormat = WebMessageFormat.Json)]
        FitnessClassDTOCollection GetFitnessCollection();



        [Description("Get Fitness Class Collection by Instructor ID")]
        [OperationContract]
        [WebGet(UriTemplate = "/Class/List/{instructId}", ResponseFormat = WebMessageFormat.Json)]
        FitnessClassDTOCollection GetFitnessCollectionById(string instructId);





        [Description("Save Fitness Item")]
        [OperationContract]
        [WebInvoke(UriTemplate = "/Class/", Method = "PUT", RequestFormat = WebMessageFormat.Json)]
        int SaveFitnessItem(FitnessClassDTO dtoFitnessClass);

        [Description("Delete Fitness Item")]
        [OperationContract]
        [WebInvoke(UriTemplate = "/Class/{fcId}", Method = "DELETE", RequestFormat = WebMessageFormat.Json)]
        int DeleteFitnessItem(string fcId);

    }
}
