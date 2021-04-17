pipeline {
  agent any
  stages {
    stage('test') {
      steps {
        dotnetBuild()
      }
    }

  }
  environment {
    test = 'test'
  }
}