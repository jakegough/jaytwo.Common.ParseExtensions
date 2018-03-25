default: build

clean: 
	find . -name bin | xargs rm -vrf
	find . -name obj | xargs rm -vrf
	find . -name publish | xargs rm -vrf
	find . -name project.lock.json | xargs rm -vrf
	find . -name testResults | xargs rm -vrf
	find . -name out | xargs rm -vrf

restore:
	dotnet restore . --verbosity minimal
  
build: restore
	dotnet build ./src/jaytwo.Common.ParseExtensions

test: build
	dotnet test ./test/jaytwo.Common.ParseExtensions.UnitTests
  
pack: build
	cd ./src/jaytwo.Common.ParseExtensions & \
    dotnet pack -o ../../out ${PACK_ARG}

pack-beta: PACK_ARG=--version-suffix beta-$(shell date +'%Y%m%d%H%M%S')
pack-beta: pack

docker-build: clean
	docker build -t foobar . --target builder

docker-test: docker-build
	docker run --rm foobar make test

DOCKER_PACK_MAKE_TARGETS?=pack
docker-pack: docker-build
	docker run --rm -v $(shell pwd)/out:/src/out foobar make ${DOCKER_PACK_MAKE_TARGETS}

docker-pack-beta: DOCKER_PACK_MAKE_TARGETS=pack-beta
docker-pack-beta: docker-pack

docker-cleanup:
	docker rmi foobar
