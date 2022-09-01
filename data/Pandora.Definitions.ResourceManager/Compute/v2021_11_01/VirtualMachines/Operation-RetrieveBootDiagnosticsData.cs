using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachines;

internal class RetrieveBootDiagnosticsDataOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new VirtualMachineId();

    public override Type? ResponseObject() => typeof(RetrieveBootDiagnosticsDataResultModel);

    public override Type? OptionsObject() => typeof(RetrieveBootDiagnosticsDataOperation.RetrieveBootDiagnosticsDataOptions);

    public override string? UriSuffix() => "/retrieveBootDiagnosticsData";

    internal class RetrieveBootDiagnosticsDataOptions
    {
        [QueryStringName("sasUriExpirationTimeInMinutes")]
        [Optional]
        public int SasUriExpirationTimeInMinutes { get; set; }
    }
}
