using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DataShare.v2021_08_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-08-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Account.Definition(),
        new ConsumerInvitation.Definition(),
        new DataSet.Definition(),
        new DataSetMapping.Definition(),
        new EmailRegistration.Definition(),
        new Invitation.Definition(),
        new Share.Definition(),
        new ShareSubscription.Definition(),
        new SynchronizationSetting.Definition(),
        new Trigger.Definition(),
    };
}
