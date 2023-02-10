using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2022_02_01.ManagedPrivateEndpoints;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedPrivateEndpointsTypeConstant
{
    [Description("Microsoft.Kusto/clusters/managedPrivateEndpoints")]
    MicrosoftPointKustoClustersManagedPrivateEndpoints,
}
