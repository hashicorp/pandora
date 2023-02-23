using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_02_01.ThreatIntelligence;

internal class IndicatorReplaceTagsOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(ThreatIntelligenceIndicatorModelModel);

    public override ResourceID? ResourceId() => new IndicatorId();

    public override Type? ResponseObject() => typeof(ThreatIntelligenceInformationModel);

    public override string? UriSuffix() => "/replaceTags";


}
