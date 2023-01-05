using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2022_11_11.AttachedDatabaseConfigurations;

internal class CheckNameAvailabilityOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(AttachedDatabaseConfigurationsCheckNameRequestModel);

    public override ResourceID? ResourceId() => new ClusterId();

    public override Type? ResponseObject() => typeof(CheckNameResultModel);

    public override string? UriSuffix() => "/attachedDatabaseConfigurationCheckNameAvailability";


}
