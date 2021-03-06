﻿using System.ServiceModel;
using System.ComponentModel;
using System.ServiceModel.Web;
using VelocityCoders.FitnessPractice.Services.DataContracts;

namespace VelocityCoders.FitnessPractice.Services.ServiceContracts
{
    [ServiceContract]
    interface ILocationService
    {

        #region ||=======  GET LOCATION DTO COLLECTION |  ALL  =======||
        [Description("Get the collection of Gym location")]
        [OperationContract]
        [WebGet(UriTemplate = "/Location/", ResponseFormat = WebMessageFormat.Json)]
        LocationDTOCollection GetCollection();
        #endregion

        #region ||=======  GET LOCATION DTO ITEM | BY GYM-ID  =======||
        [Description("Get Location item by GymId")]
        [OperationContract]
        [WebGet(UriTemplate = "/Location/{GymId}", ResponseFormat = WebMessageFormat.Json)]
        LocationDTO GetItem(string GymId);
        #endregion

        #region ||=======  DELETE LOCATION DTO ITEM | BY LOCATION-ID  =======||
        [Description("Delete Location by LocationId")]
        [OperationContract]
        [WebInvoke(UriTemplate = "/Location/{LocationId}", Method = "DELETE", RequestFormat = WebMessageFormat.Json)]
        int DeleteItem(string locationId);
        #endregion

        #region ||=======  SAVE LOCATION DTO ITEM  =======||
        [Description("Save Location ")]
        [OperationContract]
        [WebInvoke(UriTemplate = "/Location/", Method = "PUT", RequestFormat = WebMessageFormat.Json)]
        LocationDTO SaveItem(LocationDTO locationDTO);
        #endregion

    }
}
