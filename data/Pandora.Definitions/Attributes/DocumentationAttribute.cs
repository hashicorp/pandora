// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;

namespace Pandora.Definitions.Attributes;

public class DocumentationAttribute : Attribute
{
    public string Markdown { get; }

    public DocumentationAttribute(string markdown)
    {
        Markdown = markdown;
    }
}