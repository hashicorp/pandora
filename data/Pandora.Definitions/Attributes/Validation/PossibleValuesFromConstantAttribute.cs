// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;

namespace Pandora.Definitions.Attributes.Validation;

public class PossibleValuesFromConstantAttribute : Attribute
{
    public Type ConstantSource { get; private set; }

    public PossibleValuesFromConstantAttribute(Type constantSource)
    {
        ConstantSource = constantSource;
    }
}