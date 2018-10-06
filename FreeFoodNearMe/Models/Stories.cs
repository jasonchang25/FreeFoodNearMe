using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace FreeFoodNearMe.Models
{
    public class Stories
    {
        public Stories()
        {
            Type = "Story";
            ServiceId = "";
            PostDate = DateTime.Now.ToString();
            displayName = "";
            StoryContent = "";
        }


        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "serviceId")]
        public string ServiceId { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "postDate")]
        public string PostDate { get; set; }

        [JsonProperty(PropertyName = "displayName")]
        public string displayName { get; set; }

        [JsonProperty(PropertyName = "storyContent")]
        public string StoryContent { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}