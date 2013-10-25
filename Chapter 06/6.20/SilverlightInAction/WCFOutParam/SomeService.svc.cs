using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Collections.Generic;
using System.Text;

namespace WCFOutParam
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class SomeService
    {
        [OperationContract]
        string GetSomeData(int Id, out MyErrorObject myError)
        {
            myError = null;
            return "It Worked";
        }
    }

    [DataContract]
    public class MyErrorObject
    {
        [DataMember]
        public string Message { get; set; }
    }
}
