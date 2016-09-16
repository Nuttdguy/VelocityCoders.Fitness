using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using VelocityCoders.FitnessPractice.Services.DataContracts;
using VelocityCoders.FitnessPractice.Services.Faults;

namespace VelocityCoders.FitnessPractice.Services.ServiceContracts
{
    [ServiceContract]
    interface IEntityLookupService
    {
        #region Entity
        [OperationContract]
        EntityDTOCollection GetEntityCollection();

        #endregion

        #region EntityType

        [OperationContract]
        EntityTypeDTO GetEntityType(int entityTypeId);

        [OperationContract]
        EntityTypeDTOCollection GetEntityTypeCollection(int entityId);

        [OperationContract]
        [FaultContract(typeof(EntityLookupServiceFault))]
        void DeleteEntityType(int entityTypeId);

        [OperationContract]
        [FaultContract(typeof(EntityLookupServiceFault))]
        void SaveEntityType(EntityTypeDTO entityTypeToSave);

        #endregion


    }
}
