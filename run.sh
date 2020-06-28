#!/bin/bash
docker-compose down
docker build -t calculate-interest-image ./dotnetcore.calculate-interest
docker build -t interest-rate-image ./dotnetcore.interest-rate
docker-compose up -d