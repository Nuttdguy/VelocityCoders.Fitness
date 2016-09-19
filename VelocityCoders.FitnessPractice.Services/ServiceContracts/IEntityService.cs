using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using VelocityCoders.FitnessPractice.Services.DataContracts;
using VelocityCoders.FitnessPractice.Services.Faults;

namespace VelocityCoders.FitnessPractice.Services.ServiceContracts
{
    [ServiceContract]
    interface IEntityService
    {
        #region Entity

        [OperationContract]
        EntityDTO GetEntity(int entityId);

        [OperationContract]
        EntityDTOCollection GetEntityCollection();

        [OperationContract]
        [FaultContract(typeof(EntityLookupServiceFault))]
        void DeleteEntity(int entityId);

        [OperationContract]
        [FaultContract(typeof(EntityLookupServiceFault))]
        void SaveEntity(EntityDTO entityToSave);

        #endregion
    }
}
