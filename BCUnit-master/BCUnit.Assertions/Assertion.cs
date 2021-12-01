using System;
using System.Collections.Generic;
using System.Text;

namespace BCUnit.Assertions
{
    public class Assertion
    {

        public static void AssertArrayEquals(int[] expected, int[] actual)
        {
            if (expected.Length != actual.Length) 
                Fail($"Arrays Not Equal!");

            for (int i = 0; i < expected.Length; i++) {
                if (expected[i] != actual[i]) 
                    Fail($"At index {i} Expected != Actual");
              
            }
            Console.WriteLine("PASS");


        }

        public static void AssertEquals(int expected, int acutal)
        {
            if (expected != acutal)
                Fail($"Expected: {expected}\n Actual: {acutal}");

            Console.WriteLine("PASS");
        }


        public static void AssertNotEquals(int expected, int acutal)
        {
            if (expected == acutal)
                Fail($"Expected: {expected}\n Actual: {acutal}");

            Console.WriteLine("PASS");
        }
        public static void AssertNotEquals(double expected, double acutal)
        {
            if (expected == acutal)
                Fail($"Expected: {expected}\n Actual: {acutal}");

            Console.WriteLine("PASS");
        }


        static public void Fail(String message)
        {
            throw new AssertionFailedError(message);
        }
    }
}
