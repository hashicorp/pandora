using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataShare.v2019_11_01.ConsumerInvitation;

internal class Definition : ResourceDefinition
{
    public string Name => "ConsumerInvitation";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListInvitationsOperation(),
        new RejectInvitationOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(InvitationStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ConsumerInvitationModel),
        typeof(ConsumerInvitationPropertiesModel),
    };
}
