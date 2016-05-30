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

    this.getUserProfile = function () {
        return $http.get("/User/GetProfile");
    };

    this.EditProfile = function (user) {
        var response = $http({
            method: "post",
            url: "/User/EditProfile",
            data: JSON.stringify(user),
            dataType: "json"
        });
        return response;
    }

});

app.service("questionnaireService", function ($http) {

    this.getQuestionnaire = function () {
        return $http.get("/Questionnaire/GetQuestionnaire");
    };

    this.getQuestionnaires = function () {
        return $http.get("/Questionnaire/GetAllIncludeUserAndType");
    };

    this.getQuestionnaireResult = function () {
        return $http.get("/Questionnaire/GetQuestionnaireResult");
    };

    this.getCategories = function () {
        return $http.get("/QuestionnaireCategory/GetCategories");
    };

    this.getQuestions = function (categoryId) {
        return $http.get("/QuestionnaireCategory/GetCategoryWithQuestions/" + categoryId);
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

    this.AddCategory = function (category) {
        var response = $http({
            method: "post",
            url: "/QuestionnaireCategory/Create",
            data: JSON.stringify(category),
            dataType: "json"
        });
        return response;
    }

    this.EditCategory = function (category) {
        var response = $http({
            method: "post",
            url: "/QuestionnaireCategory/Edit",
            data: JSON.stringify(category),
            dataType: "json"
        });
        return response;
    }

    this.DeleteCategory = function (id) {
        var response = $http({
            method: "post",
            url: "/QuestionnaireCategory/Delete",
            params: {
                Id: JSON.stringify(id)
            }
        });
        return response;
    }

    this.AddQuestion = function (question) {
        var response = $http({
            method: "post",
            url: "/QuestionnaireQuestion/Create",
            data: JSON.stringify(question),
            dataType: "json"
        });
        return response;
    }

    this.EditQuestion = function (question) {
        var response = $http({
            method: "post",
            url: "/QuestionnaireQuestion/Edit",
            data: JSON.stringify(question),
            dataType: "json"
        });
        return response;
    }

    this.DeleteQuestion = function (id) {
        var response = $http({
            method: "post",
            url: "/QuestionnaireQuestion/Delete",
            params: {
                Id: JSON.stringify(id)
            }
        });
        return response;
    }

});

app.service("adminService", function ($http) {

    this.getLog = function () {
        return $http.get("/Admin/GetLog");
    };

});