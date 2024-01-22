// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.ComponentModel;

namespace Pandora.Data.Models;

public enum ApiDefinitionsSource
{
    Unknown = 0,

    [Description("ResourceManagerRestApiSpecs")]
    ResourceManagerRestApiSpecs,

    [Description("HandWritten")]
    HandWritten,

    [Description("MicrosoftGraphMetadata")]
    MicrosoftGraphMetadata,
}