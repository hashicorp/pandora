using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.IntegrationRuntimes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IntegrationRuntimeAuthKeyNameConstant
{
    [Description("authKey1")]
    AuthKeyOne,

    [Description("authKey2")]
    AuthKeyTwo,
}
