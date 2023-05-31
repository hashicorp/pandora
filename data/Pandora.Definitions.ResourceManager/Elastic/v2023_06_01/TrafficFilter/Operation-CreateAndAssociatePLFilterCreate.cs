using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Elastic.v2023_06_01.TrafficFilter;

internal class CreateAndAssociatePLFilterCreateOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

    public override bool LongRunning() => true;

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new MonitorId();

    public override Type? OptionsObject() => typeof(CreateAndAssociatePLFilterCreateOperation.CreateAndAssociatePLFilterCreateOptions);

    public override string? UriSuffix() => "/createAndAssociatePLFilter";

    internal class CreateAndAssociatePLFilterCreateOptions
    {
        [QueryStringName("name")]
        [Optional]
        public string Name { get; set; }

        [QueryStringName("privateEndpointGuid")]
        [Optional]
        public string PrivateEndpointGuid { get; set; }

        [QueryStringName("privateEndpointName")]
        [Optional]
        public string PrivateEndpointName { get; set; }
    }
}
