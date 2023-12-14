// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Oauth2PermissionGrants.StableV1.Oauth2PermissionGrant;

internal class Definition : ResourceDefinition
{
    public string Name => "Oauth2PermissionGrant";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOauth2PermissionGrantOperation(),
        new DeleteOauth2PermissionGrantByIdOperation(),
        new GetOauth2PermissionGrantByIdOperation(),
        new GetOauth2PermissionGrantCountOperation(),
        new ListOauth2PermissionGrantsOperation(),
        new UpdateOauth2PermissionGrantByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
