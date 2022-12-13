using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ManagementGroups.v2021_04_01.Entities;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PermissionsConstant
{
    [Description("delete")]
    Delete,

    [Description("edit")]
    Edit,

    [Description("noaccess")]
    Noaccess,

    [Description("view")]
    View,
}
