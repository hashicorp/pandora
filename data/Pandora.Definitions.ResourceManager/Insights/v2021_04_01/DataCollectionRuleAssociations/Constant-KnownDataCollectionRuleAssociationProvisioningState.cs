using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2021_04_01.DataCollectionRuleAssociations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KnownDataCollectionRuleAssociationProvisioningStateConstant
{
    [Description("Creating")]
    Creating,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
