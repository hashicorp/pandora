using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DigitalTwins.v2022_10_31.TimeSeriesDatabaseConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConnectionTypeConstant
{
    [Description("AzureDataExplorer")]
    AzureDataExplorer,
}
