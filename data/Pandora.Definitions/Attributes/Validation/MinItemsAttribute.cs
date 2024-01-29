// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;

namespace Pandora.Definitions.Attributes.Validation;

public class MinItemsAttribute : Attribute
{
    public int MinItems { get; private set; }

    public MinItemsAttribute(int minItems)
    {
        MinItems = minItems;
    }
}