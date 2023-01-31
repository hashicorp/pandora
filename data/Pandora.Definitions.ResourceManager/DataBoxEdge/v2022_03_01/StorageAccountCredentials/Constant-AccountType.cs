using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.StorageAccountCredentials;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AccountTypeConstant
{
    [Description("BlobStorage")]
    BlobStorage,

    [Description("GeneralPurposeStorage")]
    GeneralPurposeStorage,
}
