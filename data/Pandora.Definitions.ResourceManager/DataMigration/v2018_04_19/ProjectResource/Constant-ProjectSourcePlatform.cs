using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataMigration.v2018_04_19.ProjectResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProjectSourcePlatformConstant
{
    [Description("SQL")]
    SQL,

    [Description("Unknown")]
    Unknown,
}
