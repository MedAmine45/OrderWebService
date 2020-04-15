    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIPerspection.Models
{
    public class ApplicationSettings
    {
        public string JWT_Secret { get; set; }
        public string Client_URL { get; set; }
    }

    public class EmailSettings
    {
        public string MailToAddress { get; set; } 
        public string MailFromAddress { get; set; }
        public bool UseSsl { get; set; } 
        public string Username { get; set; } 
        public string Password { get; set; }
        public string ServerName { get; set; } 
        public int ServerPort { get; set; } 

    }
}
