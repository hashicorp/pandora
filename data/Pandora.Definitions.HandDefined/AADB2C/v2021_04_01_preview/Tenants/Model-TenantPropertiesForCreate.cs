// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

﻿using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;

namespace Pandora.Definitions.HandDefined.AADB2C.v2021_04_01_preview.Tenants;

internal class TenantPropertiesForCreate
{
    [JsonPropertyName("createTenantProperties")]
    [Required]
    public CreateTenantPropertiesModel? CreateTenantProperties { get; set; }
}