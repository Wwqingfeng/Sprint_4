﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BCUnit.Framework.SDK
{


    // Attribute method class to flag a method
    [AttributeUsage(AttributeTargets.Method)]
    public class TestMethodAttribute : Attribute
    {

        public int Order
        {
            get; set;
        }

    }

}

