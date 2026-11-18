#!/bin/bash
# Copyright IBM Corp. 2023, 2026
# SPDX-License-Identifier: MPL-2.0

set -euo pipefail

if [[ $(git status --porcelain | wc -l) -gt 0 ]]; then
  git add --all
  git commit -m "$1"
  echo "has_changes_to_push=true" >> "$GITHUB_OUTPUT"
else
  echo "has_changes_to_push=false" >> "$GITHUB_OUTPUT"
fi
