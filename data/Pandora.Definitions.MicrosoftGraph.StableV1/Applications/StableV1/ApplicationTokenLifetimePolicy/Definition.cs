// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Applications.StableV1.ApplicationTokenLifetimePolicy;

internal class Definition : ResourceDefinition
{
    public string Name => "ApplicationTokenLifetimePolicy";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AddApplicationByIdTokenLifetimePolicyRefOperation(),
        new GetApplicationByIdTokenLifetimePolicyCountOperation(),
        new ListApplicationByIdTokenLifetimePoliciesOperation(),
        new ListApplicationByIdTokenLifetimePolicyRefsOperation(),
        new RemoveApplicationByIdTokenLifetimePolicyByIdRefOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
