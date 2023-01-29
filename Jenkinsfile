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
        sh 'docker build -f StockPortfolioAppRestApi/Dockerfile . -t bodzioss/stockportfolioapp:latest'
      }
    }

    stage('Log into Dockerhub') {
      environment {
        DOCKERHUB_USER = 'bodzioss'
        DOCKERHUB_PASSWORD = 'Marcin2612'
      }
      steps {
        sh 'docker login -u $DOCKERHUB_USER -p $DOCKERHUB_PASSWORD'
      }
    }

    stage('Docker Push') {
      steps {
        sh 'docker push bodzioss/stockportfolioapp:latest'
      }
    }

  }
}