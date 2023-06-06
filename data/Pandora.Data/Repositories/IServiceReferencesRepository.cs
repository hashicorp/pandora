using System.Collections.Generic;
using Pandora.Data.Models;

namespace Pandora.Data.Repositories;

public interface IServiceReferencesRepository
{
    ServiceDefinition GetByName(string name, ServiceDefinitionType definitionType);

    IEnumerable<ServiceDefinition> GetAll(ServiceDefinitionType definitionType);
}