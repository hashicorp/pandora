// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta.DirectoryDeviceLocalCredential;

internal class DirectoryDeviceLocalCredentialId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/directory/deviceLocalCredentials/{deviceLocalCredentialInfoId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticDirectory", "directory"),
        ResourceIDSegment.Static("staticDeviceLocalCredentials", "deviceLocalCredentials"),
        ResourceIDSegment.UserSpecified("deviceLocalCredentialInfoId")
    };
}
