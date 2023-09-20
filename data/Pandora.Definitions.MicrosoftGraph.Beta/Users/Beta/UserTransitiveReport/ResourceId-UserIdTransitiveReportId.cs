// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserTransitiveReport;

internal class UserIdTransitiveReportId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/transitiveReports/{directoryObjectId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticTransitiveReports", "transitiveReports"),
        ResourceIDSegment.UserSpecified("directoryObjectId")
    };
}
