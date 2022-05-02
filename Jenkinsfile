pipeline {
  agent any
  stages {
    stage('Show Projects') {
      steps {
        git(url: 'https://github.com/maurosanchezJC/UnityCodingDojo', branch: 'master', changelog: true, poll: true)
      }
    }

    stage('') {
      steps {
        echo 'hola'
      }
    }

  }
}