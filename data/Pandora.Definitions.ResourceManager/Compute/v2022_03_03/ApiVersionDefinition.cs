// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_03;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-03-03";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new CommunityGalleries.Definition(),
        new CommunityGalleryImageVersions.Definition(),
        new CommunityGalleryImages.Definition(),
        new Galleries.Definition(),
        new GalleryApplicationVersions.Definition(),
        new GalleryApplications.Definition(),
        new GalleryImageVersions.Definition(),
        new GalleryImages.Definition(),
        new GallerySharingUpdate.Definition(),
        new SharedGalleries.Definition(),
        new SharedGalleryImageVersions.Definition(),
        new SharedGalleryImages.Definition(),
    };
}
