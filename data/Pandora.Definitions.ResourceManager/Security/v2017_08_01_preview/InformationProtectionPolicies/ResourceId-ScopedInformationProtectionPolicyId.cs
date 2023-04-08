using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2017_08_01_preview.InformationProtectionPolicies;

internal class ScopedInformationProtectionPolicyId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/{scope}/providers/Microsoft.Security/informationProtectionPolicies/{informationProtectionPolicyName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Scope("scope"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftSecurity", "Microsoft.Security"),
        ResourceIDSegment.Static("staticInformationProtectionPolicies", "informationProtectionPolicies"),
        ResourceIDSegment.Constant("informationProtectionPolicyName", typeof(InformationProtectionPolicyNameConstant)),
    };
}
