﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.Contract.Request
{
    public class ArtisanServiceRequest
    {
       
           // public int Id { get; set; }
            public int ArtisanId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Status { get; set; }
            public DateTime? Createdon { get; set; }

           // public virtual Artisan Artisan { get; set; }
        
    }
}
