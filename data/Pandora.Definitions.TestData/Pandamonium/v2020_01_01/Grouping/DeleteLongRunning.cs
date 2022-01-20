using System;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.TestData.Pandamonium.v2020_01_01.Grouping;

public class DeleteLongRunning : LongRunningDeleteOperation
{
    public override Type? OptionsObject()
    {
        return typeof(DeleteImmediateOptions);
    }

    public class DeleteImmediateOptions
    {
        [QueryStringName("reallyReally")]
        [Optional]
        public bool ReallyDelete { get; set; }
    }
}