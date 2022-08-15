using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.Encodings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JobErrorCodeConstant
{
    [Description("ConfigurationUnsupported")]
    ConfigurationUnsupported,

    [Description("ContentMalformed")]
    ContentMalformed,

    [Description("ContentUnsupported")]
    ContentUnsupported,

    [Description("DownloadNotAccessible")]
    DownloadNotAccessible,

    [Description("DownloadTransientError")]
    DownloadTransientError,

    [Description("ServiceError")]
    ServiceError,

    [Description("ServiceTransientError")]
    ServiceTransientError,

    [Description("UploadNotAccessible")]
    UploadNotAccessible,

    [Description("UploadTransientError")]
    UploadTransientError,
}
