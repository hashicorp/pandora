// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;

namespace Pandora.Definitions.Attributes;

public class QueryStringName : Attribute
{
    public string Name { get; }

    public QueryStringName(string name)
    {
        Name = name;
    }
}