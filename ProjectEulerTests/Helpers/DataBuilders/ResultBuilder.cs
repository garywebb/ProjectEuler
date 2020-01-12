using ProjectEuler;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEulerTests.Helpers.DataBuilders
{
    public class ResultBuilder : IDataBuilder<Result>
    {
        private readonly Result _result = new Result
        {
            ActualOutput = 1,
            ResultState = ResultState.Success,
            ElapsedTime = new TimeSpan(0, 0, 0, 0, 100),
        };

        public Result Build()
        {
            return _result;
        }

        public ResultBuilder With(
            int? actualOutput = null,
            ResultState? resultState = null,
            TimeSpan? elapsedTime = null)
        {
            if (actualOutput != null) _result.ActualOutput = actualOutput.Value;
            if (resultState != null) _result.ResultState = resultState.Value;
            if (elapsedTime != null) _result.ElapsedTime = elapsedTime.Value;

            return this;
        }
    }
}
