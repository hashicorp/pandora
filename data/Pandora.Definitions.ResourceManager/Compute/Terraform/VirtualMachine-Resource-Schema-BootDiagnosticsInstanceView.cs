using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceBootDiagnosticsInstanceViewSchema
{

    [HclName("console_screenshot_blob_uri")]
    [Optional]
    public string ConsoleScreenshotBlobUri { get; set; }


    [HclName("serial_console_log_blob_uri")]
    [Optional]
    public string SerialConsoleLogBlobUri { get; set; }


    [HclName("status")]
    [Optional]
    public List<VirtualMachineResourceInstanceViewStatusSchema> Status { get; set; }

}
