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
            archiveArtifacts artifacts: 'TestResults/*.trx', fingerprint: true
            mstest testResultsFile:"**/*.trx", keepLongStdio: true
            step([$class: 'XrayImportBuilder', endpointName: '/cucumber', importFilePath: 'cucumber_xray_tests/data.json', serverInstance: '552d0cb6-6f8d-48ba-bbad-50e94f39b722'])
        }
    }
}
