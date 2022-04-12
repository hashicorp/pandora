using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsRevisions;


internal class ContainerAppProbeModel
{
    [JsonPropertyName("failureThreshold")]
    public int? FailureThreshold { get; set; }

    [JsonPropertyName("httpGet")]
    public ContainerAppProbeHttpGetModel? HttpGet { get; set; }

    [JsonPropertyName("initialDelaySeconds")]
    public int? InitialDelaySeconds { get; set; }

    [JsonPropertyName("periodSeconds")]
    public int? PeriodSeconds { get; set; }

    [JsonPropertyName("successThreshold")]
    public int? SuccessThreshold { get; set; }

    [JsonPropertyName("tcpSocket")]
    public ContainerAppProbeTcpSocketModel? TcpSocket { get; set; }

    [JsonPropertyName("terminationGracePeriodSeconds")]
    public int? TerminationGracePeriodSeconds { get; set; }

    [JsonPropertyName("timeoutSeconds")]
    public int? TimeoutSeconds { get; set; }

    [JsonPropertyName("type")]
    public TypeConstant? Type { get; set; }
}
