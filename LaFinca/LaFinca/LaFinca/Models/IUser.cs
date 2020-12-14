
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaFinca.Models
{
    public class IUser
    {
        //[BsonRepresentation(BsonType.ObjectId)]
        //[BsonId]
        public string Id { get; set; }
        [BsonElement("username")]
        [JsonProperty("username")]
        public string username { get; set; }
        [BsonElement("names")]
        [JsonProperty("name")]
        public string name { get; set; }
        [BsonElement("email")]
        [JsonProperty("email")]
        public string email { get; set; }
        [BsonElement("password")]
        [JsonProperty("password")]
        public string password { get; set; }
        [BsonElement("role")]
        [JsonProperty("role")]
        public string role { get; set; } = "customer";

        [BsonElement("favoritesArray")]
        [JsonProperty("favoritesArray")]
        public string[] favoritesArray { get; set; }

        public IUser()
        {

        }

        public IUser( string name, string username, string email,string password, string role)
        {
            this.Id = new ObjectId().ToString();
            this.name = name;
            this.username = username;
            this.email = email;
            this.password = password;
            this.role = "customer";
        }

    }
}
