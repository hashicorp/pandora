// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Compute.v2023_04_02;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-04-02";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new DiskAccesses.Definition(),
        new DiskEncryptionSets.Definition(),
        new Disks.Definition(),
        new IncrementalRestorePoints.Definition(),
        new Snapshots.Definition(),
    };
}
