using System.Collections.Generic;

namespace MyWebApi.Models
{
    public class SimpleUser
    {


        public long Id { get; set; }           
        public string Name { get; set; }
        public string NickName { get; set; }
        public string PhoneNum { get; set; }
        public string Password { get; set; }
    }
}
