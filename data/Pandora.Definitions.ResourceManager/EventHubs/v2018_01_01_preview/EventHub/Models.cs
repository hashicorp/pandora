using System.ComponentModel;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;

namespace Pandora.Definitions.ResourceManager.EventHubs.v2018_01_01_preview.EventHub
{
    internal class CreateEventHubInput
    {
        [JsonPropertyName("properties")]
        public CreateEventHubProperties Properties { get; set; }
    }

    internal class CreateEventHubProperties
    {
        [JsonPropertyName("captureDescription")]
        [Optional]
        [ForceNew]
        public CaptureDescription CaptureDescription { get; set; }
        
        [JsonPropertyName("messageRetentionInDays")]
        [Optional]
        [FieldValidation(Type = FieldValidationType.Range, StartRange = 1, EndRange = 7)]
        public int MessageRetentionInDays { get; set; }
        
        [JsonPropertyName("partitionCount")]
        [Optional]
        [FieldValidation(Type = FieldValidationType.Range, StartRange = 1, EndRange = 32)]
        public int PartitionCount { get; set; }
    }

    internal class CaptureDescription
    {
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }
        
        [JsonPropertyName("encoding")]
        [Optional]
        public Encoding Encoding { get; set; }
        
        [JsonPropertyName("intervalInSeconds")]
        [Optional]
        public int IntervalInSeconds { get; set; }
        
        [JsonPropertyName("sizeLimitsInBytes")]
        [Optional]
        public int SizeLimitInBytes { get; set; }
        
        [JsonPropertyName("destination")]
        [Optional]
        public CaptureDestination CaptureDestination { get; set; }

        [JsonPropertyName("skipEmptyArchives")]
        [Optional]
        public bool SkipEmptyArchives { get; set; }
    }

    internal class CaptureDestination
    {
        [JsonPropertyName("name")]
        [Required]
        public string Name { get; set; }
        
        [JsonPropertyName("properties")]
        [Required]
        public CaptureDestinationProperties Properties { get; set; }
    }

    internal class CaptureDestinationProperties
    {
        // TODO: make a custom type of ResourceIDReference, which rewrites them on demand?
        [JsonPropertyName("storageAccountResourceId")]
        [Required]
        [ForceNew]
        public string StorageAccountResourceID { get; set; }
        
        [JsonPropertyName("blobContainer")]
        [Required]
        public string BlobContainerName { get; set; }
        
        [JsonPropertyName("archiveNameFormat")]
        public string ArchiveNameFormat { get; set; }
    }

    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum Encoding
    {
        [Description("Avro")]
        Avro,
        
        [Description("AvroDeflate")]
        // TODO: [Deprecated]
        AvroDeflate
    }
}