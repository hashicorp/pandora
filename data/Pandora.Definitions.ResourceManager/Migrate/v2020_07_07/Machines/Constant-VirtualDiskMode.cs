using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Migrate.v2020_07_07.Machines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VirtualDiskModeConstant
{
    [Description("append")]
    Append,

    [Description("independent_nonpersistent")]
    IndependentNonpersistent,

    [Description("independent_persistent")]
    IndependentPersistent,

    [Description("nonpersistent")]
    Nonpersistent,

    [Description("persistent")]
    Persistent,

    [Description("undoable")]
    Undoable,
}
