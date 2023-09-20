using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2023_08_15.ManagedPrivateEndpoints;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedPrivateEndpointsTypeConstant
{
    [Description("Microsoft.Kusto/clusters/managedPrivateEndpoints")]
    MicrosoftPointKustoClustersManagedPrivateEndpoints,
}
