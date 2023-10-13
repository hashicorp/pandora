using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01.ComponentContinuousExportAPIs;

internal class ExportConfigurationsCreateOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(ApplicationInsightsComponentExportRequestModel);

    public override ResourceID? ResourceId() => new ComponentId();

    public override Type? ResponseObject() => typeof(List<ApplicationInsightsComponentExportConfigurationModel>);

    public override string? UriSuffix() => "/exportconfiguration";


}
