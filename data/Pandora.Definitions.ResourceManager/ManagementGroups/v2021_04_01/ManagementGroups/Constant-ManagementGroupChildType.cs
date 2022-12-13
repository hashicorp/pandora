using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ManagementGroups.v2021_04_01.ManagementGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagementGroupChildTypeConstant
{
    [Description("Microsoft.Management/managementGroups")]
    MicrosoftPointManagementManagementGroups,

    [Description("/subscriptions")]
    Subscriptions,
}
