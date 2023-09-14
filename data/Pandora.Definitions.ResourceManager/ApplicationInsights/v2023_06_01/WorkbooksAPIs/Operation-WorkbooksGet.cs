using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2023_06_01.WorkbooksAPIs;

internal class WorkbooksGetOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new WorkbookId();

    public override Type? ResponseObject() => typeof(WorkbookModel);

    public override Type? OptionsObject() => typeof(WorkbooksGetOperation.WorkbooksGetOptions);

    internal class WorkbooksGetOptions
    {
        [QueryStringName("canFetchContent")]
        [Optional]
        public bool CanFetchContent { get; set; }
    }
}
