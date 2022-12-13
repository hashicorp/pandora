using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ManagementGroups.v2020_05_01.ManagementGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TypeConstant
{
    [Description("Microsoft.Management/managementGroups")]
    MicrosoftPointManagementManagementGroups,

    [Description("/subscriptions")]
    Subscriptions,
}
