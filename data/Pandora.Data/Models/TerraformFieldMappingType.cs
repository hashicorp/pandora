// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Data.Models;

public enum TerraformFieldMappingType
{
    Unknown,

    DirectAssignment,
    Manual,
    ModelToModel,
}