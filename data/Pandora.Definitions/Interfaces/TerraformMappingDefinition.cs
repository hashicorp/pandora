// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Mappings;

namespace Pandora.Definitions.Interfaces;

public interface TerraformMappingDefinition
{
    public List<MappingType> Mappings { get; }
}