using BCUnit.Framework.SDK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using static BCUnit.Assertions.Assertion;


namespace BCUnit.Engine
{
    public class Engine
    {

        private List<Type> AllAtributes = null;
        private string _fileName, _fileType;
       
        

        /// <summary>
        /// Constructor will take a fileLocation folder and it should be located inside the Application directory and an optional fileType of .dll extension
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileType"></param>
        public Engine(string fileName, string fileType = "*.dll")
        {
            _fileName = fileName;
            _fileType = fileType;
            
            AllAtributes = new List<Type>();
            AllAtributes = ReadAllAttribute(fileName, fileType);



        }


        /// <summary>
        /// Will invoke all the methods that has an attribute tags
        /// </summary>
        public void MethodsParser()
        {

            foreach (Type t in AllAtributes) {


                // Query to find the BeforeAllTestAttribute tag
                var BeforeAllTest = from m in t.GetMethods()
                                 where m.GetCustomAttributes(false).Any(a => a is BeforeAllTestsAttribute)
                                 select m;

                InvokeMethod(t, BeforeAllTest);


                // Query to find the TestMethodsAttriubte tags
                var allTestMethods = from m in t.GetMethods()
                                     where m.GetCustomAttributes(false).Any(a => a is TestMethodAttribute)
                                     select m;

                // Re-ordering the founded methods
                var ordered = allTestMethods.OrderBy(p => p.GetCustomAttribute<TestMethodAttribute>().Order);

                // Two lists to store the TestMethodsAttriubte tags 
                List<MethodInfo> withOrder = new List<MethodInfo>();        // has Order = 1, 2, 3, ..

                List<MethodInfo> withoutOrder = new List<MethodInfo>();     // has default Order = 0


                // adding TestMethodsAttriubte methods to the lists
                foreach (var v in ordered) {
                    int order = v.GetCustomAttribute<TestMethodAttribute>().Order;


                    if (order != 0) {
                        withOrder.Add(v);
                    } else {
                        withoutOrder.Add(v);
                    }
                }

                // Concatenate the lists with Order of 1, 2, 3......, then 0, 0, 0
                List<MethodInfo> newList = withOrder.Concat(withoutOrder).ToList();

                InvokeMethod(t, newList);


                // Checking for AfterAllTests Attribute tag
                var afterTest = from m in t.GetMethods()
                                where m.GetCustomAttributes(false).Any(a => a is AfterAllTestsAttribute)
                                select m;

                InvokeMethod(t, afterTest);

            }

        }


        /// <summary>
        /// Will use the Activator class to invoke methods
        /// </summary>
        /// <param name="type"></param>
        /// <param name="testList"></param>
        private void InvokeMethod(Type type, IEnumerable<MethodInfo> testList)
        {
            if (testList != null) {
                object instance = Activator.CreateInstance(type);
                foreach (MethodInfo mInfo in testList) {
                    Console.Write($"Engine is running on {mInfo.Name}() =>\n");
                    mInfo.Invoke(instance, new object[0]);
                }
            }
        }

    

        /// <summary>
        /// Will return the number of classes tagged with TestClass Attribute
        /// </summary>
        /// <returns>int</returns>
        public int GetCount()
        {
            return AllAtributes.Count;
        }

        /// <summary>
        /// Will print the name of classes tagged with TestClass Attribute
        /// </summary>
        public void PrintClassName()
        {
            if(GetCount() != 0) {
                foreach (Type t in AllAtributes) {
                    Console.WriteLine("The test class is: " + t.Name);
                }
            } else {
                Console.WriteLine($"There is no {_fileType} files in {_fileName} folder!");
            }

        }


        /// <summary>
        /// Will return all the classes tagged with TestClassAttribute
        /// </summary>
        /// <returns>List<paramref name=" Type"/></returns>
        private List<Type> ReadAllAttribute(string fileName, string fileType)
        {
            var pluginList = new List<Type>();

            var files = Directory.GetFiles(fileName, fileType);

            foreach (var file in files) {
                List<Assembly> tempAssemblyList = new List<Assembly>();

                Assembly assembly = Assembly.LoadFile(Path.Combine(Directory.GetCurrentDirectory(), file));
                tempAssemblyList.Add(assembly);

                foreach (Assembly a in tempAssemblyList) {
                    Type[] allTypes = a.GetTypes();
                    foreach (Type type in allTypes) {

                        if ((type.GetCustomAttribute(typeof(TestClassAttribute))) is TestClassAttribute) {
                            pluginList.Add(type);


                        }
                    }
                }

            }

            return pluginList;
        }





    }//class

}//namespace
