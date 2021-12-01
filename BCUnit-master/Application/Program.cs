using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BCUnit.Engine;

using BCUnit.Framework.SDK;


namespace Application {
    class Program {

        
        static void Main(string[] args) {
            

            Engine engine = new Engine("extension");
            Console.WriteLine($"Engine found {engine.GetCount()} plugin(s)!");

            engine.PrintClassName();
            Console.WriteLine();
            engine.MethodsParser();



        }





    }
}
