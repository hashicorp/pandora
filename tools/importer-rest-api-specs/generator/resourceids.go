package generator

import "fmt"

func (g PandoraDefinitionGenerator) codeForResourceID(namespace string, resourceIdName string, resourceIdValue string) string {
	return fmt.Sprintf(`using Pandora.Definitions.Interfaces;

namespace %[1]s
{
	internal class %[2]s : ResourceID
	{
		public string ID() => "%[3]s";
	}
}
`, namespace, resourceIdName, resourceIdValue)
}
