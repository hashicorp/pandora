using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.Group;

internal class CreateOrUpdateOperation : Operations.PutOperation
{
    public override Type? RequestObject() => typeof(GroupCreateParametersModel);

\t\tpublic override ResourceID? ResourceId() => new GroupId();

\t\tpublic override Type? ResponseObject() => typeof(GroupContractModel);

\t\tpublic override Type? OptionsObject() => typeof(CreateOrUpdateOperation.CreateOrUpdateOptions);

    internal class CreateOrUpdateOptions
    {
        [HeaderName("If-Match")]
        [Optional]
        public string IfMatch { get; set; }
    }
}
