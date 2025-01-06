#!/bin/bash
name=$1

kubectl get pods -A | grep "$name" | awk '{print $2}' | kubectl logs -