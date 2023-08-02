using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;


internal class ProcessInfoPropertiesModel
{
    [JsonPropertyName("children")]
    public List<string>? Children { get; set; }

    [JsonPropertyName("command_line")]
    public string? CommandLine { get; set; }

    [JsonPropertyName("deployment_name")]
    public string? DeploymentName { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("environment_variables")]
    public Dictionary<string, string>? EnvironmentVariables { get; set; }

    [JsonPropertyName("file_name")]
    public string? FileName { get; set; }

    [JsonPropertyName("handle_count")]
    public int? HandleCount { get; set; }

    [JsonPropertyName("href")]
    public string? Href { get; set; }

    [JsonPropertyName("identifier")]
    public int? Identifier { get; set; }

    [JsonPropertyName("iis_profile_timeout_in_seconds")]
    public float? IisProfileTimeoutInSeconds { get; set; }

    [JsonPropertyName("is_iis_profile_running")]
    public bool? IsIisProfileRunning { get; set; }

    [JsonPropertyName("is_profile_running")]
    public bool? IsProfileRunning { get; set; }

    [JsonPropertyName("is_scm_site")]
    public bool? IsScmSite { get; set; }

    [JsonPropertyName("is_webjob")]
    public bool? IsWebjob { get; set; }

    [JsonPropertyName("minidump")]
    public string? Minidump { get; set; }

    [JsonPropertyName("module_count")]
    public int? ModuleCount { get; set; }

    [JsonPropertyName("modules")]
    public List<ProcessModuleInfoModel>? Modules { get; set; }

    [JsonPropertyName("non_paged_system_memory")]
    public int? NonPagedSystemMemory { get; set; }

    [JsonPropertyName("open_file_handles")]
    public List<string>? OpenFileHandles { get; set; }

    [JsonPropertyName("paged_memory")]
    public int? PagedMemory { get; set; }

    [JsonPropertyName("paged_system_memory")]
    public int? PagedSystemMemory { get; set; }

    [JsonPropertyName("parent")]
    public string? Parent { get; set; }

    [JsonPropertyName("peak_paged_memory")]
    public int? PeakPagedMemory { get; set; }

    [JsonPropertyName("peak_virtual_memory")]
    public int? PeakVirtualMemory { get; set; }

    [JsonPropertyName("peak_working_set")]
    public int? PeakWorkingSet { get; set; }

    [JsonPropertyName("private_memory")]
    public int? PrivateMemory { get; set; }

    [JsonPropertyName("privileged_cpu_time")]
    public string? PrivilegedCpuTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("start_time")]
    public DateTime? StartTime { get; set; }

    [JsonPropertyName("thread_count")]
    public int? ThreadCount { get; set; }

    [JsonPropertyName("threads")]
    public List<ProcessThreadInfoModel>? Threads { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("time_stamp")]
    public DateTime? TimeStamp { get; set; }

    [JsonPropertyName("total_cpu_time")]
    public string? TotalCpuTime { get; set; }

    [JsonPropertyName("user_cpu_time")]
    public string? UserCpuTime { get; set; }

    [JsonPropertyName("user_name")]
    public string? UserName { get; set; }

    [JsonPropertyName("virtual_memory")]
    public int? VirtualMemory { get; set; }

    [JsonPropertyName("working_set")]
    public int? WorkingSet { get; set; }
}
