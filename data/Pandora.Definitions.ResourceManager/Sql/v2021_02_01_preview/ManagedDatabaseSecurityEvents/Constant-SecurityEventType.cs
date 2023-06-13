using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.ManagedDatabaseSecurityEvents;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityEventTypeConstant
{
    [Description("SqlInjectionExploit")]
    SqlInjectionExploit,

    [Description("SqlInjectionVulnerability")]
    SqlInjectionVulnerability,

    [Description("Undefined")]
    Undefined,
}
