app
    .constant("testApiUrl", "/api/Tests/")
    .service("testService", function ($http, $resource, testApiUrl) {

        this.getTests = function () {
            return $resource(testApiUrl + ":Id", { id: "@Id" });
        };

        this.finishTest = function (data, testId) {
            var response = $http({
                method: "post",
                url: "/Test/AddPoints/" + testId,
                data: JSON.stringify(data),
                dataType: "json"
            });
            return response;
        };
    });

app
    .constant("testsQuestionsApiUrl", "/api/TestsQuestions/")
    .service("testsQuestionsService", function ($http, $resource, testsQuestionsApiUrl) {

        this.getQuestions = function () {
            return $resource(testsQuestionsApiUrl + ":Id", { id: "@Id" });
        };
    });

app
    .constant("testsAnswersApiUrl", "/api/TestsAnswers/")
    .service("testsAnswersService", function ($http, $resource, testsAnswersApiUrl) {

        this.getAnswers = function () {
            return $resource(testsAnswersApiUrl + ":Id", { id: "@Id" });
        };
    });

app
    .constant("testsCategoriesApiUrl", "/api/TestsCategories/")
    .service("testsCategoriesService", function ($http, $resource, testsCategoriesApiUrl) {

        this.getCategories = function () {
            return $resource(testsCategoriesApiUrl + ":Id", { id: "@Id" });
        };
    });

app
    .constant("testingApiUrl", "/api/Testing/")
    .service("testingService", function ($http, $resource, testingApiUrl) {
        this.get = function () {
            return $resource(testingApiUrl + ":Id", { id: "@Id" });
        };

        this.finishTest = function (data, id) {
            var response = $http({
                method: "post",
                url: "/api/Testing/Post/" + id,
                data: JSON.stringify(data),
                dataType: "json"
            });
            return response;
        }
    });

app
    .constant("questionnairesApiUrl", "/api/Questionnaires/")
    .service("questionnairesService", function ($http, $resource, questionnairesApiUrl) {

        this.get = function () {
            return $resource(questionnairesApiUrl + ":Id", { id: "@Id" });
        };
    });

app
    .constant("questionnaireApiUrl", "/api/Questionnaire/")
    .service("questionnaireService", function ($http, $resource, questionnaireApiUrl) {

        this.get = function () {
            return $resource(questionnaireApiUrl + ":Id", { id: "@Id" });
        };
    });

app
    .constant("usersApiUrl", "/api/Users/")
    .service("usersService", function ($http, $resource, usersApiUrl) {

        this.get = function () {
            return $resource(usersApiUrl + ":Id", { id: "@Id" });
        };
    });

app
    .constant("userApiUrl", "/api/User/")
    .service("userService", function ($http, $resource, userApiUrl) {

        this.get = function () {
            return $resource(userApiUrl + ":Id", { id: "@Id" });
        };

        this.changeAvatar = function (file) {
            var formData = new FormData();
            formData.append("file", file);
            var response = $http.post(userApiUrl + "/UpdateProfileImage",
                formData,
                {
                    headers: { 'Content-Type': undefined },
                    transformRequest: angular.identity
                });
            return response;
        };
    });

app.service("adminService", function ($http, $resource) {
    this.getLog = function () {
        return $resource("/api/Admin/GetLog" + ":Id", { id: "@Id" });
    };

    this.getCounters = function () {
        return $resource("/api/Admin/GetCounters" + ":Id", { id: "@Id" });
    };

    this.getRoles = function () {
        return $resource("/api/Admin/GetRoles" + ":Id", { id: "@Id" });
    };
});

///Factories///

app.factory("scopes", function () {
    var mem = {};

    return {
        store: function (key, value) {
            mem[key] = value;
        },
        get: function (key) {
            return mem[key];
        }
    };
});

///For Put///

app.factory("testsPut", ["$resource", function ($resource) {
    return $resource("/api/Tests/", null,
    {
        'update': { method: "PUT" }
    });
}]);

app.factory("testsQuestionsPut", ["$resource", function ($resource) {
    return $resource("/api/TestsQuestions/", null,
    {
        'update': { method: "PUT" },
        'delete': { method: "DELETE" }
    });
}]);

app.factory("testsAnswersPut", ["$resource", function ($resource) {
    return $resource("/api/TestsAnswers/", null,
    {
        'update': { method: "PUT" },
        'delete': { method: "DELETE" }
    });
}]);

app.factory("testsCategoriesPut", ["$resource", function ($resource) {
    return $resource("/api/TestsCategories/", null,
    {
        'update': { method: "PUT" }
    });
}]);

app.factory("userProfilePut", ["$resource", function ($resource) {
    return $resource("/api/User/", null,
    {
        'update': { method: "PUT" }
    });
}]);

///For Put///

///Full Api///

app.factory("questionnairesCategoriesApi", ["$resource", function ($resource) {
    return $resource("/api/QuestionnairesCategories/", null,
    {
        'add': { method: "POST" },
        'update': { method: "PUT" },
        'delete': { method: "DELETE" }
    });
}]);

app.factory("questionnairesQuestionsApi", ["$resource", function ($resource) {
    return $resource("/api/QuestionnairesQuestions/", null,
    {
        'add': { method: "POST" },
        'update': { method: "PUT" },
        'delete': { method: "DELETE" }
    });
}]);

app.factory("questionnairesApi", ["$resource", function ($resource) {
    return $resource("/api/Questionnaires/", null,
    {
        'update': { method: "POST" }
    });
}]);

app.factory("adminApi", ["$resource", function ($resource) {
    return $resource("/api/Admin", null,
    {
        'giveTest': {
            method: "POST",
            url: "/api/Admin/GiveTest"
        }
    });
}]);

///Full Api///

///Factories///