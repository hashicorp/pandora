using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.Diagnostics;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IssueTypeConstant
{
    [Description("AppCrash")]
    AppCrash,

    [Description("AppDeployment")]
    AppDeployment,

    [Description("AseDeployment")]
    AseDeployment,

    [Description("Other")]
    Other,

    [Description("PlatformIssue")]
    PlatformIssue,

    [Description("RuntimeIssueDetected")]
    RuntimeIssueDetected,

    [Description("ServiceIncident")]
    ServiceIncident,

    [Description("UserIssue")]
    UserIssue,
}
