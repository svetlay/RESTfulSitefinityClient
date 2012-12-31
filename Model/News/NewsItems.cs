using System;
using System.Linq;
using System.Runtime.Serialization;

namespace SFWinformsClient.Model.News
{
    [DataContract]
    class NewsItems
    {
        [DataMember]
        public NewsItem[] Items { get; set; }
    }

    //A single News Item
    [DataContract]
    public class NewsItem
    {
        [DataMember]
        public string Title { get; set; }//the title as a string

        public override string ToString()
        {
            return this.Title;
        }
    }
}