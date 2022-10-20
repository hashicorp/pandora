using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_05_15.Restorables;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConflictResolutionModeConstant
{
    [Description("Custom")]
    Custom,

    [Description("LastWriterWins")]
    LastWriterWins,
}
