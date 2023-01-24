using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataMigration.v2018_04_19.POST;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CommandStateConstant
{
    [Description("Accepted")]
    Accepted,

    [Description("Failed")]
    Failed,

    [Description("Running")]
    Running,

    [Description("Succeeded")]
    Succeeded,

    [Description("Unknown")]
    Unknown,
}
