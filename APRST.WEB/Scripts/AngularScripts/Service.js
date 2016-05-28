app.service("testService", function ($http) {

    this.getTests = function () {
        return $http.get("/Test/GetAllTests");
    };
    
    this.getQuestions = function (id) {
        return $http.get("/Test/GetQuestions/" + id);
    };

    this.getAnswers = function (id) {
        return $http.get("/Question/GetAnswers/" + id);
    };

    this.getQnA = function (id) {
        return $http.get("/Test/GetQnA/" + id);
    };

    this.finishTest = function (data, testId) {
        var response = $http({
            method: "post",
            url: "/Test/AddPoints/" + testId,
            data: JSON.stringify(data),
            dataType: "json"
        });
        return response;
    }
});

app.service("categoryService", function ($http) {

    this.getCategories = function () {
        return $http.get("/TestCategory/GetCategories");
    };

    this.AddCategory = function (category) {
        var response = $http({
            method: "post",
            url: "/TestCategory/Create",
            data: JSON.stringify(category),
            dataType: "json"
        });
        return response;
    }

    this.EditCategory = function (category) {
        var response = $http({
            method: "post",
            url: "/TestCategory/Edit",
            data: JSON.stringify(category),
            dataType: "json"
        });
        return response;
    }

    this.DeleteCategory = function (id) {
        var response = $http({
            method: "post",
            url: "/TestCategory/Delete",
            params: {
                Id: JSON.stringify(id)
            }
        });
        return response;
    }

});

app.service("userService", function ($http) {

    this.getUsers = function () {
        return $http.get("/User/GetAll");
    };

    this.getUserTestsResults = function (upn) {
        return $http.get("/Test/GetUserTestsResults/" + upn);
    };

});

app.service("questionnaireService", function ($http) {

    this.getQuestionnaire = function () {
        return $http.get("/Questionnaire/GetQuestionnaire");
    };

    this.getQuestionnaireResult = function () {
        return $http.get("/Questionnaire/GetQuestionnaireResult");
    };

    this.addQuestionnaire = function (qResult) {
        var response = $http({
            method: "post",
            url: "/Questionnaire/Add",
            data: JSON.stringify(qResult),
            dataType: "json"
        });
        return response;
    }

});