pipeline {
  agent any
  stages {
    stage('Checkout code') {
      steps {
        git(branch: 'App-Deployment', url: 'https://github.com/Bodzioss/StockPortfolioApp/')
      }
    }

    stage('Build') {
      agent {
        docker {
          image 'node:lts-alpine'
          args '-p 3000:3000'
        }

      }
      steps {
        sh 'docker build -f StockPortfolioAppRestApi/Dockerfile .'
      }
    }

  }
}