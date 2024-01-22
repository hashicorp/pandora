// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Data.Models;

public enum ServiceDefinitionType
{
    Unknown = 0,

    ResourceManager = 1,
    DataPlane = 2,
    MicrosoftGraphStableV1 = 3,
    MicrosoftGraphBeta = 4,
}