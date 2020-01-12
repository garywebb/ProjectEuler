using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEulerTests.Helpers.DataBuilders
{
    public static class DataBuilderFactory
    {
        public static ResultBuilder AResult() => new ResultBuilder();
        public static ResultBuilder ASuccessResult() => 
            AResult()
                .With(resultState: ProjectEuler.ResultState.Success);
        public static ResultBuilder AFailureResult() =>
            AResult()
                .With(resultState: ProjectEuler.ResultState.Failure);
        public static ChallengeBuilder AChallenge() => new ChallengeBuilder();
    }
}
