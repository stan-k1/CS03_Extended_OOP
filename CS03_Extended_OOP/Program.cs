using System;

namespace CS03_Extended_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exceptions

            int x = 5, y = 0;
            try
            {
                int r = x / y;
                Console.WriteLine("This will not be printed.");
            }
            catch (DivideByZeroException exception)
            {
                Console.WriteLine("The divisor should not be zero.");
            }
            catch (Exception exception)
            {
                Console.WriteLine("An unknown exception has occurred. Press Enter to quit.");
                Console.ReadLine();
                throw exception;
            }
            finally
            {
                Console.WriteLine("Execution completed. Press enter to quit.");
            }

            //Throwing a User-Defined Exception

            Cat cat = null;
            try
            {
                cat = new Cat(21);
            }
            catch (CatAgeException exception)
            {
                Console.WriteLine(exception.Message); //"Cat age cannot be larger than 20"
            }
            Console.WriteLine(cat == null); //True


        }
    }
}
