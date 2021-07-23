using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ManagedIdentity.v2018_11_30.ManagedIdentity
{
	internal class Definition : ApiDefinition
	{
		// Generated from Swagger revision "e7682aa897902920f3a95b2f358b6f7729d18666" 

		public string ApiVersion => "2018-11-30";
		public string Name => "ManagedIdentity";
		public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
		{
			new SystemAssignedIdentitiesGetByScope(),
			new UserAssignedIdentitiesCreateOrUpdate(),
			new UserAssignedIdentitiesDelete(),
			new UserAssignedIdentitiesGet(),
			new UserAssignedIdentitiesListByResourceGroup(),
			new UserAssignedIdentitiesUpdate(),
		};
	}
}
