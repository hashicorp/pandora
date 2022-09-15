using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-07-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AvailabilitySets.Definition(),
        new CapacityReservation.Definition(),
        new CapacityReservationGroups.Definition(),
        new CapacityReservations.Definition(),
        new CommunityGalleries.Definition(),
        new CommunityGalleryImageVersions.Definition(),
        new CommunityGalleryImages.Definition(),
        new Compute.Definition(),
        new DedicatedHost.Definition(),
        new DedicatedHostGroups.Definition(),
        new DedicatedHosts.Definition(),
        new Galleries.Definition(),
        new GalleryApplicationVersions.Definition(),
        new GalleryApplications.Definition(),
        new GalleryImageVersions.Definition(),
        new GalleryImages.Definition(),
        new GallerySharingUpdate.Definition(),
        new Images.Definition(),
        new LogAnalytics.Definition(),
        new ProximityPlacementGroups.Definition(),
        new RestorePointCollections.Definition(),
        new SharedGalleries.Definition(),
        new SharedGalleryImageVersions.Definition(),
        new SharedGalleryImages.Definition(),
        new Skus.Definition(),
        new SshPublicKeys.Definition(),
        new VirtualMachineExtensionImages.Definition(),
        new VirtualMachineExtensions.Definition(),
        new VirtualMachineImages.Definition(),
        new VirtualMachineRunCommands.Definition(),
        new VirtualMachineScaleSetExtensions.Definition(),
        new VirtualMachineScaleSetRollingUpgrades.Definition(),
        new VirtualMachineScaleSetVMExtensions.Definition(),
        new VirtualMachineScaleSetVMRunCommands.Definition(),
        new VirtualMachineScaleSetVMs.Definition(),
        new VirtualMachineScaleSets.Definition(),
        new VirtualMachineSizes.Definition(),
        new VirtualMachines.Definition(),
    };
}
