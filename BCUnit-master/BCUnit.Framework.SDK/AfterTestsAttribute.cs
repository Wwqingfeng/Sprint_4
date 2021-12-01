using System;
using System.Collections.Generic;
using System.Text;


// This will run before TestMethod Attribute
namespace BCUnit.Framework.SDK
{
    [AttributeUsage(AttributeTargets.Method)]

    public class AfterAllTestsAttribute : Attribute
    {
    }
}
