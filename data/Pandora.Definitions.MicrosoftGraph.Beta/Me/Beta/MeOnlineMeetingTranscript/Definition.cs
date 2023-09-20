// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeOnlineMeetingTranscript;

internal class Definition : ResourceDefinition
{
    public string Name => "MeOnlineMeetingTranscript";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeOnlineMeetingByIdTranscriptOperation(),
        new DeleteMeOnlineMeetingByIdTranscriptByIdOperation(),
        new GetMeOnlineMeetingByIdTranscriptByIdOperation(),
        new GetMeOnlineMeetingByIdTranscriptCountOperation(),
        new ListMeOnlineMeetingByIdTranscriptsOperation(),
        new UpdateMeOnlineMeetingByIdTranscriptByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
