
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaFinca.Models
{
    public class IUser
    {
        //[BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string username { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string role { get; set; }

        public IUser()
        {

        }

        public IUser( string name, string username, string email,string password, string role)
        {
            this.name = name;
            this.username = username;
            this.email = email;
            this.password = password;
            this.role = role;
        }
    }
}
