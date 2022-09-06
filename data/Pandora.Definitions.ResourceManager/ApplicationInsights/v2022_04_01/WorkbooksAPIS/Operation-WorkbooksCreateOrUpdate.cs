using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2022_04_01.WorkbooksAPIS;

internal class WorkbooksCreateOrUpdateOperation : Operations.PutOperation
{
    public override Type? RequestObject() => typeof(WorkbookModel);

    public override ResourceID? ResourceId() => new WorkbookId();

    public override Type? ResponseObject() => typeof(WorkbookModel);

    public override Type? OptionsObject() => typeof(WorkbooksCreateOrUpdateOperation.WorkbooksCreateOrUpdateOptions);

    internal class WorkbooksCreateOrUpdateOptions
    {
        [QueryStringName("sourceId")]
        [Optional]
        public string SourceId { get; set; }
    }
}
