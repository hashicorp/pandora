using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_01_15.BackupCrrJobs;

internal class ListOperation : Pandora.Definitions.Operations.ListOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override Type? RequestObject() => typeof(CrrJobRequestModel);

    public override ResourceID? ResourceId() => new LocationId();

    public override Type NestedItemType() => typeof(JobResourceModel);

    public override Type? OptionsObject() => typeof(ListOperation.ListOptions);

    public override string? UriSuffix() => "/backupCrrJobs";

    public override System.Net.Http.HttpMethod Method() => System.Net.Http.HttpMethod.Post;

    internal class ListOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
