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
                sh 'dotnet test --logger "junit;LogFileName=TestResults.xml" --results-directory "./TestResults/"'
            }
        }
    }
    post {
        always {
            archiveArtifacts artifacts: 'TestResults/*.xml', fingerprint: true
            //mstest testResultsFile:"**/*.trx", keepLongStdio: true
            step([$class: 'XrayImportFeatureBuilder', credentialId: '', folderPath: '**/*.feature', lastModified: '', preconditions: '', projectKey: 'XRAYD', serverInstance: 'SERVER-b3beffcf-1712-4a87-99f7-b7f9d4a0c25c', testInfo: ''])
            step([$class: 'XrayImportBuilder', endpointName: '/junit', importFilePath: 'TestResults/TestResults.xml', projectKey: 'XRAYD', serverInstance: 'b3beffcf-1712-4a87-99f7-b7f9d4a0c25c'])
        }
    }
}
