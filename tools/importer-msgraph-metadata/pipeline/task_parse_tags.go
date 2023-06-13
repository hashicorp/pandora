package pipeline

import (
	"fmt"
	"strings"
)

func (p pipelineTask) parseTags() (services Services, err error) {
	services = make(map[string][]string, 0)
	for _, tag := range p.spec.Tags {
		if tag == nil {
			continue
		}
		if tag.Name != "" {
			t := strings.Split(tag.Name, ".")
			if len(t) != 2 {
				return nil, fmt.Errorf("encountered malformed tag: %q", tag.Name)
			}
			if _, ok := services[t[0]]; !ok {
				services[t[0]] = make([]string, 0)
			}
			services[t[0]] = append(services[t[0]], t[1])
		}
	}
	return
}
