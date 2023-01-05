using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2022_12_01.CognitiveServicesAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ResourceSkuRestrictionsTypeConstant
{
    [Description("Location")]
    Location,

    [Description("Zone")]
    Zone,
}
