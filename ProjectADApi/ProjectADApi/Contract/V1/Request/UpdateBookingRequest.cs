﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.V1.Request
{
    public class UpdateBookingRequest
    {
        [Required]
        public int QouteId { get; set; }
        [Required]
        public int BookingId { get; set; }


    }
}
