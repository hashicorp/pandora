using System.Collections.Generic;
using System.Linq;
using Pandora.Definitions.Interfaces;
using ServiceDefinition = Pandora.Data.Models.ServiceDefinition;

namespace Pandora.Data.Repositories;

public class ServiceReferencesRepository : IServiceReferencesRepository
{
    private readonly List<ServiceDefinition> _services;

    public ServiceReferencesRepository(IEnumerable<Definitions.Interfaces.ServiceDefinition> services)
    {
        _services = services.Select(Transformers.Service.Map).ToList();
    }

    public ServiceDefinition GetByName(string name, bool resourceManager)
    {
        return _services.FirstOrDefault(s => s.Name == name && s.ResourceManager == resourceManager);
    }

    public IEnumerable<ServiceDefinition> GetAll(bool resourceManager)
    {
        return _services.Where(s => s.ResourceManager == resourceManager).ToList();
    }
}