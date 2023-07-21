using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_03_02_preview.ManagedClusters;

internal class ListClusterMonitoringUserCredentialsOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new KubernetesClusterId();

    public override Type? ResponseObject() => typeof(CredentialResultsModel);

    public override Type? OptionsObject() => typeof(ListClusterMonitoringUserCredentialsOperation.ListClusterMonitoringUserCredentialsOptions);

    public override string? UriSuffix() => "/listClusterMonitoringUserCredential";

    internal class ListClusterMonitoringUserCredentialsOptions
    {
        [QueryStringName("server-fqdn")]
        [Optional]
        public string ServerFqdn { get; set; }
    }
}
