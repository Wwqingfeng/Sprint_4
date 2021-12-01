using System;
using System.Collections.Generic;
using System.Text;

namespace BCUnit.Framework.SDK
{

    // Attribute class to flag classes
    [AttributeUsage(AttributeTargets.Class)]
    public class TestClassAttribute : Attribute
    {
    }
}
