using System.ServiceModel;
using System.ComponentModel;
using System.ServiceModel.Web;
using VelocityCoders.FitnessPractice.Services.DataContracts;


namespace VelocityCoders.FitnessPractice.Services.ServiceContracts
{
    [ServiceContract]
    public interface IStateService
    {
        [Description("Get Collection of States")]
        [OperationContract]
        [WebGet(UriTemplate = "/State/", ResponseFormat = WebMessageFormat.Json)]
        StateDTOCollection GetCollection();

        [Description("Get State Item by StateId")]
        [OperationContract]
        [WebGet(UriTemplate = "/State/{stateId}", ResponseFormat = WebMessageFormat.Json)]
        StateDTO GetItem(string stateId);

        [Description("Delete State Item by StateId")]
        [OperationContract]
        [WebInvoke(UriTemplate = "/State/{stateId}", Method = "DELETE", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int DeleteItem(string stateId);

        [Description("Save Item")]
        [OperationContract]
        [WebInvoke(UriTemplate = "/State/", Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        StateDTO SaveItem(StateDTO stateDTO);

    }
}