using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Maps.v2021_02_01.Accounts
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum Kind
    {
        [Description("Gen1")]
        GenOne,

        [Description("Gen2")]
        GenTwo,
    }
}
