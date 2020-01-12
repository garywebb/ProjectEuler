using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEulerTests.Helpers.DataBuilders
{
    public interface IDataBuilder<T>
    {
        T Build();
    }
}
