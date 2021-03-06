﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vneed.Model
{
    public class Order
    {
        public int OrderSerialNumber;
        public string OrderID;
        public int Status;
        public int Payment;
        public int Delivery;
        public int UserID;
        public DateTime ModiefiedDate;
        public string Name;
        public string School;
        public string Contact;
        public string Email;
        public string IdentityNo;
        public int AlreadySignedIn;
        public string ExtraInfo;

        public void SetStatusToNotPayed()
        {
            Status = 0;
        }

        public void SetStatusToPayed()
        {
            Status = 1;
        }

        public void SetStatusToFinished()
        {
            Status = 2;
        }
    }
}
