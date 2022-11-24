using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationJobs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ExportJobOutputSerializationTypeConstant
{
    [Description("Excel")]
    Excel,

    [Description("Json")]
    Json,

    [Description("Xml")]
    Xml,
}
