﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservationSystem
{
    public interface IEmailReceipt
    {
        public string SentEmail(string fileName);
    }
}
