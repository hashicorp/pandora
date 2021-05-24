using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubsClustersConfiguration
{
	internal class ConfigurationGet : GetOperation
	{
		public override ResourceID? ResourceId()
		{
			return new ClusterId();
		}

		public override object? ResponseObject()
		{
			return new ClusterQuotaConfigurationProperties();
		}

		public override string? UriSuffix()
		{
			return "/quotaConfiguration/default";
		}
	}
}
