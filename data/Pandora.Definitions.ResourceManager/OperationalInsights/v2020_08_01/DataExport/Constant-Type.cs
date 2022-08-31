using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2020_08_01.DataExport;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TypeConstant
{
    [Description("EventHub")]
    EventHub,

    [Description("StorageAccount")]
    StorageAccount,
}
