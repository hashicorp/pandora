using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.ThreatIntelligence;

internal class IndicatorReplaceTagsOperation : Operations.PostOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(ThreatIntelligenceIndicatorModelModel);

\t\tpublic override ResourceID? ResourceId() => new IndicatorId();

\t\tpublic override Type? ResponseObject() => typeof(ThreatIntelligenceInformationModel);

\t\tpublic override string? UriSuffix() => "/replaceTags";


}
