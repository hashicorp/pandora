using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.PublicIPPrefixes;

internal class Definition : ResourceDefinition
{
    public string Name => "PublicIPPrefixes";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListAllOperation(),
        new UpdateTagsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(IPVersionConstant),
        typeof(NatGatewaySkuNameConstant),
        typeof(ProvisioningStateConstant),
        typeof(PublicIPPrefixSkuNameConstant),
        typeof(PublicIPPrefixSkuTierConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(IPTagModel),
        typeof(NatGatewayModel),
        typeof(NatGatewayPropertiesFormatModel),
        typeof(NatGatewaySkuModel),
        typeof(PublicIPPrefixModel),
        typeof(PublicIPPrefixPropertiesFormatModel),
        typeof(PublicIPPrefixSkuModel),
        typeof(ReferencedPublicIPAddressModel),
        typeof(SubResourceModel),
        typeof(TagsObjectModel),
    };
}
