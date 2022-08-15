using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2022_04_01.WorkbooksAPIs;

internal class WorkbooksUpdateOperation : Operations.PatchOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Created,
        };

    public override Type? RequestObject() => typeof(WorkbookUpdateParametersModel);

    public override ResourceID? ResourceId() => new WorkbookId();

    public override Type? ResponseObject() => typeof(WorkbookModel);

    public override Type? OptionsObject() => typeof(WorkbooksUpdateOperation.WorkbooksUpdateOptions);

    internal class WorkbooksUpdateOptions
    {
        [QueryStringName("sourceId")]
        [Optional]
        public string SourceId { get; set; }
    }
}
