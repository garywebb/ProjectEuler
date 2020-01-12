using ProjectEuler;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEulerTests.Helpers.DataBuilders
{
    public class ChallengeBuilder : IDataBuilder<Challenge>
    {
        private readonly Challenge _challenge = new Challenge
        {
            Name = "A Challenge",
            Inputs = 10,
            ExpectedOutput = 23,
        };

        public Challenge Build()
        {
            return _challenge;
        }

        public ChallengeBuilder With(
            string name = null,
            int? inputs = null,
            int? expectedOutput = null)
        {
            if (name != null) _challenge.Name = name;
            if (inputs != null) _challenge.Inputs = inputs.Value;
            if (expectedOutput != null) _challenge.ExpectedOutput = expectedOutput.Value;

            return this;
        }
    }
}
