using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AnalysisServices.v2017_08_01.Servers;

internal class CheckNameAvailabilityOperation : Operations.PostOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(CheckServerNameAvailabilityParametersModel);

\t\tpublic override ResourceID? ResourceId() => new LocationId();

\t\tpublic override Type? ResponseObject() => typeof(CheckServerNameAvailabilityResultModel);

\t\tpublic override string? UriSuffix() => "/checkNameAvailability";


}
