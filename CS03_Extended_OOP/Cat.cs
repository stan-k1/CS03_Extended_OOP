using System;

namespace CS03_Extended_OOP
{
    class Cat : IComparable<Cat>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public CoatPattern CoatPattern { get; set; }

        public Cat(int age)
        {
            if (age > 20) throw new CatAgeException("Cat age cannot be larger  		than 20");
            else Age = 20;
        }

        public Cat() {}

        public int CompareTo(Cat other)
        {
            if (other == null) return 0;
            else return this.Age - other.Age;
        }

    }
}
