using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    public class ChallengeAnswererProvider : IChallengeAndAnswererProvider
    {
        public IEnumerable<ChallengeAndAnswerer> GetAnswerers(IEnumerable<Challenge> challenges)
        {
            var answererTypes = GetType().Assembly.GetTypes()
                .Where(type => type.GetInterfaces().Contains(typeof(IChallengeAnswerer)))
                .ToList();

            foreach (var challenge in challenges)
            {
                foreach (var answererType in answererTypes)
                {
                    var answerer = (IChallengeAnswerer)Activator.CreateInstance(answererType);
                    if (answerer.CanAnswer(challenge))
                    {
                        yield return new ChallengeAndAnswerer
                        {
                            Answerer = answerer,
                            AnswererName = answererType.Name,
                            Challenge = challenge,
                        };
                    }
                }
            }
        }
    }
}
