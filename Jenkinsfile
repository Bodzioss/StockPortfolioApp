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

    stage('Log into Dockerhub') {
      environment {
        DOCKERHUB_USER = 'marcin_bogdanski1@wp.pl'
        DOCKERHUB_PASSWORD = 'Marcin2612'
      }
      steps {
        sh 'docker login -u $DOCKERHUB_USER -p $DOCKERHUB_PASSWORD'
      }
    }

  }
}