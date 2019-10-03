using System.Collections.Generic;

namespace Practice04
{
    interface IDataStorage
    {
        IEnumerable<int> Numbers { get; }
    }
}