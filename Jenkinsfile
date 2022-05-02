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

        stage('error') {
          steps {
            sh '''yourfilenames=`ls`
for eachfile in $yourfilenames
do
   echo $eachfile
done'''
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