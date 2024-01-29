// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-07-01-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Actions.Definition(),
        new AlertRuleTemplates.Definition(),
        new AlertRules.Definition(),
        new AutomationRules.Definition(),
        new Bookmark.Definition(),
        new BookmarkRelations.Definition(),
        new Bookmarks.Definition(),
        new CheckDataConnectorRequirements.Definition(),
        new DataConnectors.Definition(),
        new DataConnectorsConnect.Definition(),
        new DataConnectorsDisconnect.Definition(),
        new Enrichment.Definition(),
        new Entities.Definition(),
        new EntityQueries.Definition(),
        new EntityRelations.Definition(),
        new IncidentAlerts.Definition(),
        new IncidentBookmarks.Definition(),
        new IncidentComments.Definition(),
        new IncidentEntities.Definition(),
        new IncidentRelations.Definition(),
        new IncidentTeam.Definition(),
        new Incidents.Definition(),
        new ManualTrigger.Definition(),
        new Metadata.Definition(),
        new OfficeConsents.Definition(),
        new Repositories.Definition(),
        new SecurityMLAnalyticsSettings.Definition(),
        new SentinelOnboardingStates.Definition(),
        new Settings.Definition(),
        new SourceControls.Definition(),
        new ThreatIntelligence.Definition(),
        new WatchlistItems.Definition(),
        new Watchlists.Definition(),
    };
}
