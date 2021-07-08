using System;
using System.Collections.Generic;
using System.Globalization;

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

            //Collections

            //Initializing an Array
            Cat[] catsArray = new Cat[2];
            int[] intsArray = { 1, 2, 3, 4, 5 };

            //Working with Lists
            Cat Cadife = new() {Name = "Cadife", Age = 10};
            Cat Annie = new() {Name = "Annie", Age = 8};
            Cat Belle = new() { Name = "Belle", Age = 13 };

            List<Cat> catList = new();
            catList.Add(Cadife);
            catList.Add(Annie);
            catList.Remove(Annie);
            Cat newCatReference = catList[0];
            Console.WriteLine(newCatReference.Name); //Cadife

            //Initializing Lists
            int[] ints = { 1, 2, 3, 4, 5 };
            List<int> intsList = new(ints);
            Console.WriteLine(intsList[2]); //3

            List<int> presizedList = new(5);

            //Using Dictionaries
            Dictionary<string, Cat> dictionary = new();

            dictionary.Add("cadife", Cadife);
            dictionary.Add("annie", Annie);

            //dictionary.Remove("annie");
            dictionary.Remove("annie", out Cat removedCat);
            Console.WriteLine(removedCat.Name); //Annie

            Cat retrievedCat = dictionary["cadife"];
            Console.WriteLine(retrievedCat.Name); //Cadife
            //Cat nonexistentCat = dictionary["ghost"]; // KeyNotFoundException

            dictionary.Add("annie", Annie);
            foreach (string catkey in dictionary.Keys)
            {
                Console.WriteLine(catkey);
            }

            foreach (KeyValuePair<string, Cat> cats in dictionary)
            {
                Console.WriteLine(cats.Value.Name);
            }

            //Enums

            Season season = new();
            Console.WriteLine(season); //Autumn
            Console.WriteLine((int)season); //0

            Cat Spot = new Cat()
                { Name = "Spot", Age = 9, CoatPattern = CoatPattern.Tabby };



            //Sorted List and Dictionaries

            SortedList<string, int> SortedNums = new();
            SortedNums.Add("B", 50);
            SortedNums.Add("A", 100);
            SortedNums.Add("C", 10);
            Console.WriteLine(SortedNums.Values[0]); //100

            // Cat Cadife = new() { Name = "Cadife", Age = 10 };
            // Cat Annie = new() { Name = "Annie", Age = 8 };
            // Cat Belle = new() { Name = "Belle", Age = 13 };

            SortedDictionary<int, Cat> SortedCatsDict = new();
            SortedCatsDict.Add(1, Cadife);
            SortedCatsDict.Add(2, Annie);
            SortedCatsDict.Add(0, Belle);
            Console.WriteLine(SortedCatsDict[0].Name); //Belle

            //Comparables

            List<Cat> Cats = new();
            Cats.Add(Cadife);
            Cats.Add(Belle);
            Cats.Add(Annie);
            Console.WriteLine(Cats[0].Name); //Cadife
            Cats.Sort();
            Console.WriteLine(Cats[0].Name); //Annie

            Cats.Sort(new ReverseAgeComparer());
            Console.WriteLine(Cats[0].Name); //Belle

            //Parsing DateTimes

            string DateString = "January 1, 2021";
            DateTime ParsedDT = DateTime.Parse(DateString);
            Console.WriteLine(ParsedDT); // 1/1/2021 12:00:00 AM

            string DateString2 = "01 / 01 / 21";
            DateTime ParsedDT2 = DateTime.Parse(DateString);
            Console.WriteLine(ParsedDT2); // 1/1/2021 12:00:00 AM

            //Using Cultures

            string DateString3 = "03/01/21";

            DateTime ParsedDTGR = DateTime.Parse(DateString3, CultureInfo.GetCultureInfo("el-GR"));
            Console.WriteLine(ParsedDTGR); // 3/1/2021 12:00:00 AM

            DateTime ParsedDTGB = DateTime.Parse(DateString3, CultureInfo.GetCultureInfo("en-US"));
            Console.WriteLine(ParsedDTGB); // 1/3/2021 12:00:00 AM

            //Time Spans

            Console.WriteLine(new TimeSpan(28, 56, 24)); //1.04:56:24

            DateTime dt1 = new(1994, 12, 16);
            DateTime dt2 = new(2000, 12, 16);
            TimeSpan dts = dt2 - dt1; //2192.00:00:00
            Console.WriteLine(dts);

            //DateTimeOffset

            Console.WriteLine(DateTime.Now); // 17/6/2021 2:02:23 μμ
            Console.WriteLine(DateTimeOffset.Now); //17/6/2021 2:02:23 μμ +03:00

            DateTime dt = new(1994, 12, 16, 0, 0, 0);
            DateTimeOffset dtf = new(1994, 12, 16, 0, 0, 0, new TimeSpan(3, 0, 0));
            DateTimeOffset dtf2 = new(dt, new TimeSpan(3, 0, 0));

            Console.WriteLine(dtf); //16/12/1994 12:00:00 πμ +03:00
            Console.WriteLine(dtf2); //16/12/1994 12:00:00 πμ +03:00

            //Format Providers

            Console.WriteLine(dtf); //16/12/1994 12:00:00 πμ +03:00
            Console.WriteLine(dtf.ToString("y/MMM/dd H-m-s | \'Offset:' z")); //94/Δεκ/16 0-12-S | Offset: +3

            //Parsing with a Format Provider

            string StringDate = "Dec-10-2019";
            DateTimeOffset parsed = DateTimeOffset.ParseExact(
                StringDate,
                "MMM-d-yyyy",
                CultureInfo.InvariantCulture);

            Console.WriteLine(parsed); //10/12/2019 12:00:00 πμ +02:00

            //Parsing with Parse()

            Console.WriteLine(DateTimeOffset.Parse(StringDate)); //10/12/2019 12:00:00 πμ +02:00

            string AmbiguousStringDate = "12/1/2021";
            Console.WriteLine(DateTimeOffset.Parse(AmbiguousStringDate)); //12/1/2021 12:00:00 πμ +02:00
            Console.WriteLine(DateTimeOffset.Parse(
                AmbiguousStringDate,
                CultureInfo.GetCultureInfo("en-US"))); //1/12/2021 12:00:00 πμ +02:00

            //DateTime.Kind Property

            DateTime dt4 = new(1994, 12, 16, 0, 0, 0);
            DateTime dtSpecified = DateTime.SpecifyKind(dt4, DateTimeKind.Utc);
            Console.WriteLine(dt4.Kind); // Unspecified
            Console.WriteLine(dtSpecified.Kind); // Utc

            //Converting to UTC
            string DateWithTz = "12-10-2019 15:30:00 +03:00";

            Console.WriteLine(DateTime.Parse(
                DateWithTz,
                CultureInfo.InvariantCulture,
                DateTimeStyles.AdjustToUniversal)
            ); //10/12/2019 12:30:00 μμ

            //Parameter Modifiers - Ref

            int myNum = 1;
            Console.WriteLine(myNum); //1
            Increment(ref myNum);
            Console.WriteLine(myNum); //2

            //Using Reference Types as Parameters

            Cat Tara = new Cat { Name = "Tara", Age = 6 };
            ToKitten(Tara);
            Console.WriteLine(Tara.Age); //0

            Tara.Age = 6; //Reset Tara's Age back to 6

            ToGhost(Tara);
            Console.WriteLine(Tara.Age); //6

            ToGhostRef(ref Tara);
            Console.WriteLine(Tara.Name); //Ghost
            Console.WriteLine(Tara.Age); //1000

            //Parameter Modifiers - In

            ToGhostAge(in Tara);
            Console.WriteLine(Tara.Age); //1000

            //Parameter Modifiers - Out

            IncrementAndOutput(myNum, out int myNewNum, out string myNewText);
            Console.WriteLine(myNewNum); // 2
            Console.WriteLine(myNewText); // Outputted!

            GenericStack<string> StringStack = new();
            StringStack.Push("Hello");
            StringStack.Push("World");
            Console.WriteLine(StringStack.Pop()); //World

            GenericStack<Cat> CatStack = new();
            CatStack.Push(cat);
            Cat CatFromStack = CatStack.Pop();
            Console.WriteLine(CatFromStack.Age); //19

            string sa = "World!";
            string sb = "Hello";
            Swap<string>.SwapNow(ref sa, ref sb);
            Console.WriteLine(sa + " " + sb); //Hello World!

            Cat Cat1 = new Cat(19) { Name = "Cadife" };
            Cat Cat2 = new Cat(9) { Name = "Annie" };
            Swap<Cat>.SwapNow(ref Cat1, ref Cat2);
            Console.WriteLine(Cat2.Name); //Cadife


        }

        public static void Increment(ref int number)
        {
            number++;
        }

        public static void ToKitten(Cat cat)
        {
            cat.Age = 0;
        }

        public static void ToGhost(Cat cat)
        {
            cat = new Cat() { Name = "Ghost", Age = 1000 };
        }

        public static void ToGhostAge(in Cat cat)
        {
            cat.Age = 1000; //OK
        }

        public static void ToGhostIn(in Cat cat)
        {
            //cat = new Cat() { Name = "Ghost", Age = 1000 }; //Compile Time Error
        }

        public static void ToGhostRef(ref Cat cat)
        {
            cat = new Cat() { Name = "Ghost", Age = 1000 };
        }


        public static void IncrementAndOutput(int num, out int myNewNum, out string MyNewText)
        {
            myNewNum = num++;
            MyNewText = "Outputted";
        }


    }
}
