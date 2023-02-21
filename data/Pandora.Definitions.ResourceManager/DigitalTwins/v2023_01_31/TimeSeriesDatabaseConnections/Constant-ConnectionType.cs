using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DigitalTwins.v2023_01_31.TimeSeriesDatabaseConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConnectionTypeConstant
{
    [Description("AzureDataExplorer")]
    AzureDataExplorer,
}
