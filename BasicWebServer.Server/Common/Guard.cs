﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.Common
{
   public static class Guard
    {
        public static void AgaintsNull(object value ,string name = null)
        {
            if(value == null)
            {
                name ??= "Value";

                throw new ArgumentException($"{name} cannot be null.");
            }
        }
    }
}
