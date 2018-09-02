using System.Collections.Generic;

namespace MyWebApi.Models
{
    public class User : SimpleUser
    {
        public User(){

        }
        public User(SimpleUser user){
            this.Id = user.Id;
            this.Password = user.Password;
            this.Name = user.Name;
            this.NickName = user.NickName;
            this.PhoneNum = user.PhoneNum;
        }
        //public long Id { get; set; }            // User login ID
        public string PrimaryKey {get; set;}    
        //public string Name { get; set; }        
        //public string NickName{get; set;}
        //public string PhoneNum{get; set;}
        public string LstSession{get; set;}
        //public string Password{get; set;}
    }
}
