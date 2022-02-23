using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.FileService;


internal class SmbSettingModel
{
    [JsonPropertyName("authenticationMethods")]
    public string? AuthenticationMethods { get; set; }

    [JsonPropertyName("channelEncryption")]
    public string? ChannelEncryption { get; set; }

    [JsonPropertyName("kerberosTicketEncryption")]
    public string? KerberosTicketEncryption { get; set; }

    [JsonPropertyName("multichannel")]
    public MultichannelModel? Multichannel { get; set; }

    [JsonPropertyName("versions")]
    public string? Versions { get; set; }
}
