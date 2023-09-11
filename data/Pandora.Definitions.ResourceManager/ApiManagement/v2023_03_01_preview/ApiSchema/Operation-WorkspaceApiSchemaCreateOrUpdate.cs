using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.ApiSchema;

internal class WorkspaceApiSchemaCreateOrUpdateOperation : Pandora.Definitions.Operations.PutOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.Created,
                HttpStatusCode.OK,
        };

    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(SchemaContractModel);

    public override ResourceID? ResourceId() => new WorkspaceApiSchemaId();

    public override Type? ResponseObject() => typeof(SchemaContractModel);

    public override Type? OptionsObject() => typeof(WorkspaceApiSchemaCreateOrUpdateOperation.WorkspaceApiSchemaCreateOrUpdateOptions);

    internal class WorkspaceApiSchemaCreateOrUpdateOptions
    {
        [HeaderName("If-Match")]
        [Optional]
        public string IfMatch { get; set; }
    }
}
