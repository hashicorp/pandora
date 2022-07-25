namespace Pandora.Definitions.ResourceManager.SecurityInsights;

public partial class Service
{
    // @tombuildsstuff: disabling temporarily due to this bug
    // https://github.com/hashicorp/pandora/issues/602#issuecomment-1163941476
    // where only the Interface but not any Implementations are being pulled out
    public bool Generate => false;
}
