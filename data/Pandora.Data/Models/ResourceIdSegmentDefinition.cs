// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Data.Models;

public class ResourceIdSegmentDefinition
{
    public string? ConstantReference { get; set; }

    public string ExampleValue { get; set; }

    public string? FixedValue { get; set; }

    public string Name { get; set; }

    public ResourceIdSegmentType Type { get; set; }
}