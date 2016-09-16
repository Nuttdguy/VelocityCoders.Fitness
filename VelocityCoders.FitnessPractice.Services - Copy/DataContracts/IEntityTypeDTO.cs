using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace VelocityCoders.FitnessPractice.Services.DataContracts
{

    [ServiceContract]
    public interface IEntityTypeDTO
    {
        [OperationContract]
        void DoWork();
    }
}
