// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;

namespace Pandora.Definitions.Attributes;

public class DateFormatAttribute : Attribute
{
    public enum DateFormat
    {
        RFC3339,
        RFC3339Nano
    }

    public string Format { get; }

    public DateFormatAttribute(DateFormat format)
    {
        Format = format.ToString();
    }
}