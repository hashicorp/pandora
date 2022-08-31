using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_05_01.FrontDoors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RulesEngineMatchVariableConstant
{
    [Description("IsMobile")]
    IsMobile,

    [Description("PostArgs")]
    PostArgs,

    [Description("QueryString")]
    QueryString,

    [Description("RemoteAddr")]
    RemoteAddr,

    [Description("RequestBody")]
    RequestBody,

    [Description("RequestFilename")]
    RequestFilename,

    [Description("RequestFilenameExtension")]
    RequestFilenameExtension,

    [Description("RequestHeader")]
    RequestHeader,

    [Description("RequestMethod")]
    RequestMethod,

    [Description("RequestPath")]
    RequestPath,

    [Description("RequestScheme")]
    RequestScheme,

    [Description("RequestUri")]
    RequestUri,
}
