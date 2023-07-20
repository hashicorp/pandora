using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2022_08_29.CertificateObjectGlobalRulestack;

internal class CertificateId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/providers/PaloAltoNetworks.Cloudngfw/globalRulestacks/{globalRulestackName}/certificates/{certificateName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticPaloAltoNetworksCloudngfw", "PaloAltoNetworks.Cloudngfw"),
        ResourceIDSegment.Static("staticGlobalRulestacks", "globalRulestacks"),
        ResourceIDSegment.UserSpecified("globalRulestackName"),
        ResourceIDSegment.Static("staticCertificates", "certificates"),
        ResourceIDSegment.UserSpecified("certificateName"),
    };
}
