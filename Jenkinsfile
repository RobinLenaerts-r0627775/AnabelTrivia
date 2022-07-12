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
         stage('Build'){
           steps{
               sh 'dotnet build AnabelTrivia.sln --configuration Release --no-restore'
            }
         }
        stage('Publish'){
             steps{
               sh 'dotnet publish AnabelTrivia/ArgonDotNet.csproj --configuration Release --no-restore'
             }
         }
        stage('Deploy'){
             steps{
               sh '''for pid in $(lsof -t -i:55028); do
                       kill -9 $pid
               done'''
               sh 'nohup dotnet AnabelTrivia/bin/Release/net6.0/publish/AnabelTrivia.dll --urls=http://0.0.0.0:55028 --ip=0.0.0.0 --port=55028'
             }
        }
    }
}
