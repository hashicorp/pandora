using System.Collections.Generic;
using System.Linq;
using Pandora.Data.Models;
using CommonTypesDefinition = Pandora.Data.Models.CommonTypesDefinition;

namespace Pandora.Data.Repositories;

public class CommonTypesRepository : ICommonTypesRepository
{
    private readonly Dictionary<ServiceDefinitionType, List<CommonTypesDefinition>> _commonTypes;

    public CommonTypesRepository(Dictionary<ServiceDefinitionType, IEnumerable<Definitions.Interfaces.CommonTypesDefinition>> commonTypes)
    {
        _commonTypes = new Dictionary<ServiceDefinitionType, List<CommonTypesDefinition>>();
        foreach (var commonType in commonTypes)
        {
            var mapped = commonType.Value.Select(s => Transformers.CommonTypes.Map(s, commonType.Key)).ToList();
            _commonTypes.Add(commonType.Key, mapped);
        }
    }

    public IEnumerable<CommonTypesDefinition> Get(ServiceDefinitionType serviceDefinitionType)
    {
        var commonTypes = _commonTypes.Where(c => c.Key == serviceDefinitionType);
        if (!commonTypes.Any())
        {
            return null;
        }

        return commonTypes.SelectMany(v => v.Value).ToList();
    }
}
