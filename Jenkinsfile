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

  }
}