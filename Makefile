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

publish:
	cd ./out & \
    dotnet pack -o ../../out ${PACK_ARG}

pack-beta: PACK_ARG=--version-suffix beta-$(shell date +'%Y%m%d%H%M%S')
pack-beta: pack

DOCKER_TAG_PREFIX?=jaytwocommonparseextensions
DOCKER_TAG?=${DOCKER_TAG_PREFIX}${DOCKER_TAG_SUFFIX}
docker-build: clean
	docker build -t ${DOCKER_TAG} . --target builder

docker-test: docker-build
	docker run --rm ${DOCKER_TAG} make test

DOCKER_PACK_MAKE_TARGETS?=pack
docker-pack: docker-build
	docker run --rm -v $(shell pwd)/out:/src/out ${DOCKER_TAG} make ${DOCKER_PACK_MAKE_TARGETS}

docker-pack-beta: DOCKER_PACK_MAKE_TARGETS=pack-beta
docker-pack-beta: docker-pack

docker-publish: docker-build
	docker run --rm ${DOCKER_TAG} make publish
  
docker-cleanup:
	docker rmi ${DOCKER_TAG} || echo "docker tag ${DOCKER_TAG} not found"
