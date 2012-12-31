using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SFWinformsClient.Model.Roles
{
    [DataContract]
    class Role
    {
        [DataMember]
        public object Context { get; set; }
        [DataMember]
        public bool IsGeneric { get; set; }
        [DataMember]
        public List<RoleItem> Items { get; set; }
        [DataMember]
        public int TotalCount { get; set; }
    }

    [DataContract]

    class RoleItem
    {
                [DataMember]
            public string ProviderName { get; set; }
                [DataMember]
            public string Id { get; set; }
                    [DataMember]
            public string Name { get; set; }
                
        public override string  ToString()
{
 	 return this.Name;
}
        }


  
    
}
