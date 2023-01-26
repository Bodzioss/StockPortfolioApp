pipeline {
  agent any
  stages {
    stage('Checkout code') {
      steps {
        git(branch: 'App-Deployment', url: 'https://github.com/Bodzioss/StockPortfolioApp/')
      }
    }

    stage('Build') {
      steps {
        sh 'docker build -f StockPortfolioAppRestApi/Dockerfile .'
      }
    }

    stage('Initialize') {
      steps {
        sh '''def dockerHome = tool \'MyDocker\'
def mavenHome  = tool \'MyMaven\'
env.PATH = "${dockerHome}/bin:${mavenHome}/bin:${env.PATH}"'''
      }
    }

  }
}