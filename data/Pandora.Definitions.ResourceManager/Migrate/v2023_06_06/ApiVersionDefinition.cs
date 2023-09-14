using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-06-06";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new DependencyMapController.Definition(),
        new HyperVSites.Definition(),
        new HypervClusterController.Definition(),
        new HypervDependencyMapController.Definition(),
        new HypervHostController.Definition(),
        new HypervJobs.Definition(),
        new HypervJobsController.Definition(),
        new HypervMachinesController.Definition(),
        new HypervRunAsAccountsController.Definition(),
        new HypervSitesController.Definition(),
        new HypervSoftwareInventoriesController.Definition(),
        new IisWebApplicationsController.Definition(),
        new IisWebServersController.Definition(),
        new ImportJobsController.Definition(),
        new ImportMachinesController.Definition(),
        new ImportSitesController.Definition(),
        new MachinesController.Definition(),
        new MasterSitesController.Definition(),
        new PrivateEndpointConnectionController.Definition(),
        new PrivateLinkResourcesController.Definition(),
        new RunAsAccountsController.Definition(),
        new ServerDependencyMapController.Definition(),
        new ServerJobsController.Definition(),
        new ServerRunAsAccountsController.Definition(),
        new ServerSitesController.Definition(),
        new ServerSoftwareInventoriesController.Definition(),
        new ServersController.Definition(),
        new SitesController.Definition(),
        new SqlAvailabilityGroupsController.Definition(),
        new SqlDatabasesController.Definition(),
        new SqlDiscoverySiteDataSourceController.Definition(),
        new SqlJobsController.Definition(),
        new SqlRunAsAccountsController.Definition(),
        new SqlServersController.Definition(),
        new SqlSitesController.Definition(),
        new TomcatWebApplicationsController.Definition(),
        new TomcatWebServersController.Definition(),
        new VMwareHostController.Definition(),
        new VMwarePropertiesController.Definition(),
        new VMwareSoftwareInventoriesController.Definition(),
        new VcenterController.Definition(),
        new WebAppDiscoverySiteDataSourcesController.Definition(),
        new WebAppExtendedMachinesController.Definition(),
        new WebAppPropertiesController.Definition(),
        new WebAppRunAsAccountsController.Definition(),
        new WebAppSitesController.Definition(),
        new WebApplicationsController.Definition(),
        new WebServersController.Definition(),
    };
}
