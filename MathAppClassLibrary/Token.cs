﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathAppClassLibrary
{
    /**
     * Token is used to validate the user when services are invoked from ServiceProvider
     */
    public class Token
    {
        public static Random random = new Random();

        public int random_int;

        public Token(int random_int)
        {
            this.random_int = random_int;
        }

        public static int CreateRandomInt()
        {
            return random.Next(1, 50000);
        }
    }
}
