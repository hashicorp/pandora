using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.TenantConfiguration;

internal class DeployOperation : Operations.PostOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

\t\tpublic override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(DeployConfigurationParametersModel);

\t\tpublic override ResourceID? ResourceId() => new ServiceId();

\t\tpublic override Type? ResponseObject() => typeof(OperationResultContractModel);

\t\tpublic override string? UriSuffix() => "/tenant/configuration/deploy";


}
