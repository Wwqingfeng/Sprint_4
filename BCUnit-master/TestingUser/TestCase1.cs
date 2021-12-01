using System;
using System.Collections.Generic;
using System.Text;
using BCUnit.Framework.SDK;

using static BCUnit.Assertions.Assertion;

namespace TestingUser
{

    [TestClass]
    public class TestCase1
    {
        static Calculator calculator;
        [BeforeAllTests]
        public static void Initialize()
        {
            Console.WriteLine("Initializer...");
            calculator = new Calculator();
        }


        [TestMethod(Order = 1)]
        public void TestMethod1()
        {
            Console.WriteLine("Running method 1");
            int[] expected = { 1, 2, 3 };
            int[] actual = { 1, 2, 3 };
            AssertArrayEquals(expected, actual);
        }


        [TestMethod(Order = 3)]
        public void TestMethod2()
        {
            Console.WriteLine("Running method 2");
            int[] expected = { 1, 2, 3 };
            int[] actual = { 1, 2, 3 };
            AssertArrayEquals(expected, actual);
        }


        [TestMethod]
        public void TestMethod3()
        {
            Console.WriteLine("Running method 3");
            int expected = 5;
            int actual = 3;
            AssertNotEquals(expected, actual);
        }
        
        [TestMethod]
        public void TestMethod4()
        {
            Console.WriteLine("Running method 4");
            int actual = calculator.Subtract(1, 2);
            int expected = -1;
            AssertEquals(expected, actual);
        }

        [TestMethod(Order = 2)]
        public void TestMethod5()
        {
            Console.WriteLine("Running method 5");
            int actual = calculator.Add(1, 2);
            int expected = 3;
            AssertEquals(expected, actual);

        }
        [TestMethod]
        public void TestMethod6()
        {
            Console.WriteLine("Running method 6");
            double expected = 5.4;
            double actual = 3.2;
            AssertNotEquals(expected, actual);
        }


        [AfterAllTests]
        public void CleanResources()
        {
            Console.WriteLine("Clean Resources...");
        }
    }
}
