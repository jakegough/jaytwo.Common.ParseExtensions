FROM microsoft/dotnet:2.0-sdk-stretch AS base
RUN apt-get update \
  && apt-get install -y --no-install-recommends \
    make \
    mono-devel \
  && rm -rf /var/lib/apt/lists/*
ENV FrameworkPathOverride /usr/lib/mono/4.5/

FROM base AS builder
WORKDIR /src
COPY . /src
RUN make build