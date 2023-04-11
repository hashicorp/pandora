using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2021_06_01.AssessmentsMetadata;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TechniquesConstant
{
    [Description("Abuse Elevation Control Mechanism")]
    AbuseElevationControlMechanism,

    [Description("Access Token Manipulation")]
    AccessTokenManipulation,

    [Description("Account Discovery")]
    AccountDiscovery,

    [Description("Account Manipulation")]
    AccountManipulation,

    [Description("Active Scanning")]
    ActiveScanning,

    [Description("Application Layer Protocol")]
    ApplicationLayerProtocol,

    [Description("Audio Capture")]
    AudioCapture,

    [Description("Boot or Logon Autostart Execution")]
    BootOrLogonAutostartExecution,

    [Description("Boot or Logon Initialization Scripts")]
    BootOrLogonInitializationScripts,

    [Description("Brute Force")]
    BruteForce,

    [Description("Cloud Infrastructure Discovery")]
    CloudInfrastructureDiscovery,

    [Description("Cloud Service Dashboard")]
    CloudServiceDashboard,

    [Description("Cloud Service Discovery")]
    CloudServiceDiscovery,

    [Description("Command and Scripting Interpreter")]
    CommandAndScriptingInterpreter,

    [Description("Compromise Client Software Binary")]
    CompromiseClientSoftwareBinary,

    [Description("Compromise Infrastructure")]
    CompromiseInfrastructure,

    [Description("Container and Resource Discovery")]
    ContainerAndResourceDiscovery,

    [Description("Create Account")]
    CreateAccount,

    [Description("Create or Modify System Process")]
    CreateOrModifySystemProcess,

    [Description("Credentials from Password Stores")]
    CredentialsFromPasswordStores,

    [Description("Data Destruction")]
    DataDestruction,

    [Description("Data Encrypted for Impact")]
    DataEncryptedForImpact,

    [Description("Data from Cloud Storage Object")]
    DataFromCloudStorageObject,

    [Description("Data from Configuration Repository")]
    DataFromConfigurationRepository,

    [Description("Data from Information Repositories")]
    DataFromInformationRepositories,

    [Description("Data from Local System")]
    DataFromLocalSystem,

    [Description("Data Manipulation")]
    DataManipulation,

    [Description("Data Staged")]
    DataStaged,

    [Description("Defacement")]
    Defacement,

    [Description("Deobfuscate/Decode Files or Information")]
    DeobfuscateDecodeFilesOrInformation,

    [Description("Disk Wipe")]
    DiskWipe,

    [Description("Domain Trust Discovery")]
    DomainTrustDiscovery,

    [Description("Drive-by Compromise")]
    DriveNegativebyCompromise,

    [Description("Dynamic Resolution")]
    DynamicResolution,

    [Description("Endpoint Denial of Service")]
    EndpointDenialOfService,

    [Description("Event Triggered Execution")]
    EventTriggeredExecution,

    [Description("Exfiltration Over Alternative Protocol")]
    ExfiltrationOverAlternativeProtocol,

    [Description("Exploit Public-Facing Application")]
    ExploitPublicNegativeFacingApplication,

    [Description("Exploitation for Client Execution")]
    ExploitationForClientExecution,

    [Description("Exploitation for Credential Access")]
    ExploitationForCredentialAccess,

    [Description("Exploitation for Defense Evasion")]
    ExploitationForDefenseEvasion,

    [Description("Exploitation for Privilege Escalation")]
    ExploitationForPrivilegeEscalation,

    [Description("Exploitation of Remote Services")]
    ExploitationOfRemoteServices,

    [Description("External Remote Services")]
    ExternalRemoteServices,

    [Description("Fallback Channels")]
    FallbackChannels,

    [Description("File and Directory Discovery")]
    FileAndDirectoryDiscovery,

    [Description("File and Directory Permissions Modification")]
    FileAndDirectoryPermissionsModification,

    [Description("Gather Victim Network Information")]
    GatherVictimNetworkInformation,

    [Description("Hide Artifacts")]
    HideArtifacts,

    [Description("Hijack Execution Flow")]
    HijackExecutionFlow,

    [Description("Impair Defenses")]
    ImpairDefenses,

    [Description("Implant Container Image")]
    ImplantContainerImage,

    [Description("Indicator Removal on Host")]
    IndicatorRemovalOnHost,

    [Description("Indirect Command Execution")]
    IndirectCommandExecution,

    [Description("Ingress Tool Transfer")]
    IngressToolTransfer,

    [Description("Input Capture")]
    InputCapture,

    [Description("Inter-Process Communication")]
    InterNegativeProcessCommunication,

    [Description("Lateral Tool Transfer")]
    LateralToolTransfer,

    [Description("Man-in-the-Middle")]
    ManNegativeinNegativetheNegativeMiddle,

    [Description("Masquerading")]
    Masquerading,

    [Description("Modify Authentication Process")]
    ModifyAuthenticationProcess,

    [Description("Modify Registry")]
    ModifyRegistry,

    [Description("Network Denial of Service")]
    NetworkDenialOfService,

    [Description("Network Service Scanning")]
    NetworkServiceScanning,

    [Description("Network Sniffing")]
    NetworkSniffing,

    [Description("Non-Application Layer Protocol")]
    NonNegativeApplicationLayerProtocol,

    [Description("Non-Standard Port")]
    NonNegativeStandardPort,

    [Description("OS Credential Dumping")]
    OSCredentialDumping,

    [Description("Obfuscated Files or Information")]
    ObfuscatedFilesOrInformation,

    [Description("Obtain Capabilities")]
    ObtainCapabilities,

    [Description("Office Application Startup")]
    OfficeApplicationStartup,

    [Description("Permission Groups Discovery")]
    PermissionGroupsDiscovery,

    [Description("Phishing")]
    Phishing,

    [Description("Pre-OS Boot")]
    PreNegativeOSBoot,

    [Description("Process Discovery")]
    ProcessDiscovery,

    [Description("Process Injection")]
    ProcessInjection,

    [Description("Protocol Tunneling")]
    ProtocolTunneling,

    [Description("Proxy")]
    Proxy,

    [Description("Query Registry")]
    QueryRegistry,

    [Description("Remote Access Software")]
    RemoteAccessSoftware,

    [Description("Remote Service Session Hijacking")]
    RemoteServiceSessionHijacking,

    [Description("Remote Services")]
    RemoteServices,

    [Description("Remote System Discovery")]
    RemoteSystemDiscovery,

    [Description("Resource Hijacking")]
    ResourceHijacking,

    [Description("SQL Stored Procedures")]
    SQLStoredProcedures,

    [Description("Scheduled Task/Job")]
    ScheduledTaskJob,

    [Description("Screen Capture")]
    ScreenCapture,

    [Description("Search Victim-Owned Websites")]
    SearchVictimNegativeOwnedWebsites,

    [Description("Server Software Component")]
    ServerSoftwareComponent,

    [Description("Service Stop")]
    ServiceStop,

    [Description("Signed Binary Proxy Execution")]
    SignedBinaryProxyExecution,

    [Description("Software Deployment Tools")]
    SoftwareDeploymentTools,

    [Description("Steal or Forge Kerberos Tickets")]
    StealOrForgeKerberosTickets,

    [Description("Subvert Trust Controls")]
    SubvertTrustControls,

    [Description("Supply Chain Compromise")]
    SupplyChainCompromise,

    [Description("System Information Discovery")]
    SystemInformationDiscovery,

    [Description("Taint Shared Content")]
    TaintSharedContent,

    [Description("Traffic Signaling")]
    TrafficSignaling,

    [Description("Transfer Data to Cloud Account")]
    TransferDataToCloudAccount,

    [Description("Trusted Relationship")]
    TrustedRelationship,

    [Description("Unsecured Credentials")]
    UnsecuredCredentials,

    [Description("User Execution")]
    UserExecution,

    [Description("Valid Accounts")]
    ValidAccounts,

    [Description("Windows Management Instrumentation")]
    WindowsManagementInstrumentation,
}
