using System.Collections.Generic;
using Pandora.Data.Models;

namespace Pandora.Data.Repositories
{
    public interface IServiceReferencesRepository
    {
        ServiceDefinition GetByName(string name, bool resourceManager);
        
        IEnumerable<ServiceDefinition> GetAll(bool resourceManager);
    }
}