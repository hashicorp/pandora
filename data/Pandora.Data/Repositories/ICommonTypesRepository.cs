using System.Collections.Generic;
using Pandora.Data.Models;

namespace Pandora.Data.Repositories;

public interface ICommonTypesRepository
{
    IEnumerable<CommonTypesDefinition> Get(ServiceDefinitionType serviceDefinitionType);
}
