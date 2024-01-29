// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2023_03_01.Scripts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScriptExecutionParameterTypeConstant
{
    [Description("Credential")]
    Credential,

    [Description("SecureValue")]
    SecureValue,

    [Description("Value")]
    Value,
}
