#!/usr/bin/env bash
# Copyright IBM Corp. 2023, 2026
# SPDX-License-Identifier: MPL-2.0

set -e

VERSION=$1
if [ -z "$VERSION" ]; then
    echo "Usage: $0 <version>"
    exit 1
fi

STATE_FILE=".go-version-update-state.txt"

# Phase 1: Update .go-version and go.mod files
echo "==> Phase 1: Updating .go-version and go.mod files to $VERSION"

find . -name ".go-version" -not -path "*/vendor/*" | while read -r f; do
    echo "$VERSION" > "$f"
    echo "Updated $f"
done

find . -name "go.mod" -not -path "*/vendor/*" | while read -r f; do
    dir=$(dirname "$f")
    (cd "$dir" && go mod edit -go="$VERSION")
    echo "Updated go directive in $f"
done

# Phase 2: Resumable go mod tidy
echo "==> Phase 2: Running go mod tidy"

if [ ! -f "$STATE_FILE" ]; then
    echo "Generating state file for go mod tidy..."
    find . -name "go.mod" -not -path "*/vendor/*" | while read -r f; do
        dirname "$f" >> "$STATE_FILE"
    done
fi

# Read all lines into array to avoid issues with modifying file while reading
DIRS=()
while IFS= read -r line; do
    DIRS+=("$line")
done < "$STATE_FILE"

for i in "${!DIRS[@]}"; do
    line="${DIRS[$i]}"
    
    if [[ "$line" == DONE* ]]; then
        continue
    fi
    
    dir="$line"
    echo "Tidying $dir..."
    
    if (cd "$dir" && go mod tidy); then
        # Mark as done
        DIRS[$i]="DONE $dir"
        printf "%s\n" "${DIRS[@]}" > "$STATE_FILE"
    else
        echo "Error: 'go mod tidy' failed in $dir."
        echo "Please fix the issue and run 'make update-go-version VERSION=$VERSION' again to resume."
        exit 1
    fi
done

echo "==> All modules successfully updated and tidied!"
rm "$STATE_FILE"
