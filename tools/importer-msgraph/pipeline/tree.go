package pipeline

import (
	"fmt"
	"os"
	"path/filepath"
	"sort"
	"strings"

	"github.com/hashicorp/go-hclog"
)

type Tree struct {
	tree  map[string]*Tree
	files map[string]string
}

func newTree() *Tree {
	return &Tree{
		tree:  make(map[string]*Tree),
		files: make(map[string]string),
	}
}

func (t *Tree) addFile(path, content string) error {
	cur := t
	dir, filename := filepath.Split(path)
	for _, bit := range strings.Split(strings.Trim(dir, string(os.PathSeparator)), string(os.PathSeparator)) {
		if _, ok := cur.tree[bit]; !ok {
			cur.tree[bit] = newTree()
		}
		cur = cur.tree[bit]
	}
	cur.files[filename] = content
	return nil
}

func (t *Tree) write(curDir string, logger hclog.Logger) error {
	os.MkdirAll(curDir, os.ModePerm)
	for filename, content := range t.files {
		dest := curDir + string(os.PathSeparator) + filename
		logger.Info(fmt.Sprintf("Writing file: %s", dest))
		if err := writeFile(dest, content); err != nil {
			return err
		}
	}
	dirNames := make([]string, 0, len(t.tree))
	for dirName := range t.tree {
		dirNames = append(dirNames, dirName)
	}
	sort.Strings(dirNames)
	for _, nextDirName := range dirNames {
		dir := t.tree[nextDirName]
		if err := dir.write(curDir+string(os.PathSeparator)+nextDirName, logger); err != nil {
			return err
		}
	}
	return nil
}

func (t *Tree) descend(dirPath string) (*Tree, error) {
	cur := t
	for _, bit := range strings.Split(dirPath, string(os.PathSeparator)) {
		if _, ok := cur.tree[bit]; !ok {
			return nil, fmt.Errorf("path not found: %s", dirPath)
		}
		cur = cur.tree[bit]
	}
	return cur, nil
}
