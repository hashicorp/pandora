using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.VirtualMachine;


internal class VirtualMachineConnectionProfileModel
{
    [JsonPropertyName("adminUsername")]
    public string? AdminUsername { get; set; }

    [JsonPropertyName("nonAdminUsername")]
    public string? NonAdminUsername { get; set; }

    [JsonPropertyName("privateIpAddress")]
    public string? PrivateIpAddress { get; set; }

    [JsonPropertyName("rdpAuthority")]
    public string? RdpAuthority { get; set; }

    [JsonPropertyName("rdpInBrowserUrl")]
    public string? RdpInBrowserUrl { get; set; }

    [JsonPropertyName("sshAuthority")]
    public string? SshAuthority { get; set; }

    [JsonPropertyName("sshInBrowserUrl")]
    public string? SshInBrowserUrl { get; set; }
}
