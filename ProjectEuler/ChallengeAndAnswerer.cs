using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{
    public class ChallengeAndAnswerer
    {
        public string AnswererName { get; set; }
        public Challenge Challenge { get; set; }
        public IChallengeAnswerer<int, long> Answerer { get; set; }
    }
}
