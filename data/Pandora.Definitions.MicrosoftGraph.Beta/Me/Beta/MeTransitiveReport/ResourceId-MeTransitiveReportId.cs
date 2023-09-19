// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeTransitiveReport;

internal class MeTransitiveReportId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/transitiveReports/{directoryObjectId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticTransitiveReports", "transitiveReports"),
        ResourceIDSegment.UserSpecified("directoryObjectId")
    };
}
