using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2023_06_01.WorkbooksAPIs;

internal class WorkbooksUpdateOperation : Pandora.Definitions.Operations.PatchOperation
{
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
