using System.Collections.Generic;
using System.Linq;
using Pandora.Data.Models;
using ServiceDefinition = Pandora.Data.Models.ServiceDefinition;

namespace Pandora.Data.Repositories;

public class ServiceReferencesRepository : IServiceReferencesRepository
{
    private readonly Dictionary<ServiceDefinitionType, List<ServiceDefinition>> _services;

    public ServiceReferencesRepository(Dictionary<ServiceDefinitionType, IEnumerable<Definitions.Interfaces.ServiceDefinition>> services)
    {
        _services = new Dictionary<ServiceDefinitionType, List<ServiceDefinition>>();
        foreach (var service in services)
        {
            var mapped = service.Value.Select(s => Transformers.Service.Map(s, service.Key)).ToList();
            _services.Add(service.Key, mapped);
        }
    }

    public ServiceDefinition GetByName(string name, ServiceDefinitionType definitionType)
    {
        var services = _services.Where(s => s.Key == definitionType);
        if (!services.Any())
        {
            return null;
        }

        return services.SelectMany(v => v.Value).ToList().FirstOrDefault(s => s.Name == name);
    }

    public IEnumerable<ServiceDefinition> GetAll(ServiceDefinitionType definitionType)
    {
        var services = _services.Where(s => s.Key == definitionType);
        if (!services.Any())
        {
            return new List<ServiceDefinition>();
        }

        return services.SelectMany(v => v.Value).ToList();
    }
}