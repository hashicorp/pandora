// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;

namespace Pandora.Definitions.Attributes;

public class HeaderNameAttribute : Attribute
{
    public string Name { get; }

    public HeaderNameAttribute(string name)
    {
        Name = name;
    }
}