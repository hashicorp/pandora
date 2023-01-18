using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountSchemas;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SchemaTypeConstant
{
    [Description("NotSpecified")]
    NotSpecified,

    [Description("Xml")]
    Xml,
}
