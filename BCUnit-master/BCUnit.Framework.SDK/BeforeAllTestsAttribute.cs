using System;
using System.Collections.Generic;
using System.Text;

namespace BCUnit.Framework.SDK
{

    // This will run before TestMethod Attribute
    [AttributeUsage(AttributeTargets.Method)]
    public class BeforeAllTestsAttribute : Attribute
    {
    }
}
