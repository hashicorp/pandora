// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2015-05-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AnalyticsItemsAPIs.Definition(),
        new ComponentAnnotationsAPIs.Definition(),
        new ComponentApiKeysAPIs.Definition(),
        new ComponentContinuousExportAPIs.Definition(),
        new ComponentFeaturesAndPricingAPIs.Definition(),
        new ComponentProactiveDetectionAPIs.Definition(),
        new ComponentWorkItemConfigsAPIs.Definition(),
        new ComponentsAPIs.Definition(),
        new FavoritesAPIs.Definition(),
        new MyworkbooksAPIs.Definition(),
        new WebTestLocationsAPIs.Definition(),
        new WebTestsAPIs.Definition(),
        new WorkbooksAPIs.Definition(),
    };
}
