pipeline {
  agent any
  stages {
    stage('Show Projects') {
      steps {
        git(url: 'https://github.com/maurosanchezJC/UnityCodingDojo', branch: 'master', changelog: true, poll: true)
      }
    }

    stage('Hello World') {
      parallel {
        stage('Hello World') {
          steps {
            echo 'Hello World!'
          }
        }

        stage('') {
          steps {
            readFile './CodingDojo3/Exercise/PlayerPrinter.cs'
          }
        }

      }
    }

    stage('Final') {
      steps {
        echo 'Job finished successfully'
      }
    }

  }
}