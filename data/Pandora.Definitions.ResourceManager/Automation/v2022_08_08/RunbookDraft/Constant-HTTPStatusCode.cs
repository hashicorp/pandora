using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2022_08_08.RunbookDraft;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HTTPStatusCodeConstant
{
    [Description("Accepted")]
    Accepted,

    [Description("Ambiguous")]
    Ambiguous,

    [Description("BadGateway")]
    BadGateway,

    [Description("BadRequest")]
    BadRequest,

    [Description("Conflict")]
    Conflict,

    [Description("Continue")]
    Continue,

    [Description("Created")]
    Created,

    [Description("ExpectationFailed")]
    ExpectationFailed,

    [Description("Forbidden")]
    Forbidden,

    [Description("Found")]
    Found,

    [Description("GatewayTimeout")]
    GatewayTimeout,

    [Description("Gone")]
    Gone,

    [Description("HttpVersionNotSupported")]
    HTTPVersionNotSupported,

    [Description("InternalServerError")]
    InternalServerError,

    [Description("LengthRequired")]
    LengthRequired,

    [Description("MethodNotAllowed")]
    MethodNotAllowed,

    [Description("Moved")]
    Moved,

    [Description("MovedPermanently")]
    MovedPermanently,

    [Description("MultipleChoices")]
    MultipleChoices,

    [Description("NoContent")]
    NoContent,

    [Description("NonAuthoritativeInformation")]
    NonAuthoritativeInformation,

    [Description("NotAcceptable")]
    NotAcceptable,

    [Description("NotFound")]
    NotFound,

    [Description("NotImplemented")]
    NotImplemented,

    [Description("NotModified")]
    NotModified,

    [Description("OK")]
    OK,

    [Description("PartialContent")]
    PartialContent,

    [Description("PaymentRequired")]
    PaymentRequired,

    [Description("PreconditionFailed")]
    PreconditionFailed,

    [Description("ProxyAuthenticationRequired")]
    ProxyAuthenticationRequired,

    [Description("Redirect")]
    Redirect,

    [Description("RedirectKeepVerb")]
    RedirectKeepVerb,

    [Description("RedirectMethod")]
    RedirectMethod,

    [Description("RequestEntityTooLarge")]
    RequestEntityTooLarge,

    [Description("RequestTimeout")]
    RequestTimeout,

    [Description("RequestUriTooLong")]
    RequestUriTooLong,

    [Description("RequestedRangeNotSatisfiable")]
    RequestedRangeNotSatisfiable,

    [Description("ResetContent")]
    ResetContent,

    [Description("SeeOther")]
    SeeOther,

    [Description("ServiceUnavailable")]
    ServiceUnavailable,

    [Description("SwitchingProtocols")]
    SwitchingProtocols,

    [Description("TemporaryRedirect")]
    TemporaryRedirect,

    [Description("Unauthorized")]
    Unauthorized,

    [Description("UnsupportedMediaType")]
    UnsupportedMediaType,

    [Description("Unused")]
    Unused,

    [Description("UpgradeRequired")]
    UpgradeRequired,

    [Description("UseProxy")]
    UseProxy,
}
