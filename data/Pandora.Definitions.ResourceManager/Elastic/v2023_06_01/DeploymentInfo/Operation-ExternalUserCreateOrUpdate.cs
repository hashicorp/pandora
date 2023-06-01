using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Elastic.v2023_06_01.DeploymentInfo;

internal class ExternalUserCreateOrUpdateOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(ExternalUserInfoModel);

    public override ResourceID? ResourceId() => new MonitorId();

    public override Type? ResponseObject() => typeof(ExternalUserCreationResponseModel);

    public override string? UriSuffix() => "/createOrUpdateExternalUser";


}
