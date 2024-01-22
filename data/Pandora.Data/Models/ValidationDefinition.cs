// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;

namespace Pandora.Data.Models;

public class ValidationDefinition
{
    public ValidationType ValidationType { get; set; }

    public List<object>? Values { get; set; }
}