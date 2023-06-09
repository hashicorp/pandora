using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2022_08_29;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-08-29";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new CertificateObjectGlobalRulestack.Definition(),
        new CertificateObjectLocalRulestack.Definition(),
        new FirewallStatus.Definition(),
        new Firewalls.Definition(),
        new FqdnListGlobalRulestack.Definition(),
        new FqdnListLocalRulestack.Definition(),
        new GlobalRulestack.Definition(),
        new LocalRules.Definition(),
        new LocalRulestacks.Definition(),
        new PostRules.Definition(),
        new PreRules.Definition(),
        new PrefixListGlobalRulestack.Definition(),
        new PrefixListLocalRulestack.Definition(),
    };
}
