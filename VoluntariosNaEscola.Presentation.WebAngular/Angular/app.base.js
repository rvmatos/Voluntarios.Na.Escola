var appDataBase = angular.module('appDataBase', ['ngRoute', 'ngCookies', 'ngDialog', 'ngMessages', 'angularFileUpload']);

appDataBase.constant('Constants',

    {
        HostHttp: 'http://localhost/appdatabase/service/api/',
        DevelopmentType: [
           { id: 0, name: "" },
            { id: 1, name: "Serviço", },
            { id: 2, name: "Pacote", },
            { id: 3, name: "Customizado" }]
        , Criticality: [
            { id: 0, name: "" },
            { id: 1, name: "Muito alta", },
            { id: 2, name: "Alta", },
            { id: 3, name: "Média" },
            { id: 4, name: "Baixa" }]
        , Idiom: [
           { id: 0, name: "" },
            { id: 1, name: "Português" },
            { id: 2, name: "Inglês" },
            { id: 3, name: "Espanhol" },
            { id: 4, name: "Multi idiomas" }]
        , Level: [
           { id: 0, name: "" },
            { id: 1, name: "Global" },
            { id: 2, name: "Regional" },
            { id: 3, name: "Local" }]
        , Situation: [
           { id: 0, name: "" },
            { id: 1, name: "Tolerarl" },
            { id: 2, name: "Investigar" },
            { id: 3, name: "Migrar" },
            { id: 4, name: "Eliminar" }]

    });
