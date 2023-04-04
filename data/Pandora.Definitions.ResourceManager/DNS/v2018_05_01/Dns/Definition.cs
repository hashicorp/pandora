using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DNS.v2018_05_01.Dns;

internal class Definition : ResourceDefinition
{
    public string Name => "Dns";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DnsResourceReferenceGetByTargetResourcesOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(RecordTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DnsResourceReferenceModel),
        typeof(DnsResourceReferenceRequestModel),
        typeof(DnsResourceReferenceRequestPropertiesModel),
        typeof(DnsResourceReferenceResultModel),
        typeof(DnsResourceReferenceResultPropertiesModel),
        typeof(SubResourceModel),
    };
}
