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

internal class ListClusterAdminCredentialsOperation : Operations.PostOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

\t\tpublic override Type? RequestObject() => null;

\t\tpublic override ResourceID? ResourceId() => new ManagedClusterId();

\t\tpublic override Type? ResponseObject() => typeof(CredentialResultsModel);

\t\tpublic override Type? OptionsObject() => typeof(ListClusterAdminCredentialsOperation.ListClusterAdminCredentialsOptions);

\t\tpublic override string? UriSuffix() => "/listClusterAdminCredential";

    internal class ListClusterAdminCredentialsOptions
    {
        [QueryStringName("server-fqdn")]
        [Optional]
        public string ServerFqdn { get; set; }
    }
}
