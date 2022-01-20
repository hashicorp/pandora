using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SignalR.v2020_05_01.SignalR;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ACLActionConstant
{
    [Description("Allow")]
    Allow,

    [Description("Deny")]
    Deny,
}
