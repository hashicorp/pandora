using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.PolicyFragment;

internal class GetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new PolicyFragmentId();

    public override Type? ResponseObject() => typeof(PolicyFragmentContractModel);

    public override Type? OptionsObject() => typeof(GetOperation.GetOptions);

    internal class GetOptions
    {
        [QueryStringName("format")]
        [Optional]
        public PolicyFragmentContentFormatConstant Format { get; set; }
    }
}
