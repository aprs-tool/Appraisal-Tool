var app = angular.module("ApraisalToolApp", ["ngAnimate", "ui.bootstrap", "ngSanitize", "ngResource", "ngRoute"])
    .config(function ($routeProvider) {
        
        $routeProvider.when("/Admin",
        {
            templateUrl: "/content/views/Admin/Index.html"
        });

        $routeProvider.when("/User", {
            templateUrl: "/content/views/User/Index.html"
        });

        $routeProvider.when("/AllUsers", {
            templateUrl: "/content/views/User/AllUsers.html"
        });

        $routeProvider.when("/Questionnaires", {
            templateUrl: "/content/views/Questionnaires/Index.html"
        });

        $routeProvider.when("/Tests", {
            templateUrl: "/content/views/Tests/Index.html"
        });

        $routeProvider.when("/Testing", {
            templateUrl: "/content/views/Tests/Testing.html"
        });

        $routeProvider.otherwise({
            templateUrl: "/content/views/User/Index.html"
        });

    });