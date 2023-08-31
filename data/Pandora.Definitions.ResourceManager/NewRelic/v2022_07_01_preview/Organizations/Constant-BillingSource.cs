using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NewRelic.v2022_07_01_preview.Organizations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BillingSourceConstant
{
    [Description("AZURE")]
    AZURE,

    [Description("NEWRELIC")]
    NEWRELIC,
}
