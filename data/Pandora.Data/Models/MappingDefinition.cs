// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Data.Models;

public class MappingDefinition
{
    public string Path { get; set; }
    public string Model { get; set; }
    public bool Manual { get; set; }
}