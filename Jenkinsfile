pipeline {
    agent any
    triggers {
        githubPush()
    }
    stages {
        stage('Restore packages'){
           steps{
               sh 'dotnet restore AnabelTrivia.sln'
            }
         }
        stage('Clean'){
           steps{
               sh 'dotnet clean AnabelTrivia.sln --configuration Release'
            }
         }
        stage('Deploy'){
             steps{
               sh '''for pid in $(lsof -t -i:55028); do
                       kill -9 $pid
               done'''
               sh 'nohup dotnet AnabelTrivia/bin/Release/net6.0/publish/AnabelTrivia.dll --urls=http://localhost:55028 --ip=localhost --port=55028 /dev/null 2>&1 &'
             }
        }
    }
}
