// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.HandDefined.AADB2C.v2021_04_01_preview;

public class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-04-01-preview";
    public bool Generate => true;
    public bool Preview => true;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Tenants.Definition(),
    };

    public Source Source => Source.HandWritten;
}