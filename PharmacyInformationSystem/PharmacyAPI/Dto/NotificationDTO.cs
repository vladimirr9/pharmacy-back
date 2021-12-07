using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Dto
{
    public class NotificationDTO 
    {
        public string Neki { get; set; }
        public NotificationDTO()
        { }
        public NotificationDTO(string neki)
        {
            this.Neki = neki;
        }

    }
}
