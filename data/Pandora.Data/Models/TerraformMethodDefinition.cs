// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Data.Models;

public class TerraformMethodDefinition
{
    public bool Generate { get; set; }
    public string MethodName { get; set; }
    public int TimeoutInMinutes { get; set; }
}