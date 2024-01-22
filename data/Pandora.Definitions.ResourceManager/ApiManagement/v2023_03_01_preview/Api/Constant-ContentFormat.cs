// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.Api;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ContentFormatConstant
{
    [Description("graphql-link")]
    GraphqlNegativelink,

    [Description("odata")]
    Odata,

    [Description("odata-link")]
    OdataNegativelink,

    [Description("openapi")]
    Openapi,

    [Description("openapi-link")]
    OpenapiNegativelink,

    [Description("openapi+json")]
    OpenapiPositivejson,

    [Description("openapi+json-link")]
    OpenapiPositivejsonNegativelink,

    [Description("swagger-json")]
    SwaggerNegativejson,

    [Description("swagger-link-json")]
    SwaggerNegativelinkNegativejson,

    [Description("wadl-link-json")]
    WadlNegativelinkNegativejson,

    [Description("wadl-xml")]
    WadlNegativexml,

    [Description("wsdl")]
    Wsdl,

    [Description("wsdl-link")]
    WsdlNegativelink,
}
