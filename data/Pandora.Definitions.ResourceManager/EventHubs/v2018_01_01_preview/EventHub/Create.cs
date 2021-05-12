using Pandora.Definitions.Operations;

namespace Pandora.Definitions.ResourceManager.EventHubs.v2018_01_01_preview.EventHub
{
    internal class Create : PutOperation
    {
        public override object? RequestObject()
        {
            return new CreateEventHubInput();
        }
    }
}