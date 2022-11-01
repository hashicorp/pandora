using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_09_02_preview.ManagedClusters;

internal class ListClusterUserCredentialsOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new ManagedClusterId();

    public override Type? ResponseObject() => typeof(CredentialResultsModel);

    public override Type? OptionsObject() => typeof(ListClusterUserCredentialsOperation.ListClusterUserCredentialsOptions);

    public override string? UriSuffix() => "/listClusterUserCredential";

    internal class ListClusterUserCredentialsOptions
    {
        [QueryStringName("format")]
        [Optional]
        public FormatConstant Format { get; set; }

        [QueryStringName("server-fqdn")]
        [Optional]
        public string ServerFqdn { get; set; }
    }
}
