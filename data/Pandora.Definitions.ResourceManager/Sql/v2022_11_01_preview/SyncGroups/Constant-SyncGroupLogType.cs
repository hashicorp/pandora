using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.SyncGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SyncGroupLogTypeConstant
{
    [Description("All")]
    All,

    [Description("Error")]
    Error,

    [Description("Success")]
    Success,

    [Description("Warning")]
    Warning,
}
