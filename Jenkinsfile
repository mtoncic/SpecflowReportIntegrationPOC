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
                sh 'dotnet test --logger "trx;LogFileName=TestResults.xml" --results-directory "./TestResults/"'
            }
        }
    }
    post {
        always {
            archiveArtifacts artifacts: 'TestResults/*.xml', fingerprint: true
            //mstest testResultsFile:"**/*.trx", keepLongStdio: true
            step([$class: 'XrayImportBuilder', endpointName: '/cucumber', importFilePath: 'TestResults/TestResults.xml', serverInstance: 'b3beffcf-1712-4a87-99f7-b7f9d4a0c25c'])
        }
    }
}
