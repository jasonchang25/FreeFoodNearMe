using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace FreeFoodNearMe.Models
{
    public class Service
    {
        public Service()
        {
            Type = "Service";
            ServiceName = "";
            Website = "";
            CompanyName = "";
            Address = "";
            Suburb = "";
            PostCode = "";
            State = "";
            Lat = "";
            Lng = "";
            ContactNumber = "";
            ServiceDescription = "";
            ServiceType = "";
            DateStart = "";
            DateEnd = "";
            SundayStart = "Closed";
            SundayEnd = "Closed";
            MondayStart = "Closed";
            MondayEnd = "Closed";
            TuesdayStart = "Closed";
            TuesdayEnd = "Closed";
            WednesdayStart = "Closed";
            WednesdayEnd = "Closed";
            ThursdayStart = "Closed";
            ThursdayEnd = "Closed";
            FridayStart = "Closed";
            FridayEnd = "Closed";
            SaturdayStart = "Closed";
            SaturdayEnd = "Closed";
        }


        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "serviceName")]
        public string ServiceName { get; set; }

        [JsonProperty(PropertyName = "website")]
        public string Website { get; set; }

        [JsonProperty(PropertyName = "companyName")]
        public string CompanyName { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "suburb")]
        public string Suburb { get; set; }

        [JsonProperty(PropertyName = "postCode")]
        public string PostCode { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "lat")]
        public string Lat { get; set; }

        [JsonProperty(PropertyName = "lng")]
        public string Lng { get; set; }

        [JsonProperty(PropertyName = "contactNumber")]
        public string ContactNumber { get; set; }

        [JsonProperty(PropertyName = "serviceDescription")]
        public string ServiceDescription { get; set; }

        [JsonProperty(PropertyName = "serviceType")]
        public string ServiceType { get; set; }

        [JsonProperty(PropertyName = "dateStart")]
        public string DateStart { get; set; }

        [JsonProperty(PropertyName = "dateEnd")]
        public string DateEnd { get; set; }

        [JsonProperty(PropertyName = "sundayStart")]
        public string SundayStart { get; set; }

        [JsonProperty(PropertyName = "sundayEnd")]
        public string SundayEnd { get; set; }

        [JsonProperty(PropertyName = "mondayStart")]
        public string MondayStart { get; set; }

        [JsonProperty(PropertyName = "mondayEnd")]
        public string MondayEnd { get; set; }

        [JsonProperty(PropertyName = "tuesdayStart")]
        public string TuesdayStart { get; set; }

        [JsonProperty(PropertyName = "tuesdayEnd")]
        public string TuesdayEnd { get; set; }

        [JsonProperty(PropertyName = "wednesdayStart")]
        public string WednesdayStart { get; set; }

        [JsonProperty(PropertyName = "wednesdayEnd")]
        public string WednesdayEnd { get; set; }

        [JsonProperty(PropertyName = "thursdayStart")]
        public string ThursdayStart { get; set; }

        [JsonProperty(PropertyName = "thursdayEnd")]
        public string ThursdayEnd { get; set; }

        [JsonProperty(PropertyName = "fridayStart")]
        public string FridayStart { get; set; }

        [JsonProperty(PropertyName = "fridayEnd")]
        public string FridayEnd { get; set; }

        [JsonProperty(PropertyName = "saturdayStart")]
        public string SaturdayStart { get; set; }

        [JsonProperty(PropertyName = "saturdayEnd")]
        public string SaturdayEnd { get; set; }



        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}