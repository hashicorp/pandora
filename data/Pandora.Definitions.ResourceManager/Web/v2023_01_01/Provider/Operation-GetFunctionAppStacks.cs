using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.Provider;

internal class GetFunctionAppStacksOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override Type NestedItemType() => typeof(FunctionAppStackModel);

    public override Type? OptionsObject() => typeof(GetFunctionAppStacksOperation.GetFunctionAppStacksOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Web/functionAppStacks";

    internal class GetFunctionAppStacksOptions
    {
        [QueryStringName("stackOsType")]
        [Optional]
        public ProviderStackOsTypeConstant StackOsType { get; set; }
    }
}
