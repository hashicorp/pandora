using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.PolicyFragment;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PolicyFragmentContentFormatConstant
{
    [Description("rawxml")]
    Rawxml,

    [Description("xml")]
    Xml,
}
