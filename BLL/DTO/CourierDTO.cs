﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CourierDTO
    {
        public int courier_id { get; set; }

        public string courier_name { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string contact { get; set; }

        public string location { get; set; }

        public int income { get; set; }

        public string token { get; set; }
    }
}