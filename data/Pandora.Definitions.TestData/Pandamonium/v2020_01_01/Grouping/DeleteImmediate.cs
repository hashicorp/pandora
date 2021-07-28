using Pandora.Definitions.Attributes;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.ResourceManager.Pandamonium.v2020_01_01.Grouping
{
    public class DeleteImmediate : DeleteOperation
    {
        public override object? OptionsObject()
        {
            return new DeleteImmediateOptions();
        }
    }

    public class DeleteImmediateOptions
    {
        [QueryStringName("reallyReally")]
        [Optional]
        public bool ReallyDelete { get; set; }
    }
}