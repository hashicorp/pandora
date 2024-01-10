// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Applications.Beta.ApplicationExtensionProperty;

internal class ApplicationIdExtensionPropertyId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/applications/{applicationId}/extensionProperties/{extensionPropertyId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticApplications", "applications"),
        ResourceIDSegment.UserSpecified("applicationId"),
        ResourceIDSegment.Static("staticExtensionProperties", "extensionProperties"),
        ResourceIDSegment.UserSpecified("extensionPropertyId")
    };
}
