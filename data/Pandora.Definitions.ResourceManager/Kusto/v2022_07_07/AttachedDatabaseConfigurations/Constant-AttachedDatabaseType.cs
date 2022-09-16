using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2022_07_07.AttachedDatabaseConfigurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AttachedDatabaseTypeConstant
{
    [Description("Microsoft.Kusto/clusters/attachedDatabaseConfigurations")]
    MicrosoftPointKustoClustersAttachedDatabaseConfigurations,
}
