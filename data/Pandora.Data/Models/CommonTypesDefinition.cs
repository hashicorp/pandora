// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

﻿using System.Collections.Generic;

namespace Pandora.Data.Models;

public class CommonTypesDefinition
{
    public ServiceDefinitionType ServiceDefinitionType { get; set; }
    public IEnumerable<ConstantDefinition> Constants { get; set; }
    public IEnumerable<ModelDefinition> Models { get; set; }
}
