using Pandora.Definitions.Operations;

namespace Pandora.Definitions.TestData.Pandamonium.v2020_01_01.Grouping
{
    public class Restart : PostOperation
    {
        public override object? RequestObject()
        {
            return null;
        }

        public override string? UriSuffix()
        {
            return "/restart";
        }
    }
}