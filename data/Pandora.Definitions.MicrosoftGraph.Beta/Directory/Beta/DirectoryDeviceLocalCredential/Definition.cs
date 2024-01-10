// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta.DirectoryDeviceLocalCredential;

internal class Definition : ResourceDefinition
{
    public string Name => "DirectoryDeviceLocalCredential";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateDirectoryDeviceLocalCredentialOperation(),
        new DeleteDirectoryDeviceLocalCredentialByIdOperation(),
        new GetDirectoryDeviceLocalCredentialByIdOperation(),
        new GetDirectoryDeviceLocalCredentialCountOperation(),
        new ListDirectoryDeviceLocalCredentialsOperation(),
        new UpdateDirectoryDeviceLocalCredentialByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
