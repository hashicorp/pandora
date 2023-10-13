using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01.MyworkbooksAPIs;

internal class MyWorkbooksListByResourceGroupOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new ResourceGroupId();

    public override Type? ResponseObject() => typeof(MyWorkbooksListResultModel);

    public override Type? OptionsObject() => typeof(MyWorkbooksListByResourceGroupOperation.MyWorkbooksListByResourceGroupOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Insights/myWorkbooks";

    internal class MyWorkbooksListByResourceGroupOptions
    {
        [QueryStringName("canFetchContent")]
        [Optional]
        public bool CanFetchContent { get; set; }

        [QueryStringName("category")]
        public CategoryTypeConstant Category { get; set; }

        [QueryStringName("tags")]
        [Optional]
        public Csv<string> Tags { get; set; }
    }
}
