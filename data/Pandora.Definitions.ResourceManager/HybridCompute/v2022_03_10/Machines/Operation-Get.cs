using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HybridCompute.v2022_03_10.Machines;

internal class GetOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new MachineId();

\t\tpublic override Type? ResponseObject() => typeof(MachineModel);

\t\tpublic override Type? OptionsObject() => typeof(GetOperation.GetOptions);

    internal class GetOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public InstanceViewTypesConstant Expand { get; set; }
    }
}
