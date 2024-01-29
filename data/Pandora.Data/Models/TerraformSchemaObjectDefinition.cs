// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Data.Models;

public class TerraformSchemaObjectDefinition
{
    public TerraformSchemaObjectDefinition? NestedObject { get; set; }

    public string? ReferenceName { get; set; }

    public TerraformSchemaFieldType Type { get; set; }
}

public enum TerraformSchemaFieldType
{
    Boolean,
    DateTime,
    Dictionary,
    Float,
    Integer,
    List,
    Reference,
    Set,
    String,

    EdgeZone,
    IdentitySystemAssigned,
    IdentitySystemAndUserAssigned,
    IdentitySystemOrUserAssigned,
    IdentityUserAssigned,
    Location,
    ResourceGroup,
    Tags,
    Zone,
    Zones,
}