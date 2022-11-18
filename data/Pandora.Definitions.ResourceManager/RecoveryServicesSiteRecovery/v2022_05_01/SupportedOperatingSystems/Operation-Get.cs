using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.SupportedOperatingSystems;

internal class GetOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new VaultId();

\t\tpublic override Type? ResponseObject() => typeof(SupportedOperatingSystemsModel);

\t\tpublic override Type? OptionsObject() => typeof(GetOperation.GetOptions);

\t\tpublic override string? UriSuffix() => "/replicationSupportedOperatingSystems";

    internal class GetOptions
    {
        [QueryStringName("instanceType")]
        [Optional]
        public string InstanceType { get; set; }
    }
}
