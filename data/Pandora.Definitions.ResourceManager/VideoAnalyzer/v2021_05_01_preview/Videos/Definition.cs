using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.Videos;

internal class Definition : ResourceDefinition
{
    public string Name => "Videos";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AccessPoliciesCreateOrUpdateOperation(),
        new AccessPoliciesDeleteOperation(),
        new AccessPoliciesGetOperation(),
        new AccessPoliciesListOperation(),
        new AccessPoliciesUpdateOperation(),
        new VideosCreateOrUpdateOperation(),
        new VideosDeleteOperation(),
        new VideosGetOperation(),
        new VideosListOperation(),
        new VideosListStreamingTokenOperation(),
        new VideosUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessPolicyEccAlgoConstant),
        typeof(AccessPolicyRoleConstant),
        typeof(AccessPolicyRsaAlgoConstant),
        typeof(VideoTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AccessPolicyEntityModel),
        typeof(AccessPolicyPropertiesModel),
        typeof(AuthenticationBaseModel),
        typeof(EccTokenKeyModel),
        typeof(JwtAuthenticationModel),
        typeof(RsaTokenKeyModel),
        typeof(TokenClaimModel),
        typeof(TokenKeyModel),
        typeof(VideoEntityModel),
        typeof(VideoFlagsModel),
        typeof(VideoMediaInfoModel),
        typeof(VideoPropertiesModel),
        typeof(VideoStreamingModel),
        typeof(VideoStreamingTokenModel),
    };
}
