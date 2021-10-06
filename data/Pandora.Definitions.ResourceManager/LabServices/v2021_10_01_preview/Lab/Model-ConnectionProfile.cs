using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.Lab
{

    internal class ConnectionProfileModel
    {
        [JsonPropertyName("clientRdpAccess")]
        public ConnectionTypeConstant? ClientRdpAccess { get; set; }

        [JsonPropertyName("clientSshAccess")]
        public ConnectionTypeConstant? ClientSshAccess { get; set; }

        [JsonPropertyName("webRdpAccess")]
        public ConnectionTypeConstant? WebRdpAccess { get; set; }

        [JsonPropertyName("webSshAccess")]
        public ConnectionTypeConstant? WebSshAccess { get; set; }
    }
}
