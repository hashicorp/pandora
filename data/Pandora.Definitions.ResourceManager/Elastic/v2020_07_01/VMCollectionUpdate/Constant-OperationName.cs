using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Elastic.v2020_07_01.VMCollectionUpdate;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperationNameConstant
{
    [Description("Add")]
    Add,

    [Description("Delete")]
    Delete,
}
