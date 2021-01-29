pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
               sh 'dotnet build'
            }
        }
        stage('Test') {
            steps {
                sh 'dotnet test --logger "trx;LogFileName=TestResults.trx" --results-directory "./TestResults/"'
            }
        }
    }
    post {
        always {
            archiveArtifacts artifacts: './TestResults/*.trx', fingerprint: true
            junit 'build/reports/**/*.xml'
        }
    }
}
