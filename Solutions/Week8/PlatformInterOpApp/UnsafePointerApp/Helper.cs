using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnsafePointerApp
{
    public  class Helper
    {

        public static  unsafe void DisplayCount()
        {
            // This is an unsafe code block
            // Unsafe code is used to work with pointers
            // and memory directly in C#
            int count = 600;
            int* ptrCount = &count;

            Console.WriteLine("Count is =" + count);
            Console.WriteLine("Count is: {0}", *ptrCount);
        }

        //Fixed keyword is used to pin the memory address of the array
        // so that the garbage collector does not move it around
        public static unsafe void PerformArrayManipulation()
        {
            // This is an unsafe code block
            // Unsafe code is used to work with pointers
            // and memory directly in C#
            int[] numbers = { 99, 112,563, 64, 95 };
            fixed (int* pNumbers = numbers)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    Console.WriteLine("Number at index {0} is: {1}", i, *(pNumbers + i));
                }
            }
        }

    }
}
