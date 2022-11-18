using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2022_07_07.AttachedDatabaseConfigurations;

internal class CheckNameAvailabilityOperation : Operations.PostOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(AttachedDatabaseConfigurationsCheckNameRequestModel);

\t\tpublic override ResourceID? ResourceId() => new ClusterId();

\t\tpublic override Type? ResponseObject() => typeof(CheckNameResultModel);

\t\tpublic override string? UriSuffix() => "/attachedDatabaseConfigurationCheckNameAvailability";


}
