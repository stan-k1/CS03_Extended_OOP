using System;

namespace CS03_Extended_OOP
{
    class CatAgeException : Exception
    {
        public CatAgeException() { }
        public CatAgeException(string message) : base(message) { }
        public CatAgeException(string message, Exception inner) : base(message, inner) { }
    }
}
