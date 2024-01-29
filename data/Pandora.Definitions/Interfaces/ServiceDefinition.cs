// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

﻿using System.Collections.Generic;

namespace Pandora.Definitions.Interfaces;

public interface ServiceDefinition
{
    public string Name { get; }
    public bool Generate { get; }
    public string? ResourceProvider { get; }

    public string? TerraformPackageName { get; }

    /// <summary>
    /// TerraformResources returns a list of TerraformResourceDefinitions for this API Version.
    /// </summary>
    IEnumerable<TerraformResourceDefinition> TerraformResources { get; }
}