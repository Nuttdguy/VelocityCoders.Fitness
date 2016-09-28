using VelocityCoders.FitnessPractice.BLL;
using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.Services.ServiceContracts;
using VelocityCoders.FitnessPractice.Services.DataContracts;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;

namespace VelocityCoders.FitnessPractice.Services.REST
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class StateService : IStateService
    {

        #region SECTION 1 ||=======  GET ITEM  =======||

        #region ||=======  GET STATE ITEM | BY STATE-ID  =======||
        public StateDTO GetItem(string stateId)
        {
            State tmpItem = StateManager.GetItem(stateId.ToInt());
            return StateToDTO(tmpItem);
        }
        #endregion

        #endregion

        #region SECTION 2 ||=======  GET COLLECTION  =======||

        #region ||=======  GET STATE COLLECTION | ALL  =======||
        public StateDTOCollection GetCollection()
        {
            StateCollection tmpCollection = StateManager.GetCollection();
            return StateCollectionToDTO(tmpCollection);
        }
        #endregion

        #endregion

        #region SECTION 3 ||=======  SAVE  =======||

        #region ||=======  SAVE STATE  =======||
        public StateDTO SaveItem(StateDTO stateDTO)
        {
            
            int stateId = StateManager.SaveItem(DTOToState(stateDTO));
            State tmpItem = StateManager.GetItem(stateId);
            return StateToDTO(tmpItem);

        }
        #endregion

        #endregion

        #region SECTION 4 ||=======  DELETE  =======||

        #region ||=======  DELETE STATE  | BY STATE-ID  =======||
        public int DeleteItem(string stateId)
        {
            return StateManager.DeleteItem(stateId.ToInt());
        }
        #endregion

        #endregion


        #region SECTION 5 ||=======  HYDRATE OBJECT  =======||

        #region ||=======  STATE-DTO TO STATE-ITEM | INCOMING  =======||
        private State DTOToState(StateDTO stateDTO)
        {
            State tmpObj = new State();

            tmpObj.StateId = stateDTO.StateId;
            tmpObj.StateName = stateDTO.StateName;
            tmpObj.ShortName = stateDTO.ShortName;
            //==  NOTES: THROWS ERROR IF ABBREVIATION IS > 2 ==\\
            tmpObj.StateAbbreviation = stateDTO.StateAbbreviation.ToString();

            return tmpObj;
        }
        #endregion

        #region ||=======  STATE-ITEM TO DTO | OUTGOING  =======||
        private StateDTO StateToDTO(State state)
        {
            StateDTO tmpObj = new StateDTO();

            tmpObj.StateId = state.StateId;
            tmpObj.StateName = state.StateName;
            tmpObj.StateAbbreviation = state.StateAbbreviation;
            tmpObj.ShortName = state.ShortName;

            return tmpObj;
        }
        #endregion

        #region ||=======  STATE-COLLECTION TO DTO | OUTGOING  =======||
        private StateDTOCollection StateCollectionToDTO(StateCollection stateCollection)
        {
            StateDTOCollection tmpCollection = new StateDTOCollection();

            if (stateCollection != null)
            {
                foreach (State item in stateCollection)
                {
                    tmpCollection.Add(StateToDTO(item));
                }
            }

            return tmpCollection;
        }

        #endregion

        #endregion


    }
}