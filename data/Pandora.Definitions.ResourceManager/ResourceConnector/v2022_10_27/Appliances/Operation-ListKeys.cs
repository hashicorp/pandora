using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ResourceConnector.v2022_10_27.Appliances;

internal class ListKeysOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new ApplianceId();

    public override Type? ResponseObject() => typeof(ApplianceListKeysResultsModel);

    public override Type? OptionsObject() => typeof(ListKeysOperation.ListKeysOptions);

    public override string? UriSuffix() => "/listkeys";

    internal class ListKeysOptions
    {
        [QueryStringName("artifactType")]
        [Optional]
        public string ArtifactType { get; set; }
    }
}
