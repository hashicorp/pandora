// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;

namespace Pandora.Data.Models;

public class ResourceDefinition
{
    public string Name { get; set; }
    public List<ConstantDefinition> Constants { get; set; }
    public List<ModelDefinition> Models { get; set; }
    public List<OperationDefinition> Operations { get; set; }
    public List<ResourceIdDefinition> ResourceIds { get; set; }
}