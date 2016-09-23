using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web;
using System.ComponentModel;
using System.ServiceModel.Web;
using VelocityCoders.FitnessPractice.Services.DataContracts;


namespace VelocityCoders.FitnessPractice.Services.ServiceContracts
{
    [ServiceContract]
    interface IGymService
    {

        #region ||=======  GET GYM DTO COLLECTION  | ALL  =======||
        [Description("Gets a collection of gym records in JSON format.")]
        [OperationContract]
        [WebGet(UriTemplate="Gym/Collection/", RequestFormat = WebMessageFormat.Json)]
        GymDTOCollection GetGymCollection();
        #endregion

        #region ||=======  GET GYM ITEM DTO | BY GYM-ID  =======||
        [Description("Gets the single instance of a gym. Pass in the GymId as a parameter.")]
        [OperationContract]
        [WebGet(UriTemplate="Gym/Item/{gymId}", RequestFormat = WebMessageFormat.Json)]
        GymDTO GetGym(string gymId);
        #endregion

        #region ||=======  DELETE GYM DTO ITEM | BY GYM-ID  =======|| 
        [Description("Deletes a gym.")]
        [WebInvoke(UriTemplate="Gym/Item/{gymId}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool DeleteGym(string gymId);
        #endregion

        #region ||=======  SAVE GYM DTO ITEM |  BY GYM-ID  =======||
        [Description("Saves a gym record.")]
        [OperationContract]
        [WebInvoke(UriTemplate="Gym/Item/", Method = "PUT", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        GymDTO SaveGym(GymDTO gymToSave);
        #endregion

    }
}
