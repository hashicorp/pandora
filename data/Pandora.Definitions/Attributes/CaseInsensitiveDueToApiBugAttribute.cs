// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;

namespace Pandora.Definitions.Attributes;

public class CaseInsensitiveDueToApiBugAttribute : Attribute
{
    private string _bugUri;

    public CaseInsensitiveDueToApiBugAttribute(string bugUri)
    {
        _bugUri = bugUri;
    }
}