using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_05_05_preview.SmartGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SortOrderConstant
{
    [Description("asc")]
    Asc,

    [Description("desc")]
    Desc,
}
