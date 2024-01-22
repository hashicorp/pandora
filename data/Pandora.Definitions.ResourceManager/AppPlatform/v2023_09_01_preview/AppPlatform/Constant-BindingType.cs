// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AppPlatform.v2023_09_01_preview.AppPlatform;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BindingTypeConstant
{
    [Description("ApacheSkyWalking")]
    ApacheSkyWalking,

    [Description("AppDynamics")]
    AppDynamics,

    [Description("ApplicationInsights")]
    ApplicationInsights,

    [Description("CACertificates")]
    CACertificates,

    [Description("Dynatrace")]
    Dynatrace,

    [Description("ElasticAPM")]
    ElasticAPM,

    [Description("NewRelic")]
    NewRelic,
}
