using System.Collections.Generic;
using System.Security.Cryptography;

namespace SessionApi.Models
{
    public class Session
    {
        public long Id { get; set; }            // User login ID
        public string UserKey {get; set;}    

        public string LoginTime {get;set; }
        public string LogoutTime{get; set;}
        public bool GameStatus {get; set;}
        public static RSAParameters rsaParameter;
    }
}
