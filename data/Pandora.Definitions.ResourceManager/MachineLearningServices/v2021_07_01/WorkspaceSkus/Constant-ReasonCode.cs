using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2021_07_01.WorkspaceSkus;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReasonCodeConstant
{
    [Description("NotAvailableForRegion")]
    NotAvailableForRegion,

    [Description("NotAvailableForSubscription")]
    NotAvailableForSubscription,

    [Description("NotSpecified")]
    NotSpecified,
}
