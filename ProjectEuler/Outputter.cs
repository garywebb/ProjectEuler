using System;

namespace ProjectEuler
{
    public class Outputter : IOutputter
    {
        public void Record(string output)
        {
            Console.WriteLine(output);
        }
    }
}
