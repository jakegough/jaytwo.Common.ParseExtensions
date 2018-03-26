def github_username = 'jakegough'
def github_repository = 'jaytwo.Common.ParseExtensions'
def jenkins_credential_id_github = 'github-personal-access-token-jakegough'
def dockerhub_username = 'jakegough'
def jenkins_credential_id_dockerhub = 'userpass-dockerhub-jakegough'

node('linux && make && docker') {
    try {
        stage('Clone') {
            checkout scm
        }
        stage('Set In Progress') {
            updateBuildStatusInProgress(github_username, github_repository, jenkins_credential_id_github);
        }
        stage ('Build') {
            sh "make docker-build DOCKER_TAG_SUFFIX=-${BUILD_TIMESTAMP}"
        }
        stage ('Test') {
            sh "make docker-test DOCKER_TAG_SUFFIX=-${BUILD_TIMESTAMP}"
        }
        
        if (BRANCH_NAME == "develop") {
          stage ('Pack-Beta') {
            sh "make docker-pack-beta DOCKER_TAG_SUFFIX=-${BUILD_TIMESTAMP}"
          }
        }
        else {
          stage ('Pack') {
            sh "make docker-pack DOCKER_TAG_SUFFIX=-${BUILD_TIMESTAMP}"
          }
        }
        stage ('Docker Cleanup') {
            sh "make docker-cleanup DOCKER_TAG_SUFFIX=-${BUILD_TIMESTAMP}"
        }
        stage('Set Success') {
            updateBuildStatusSuccessful(github_username, github_repository, jenkins_credential_id_github);
        }
    }
    catch(Exception e) {
        updateBuildStatusFailed(github_username, github_repository, jenkins_credential_id_github);
        throw e
    }
    finally {
        stage("Cleanup") {            
            // clean workspace
            cleanWs()
        }        
    }
}

def updateBuildStatusInProgress(username, repository, jenkins_credential_id) {
    updateBuildStatus(username, repository, jenkins_credential_id, "pending", "Build in progress... cross your fingers...");
}

def updateBuildStatusSuccessful(username, repository, jenkins_credential_id) {
    updateBuildStatus(username, repository, jenkins_credential_id, "success", "Build passed :)");
}

def updateBuildStatusFailed(username, repository, jenkins_credential_id) {
    updateBuildStatus(username, repository, jenkins_credential_id, "failure", "Build failed :(");
}

def updateBuildStatus(username, repository, jenkins_credential_id, state, description) {
    git_commit = sh(returnStdout: true, script: "git rev-parse HEAD").toString().trim()
    
    // a lot of help from: https://stackoverflow.com/questions/14274293/show-current-state-of-jenkins-build-on-github-repo
    postToUrl = "https://api.github.com/repos/${username}/${repository}/statuses/${git_commit}"

    bodyJson = \
"""{ 
    "state": "${state}",
    "target_url": "${BUILD_URL}", 
    "description": "${description}" 
}"""

	withCredentials([string(credentialsId: jenkins_credential_id, variable: 'TOKEN')]) {
		def response = httpRequest \
			customHeaders: [[name: 'Authorization', value: "token $TOKEN"]], \
			contentType: 'APPLICATION_JSON', \
			httpMode: 'POST', \
			requestBody: bodyJson, \
			url: postToUrl

		// echo "Status: ${response.status}\nContent: ${response.content}"
	}
}