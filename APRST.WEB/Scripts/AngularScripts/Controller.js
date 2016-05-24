app.controller("TestsCtrl", function ($scope, $uibModal, testService) {
    getAllTests();

    function getAllTests() {
        debugger;
        var getTestsData = testService.getTests();
        getTestsData.then(function (test) {
            $scope.tests = test.data;
        }, function () {
            alert("Ошибка получения списка тестов");
        });
    }

    $scope.animationsEnabled = true;

    $scope.CreateTest = function (size) {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/Test/Create",
            controller: "CreateTestInstanceCtrl",
            size: size
        });
    };

    $scope.DeleteTest = function (size, id) {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/Test/Delete/" + id,
            controller: "DeleteTestInstanceCtrl",
            size: size
        });
    };

    $scope.EditTest = function (size, id) {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/Test/Edit/" + id,
            controller: "EditTestInstanceCtrl",
            size: size
        });
    };

    $scope.showCategories = function (size) {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/TestCategory/Index",
            controller: "CreateTestInstanceCtrl",
            size: size
        });
    };

});

app.controller("CreateTestInstanceCtrl", function ($scope, $uibModalInstance) {
    $scope.cancel = function () {
        $uibModalInstance.dismiss("cancel");
    };
});

app.controller("DeleteTestInstanceCtrl", function ($scope, $uibModalInstance) {
    $scope.cancel = function () {
        $uibModalInstance.dismiss("cancel");
    };
});

app.controller("EditTestInstanceCtrl", function ($scope, $uibModalInstance) {
    $scope.cancel = function () {
        $uibModalInstance.dismiss("cancel");
    };
});

app.controller("TestsingCtrl", function ($scope, testService) {
    $scope.divTestResult = false;
    $scope.divTest = true;

    var testId = document.getElementById("TestId").value;

    getAllQnA(testId);

    function getAllQnA(id) {
        debugger;
        var getQnAData = testService.getQnA(id);
        getQnAData.then(function (qna) {
            $scope.QnAs = qna.data;
        }, function () {
            alert("Ошибка получения вопрсов и ответов");
        });
    }

    $scope.finishTest = function () {
        var testId = document.getElementById("TestId").value;
        var testData = $("input[type=radio]").serializeArray();
        testService.finishTest(testData, testId);
        $scope.divTest = false;
        $scope.divTestResult = true;
    }
});

app.controller("UserCtrl", function ($scope, userService) {

    getAllUsers();
    $scope.animationsEnabled = true;

    function getAllUsers() {
        debugger;
        var getUsersData = userService.getUsers();
        getUsersData.then(function (user) {
            $scope.users = user.data;
        }, function () {
            alert("Ошибка получения списка пользователей");
        });
    }

    $scope.GiveTest = function (size) {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/User/GiveTest",
            controller: "GiveTestInstanceCtrl",
            size: size
        });
    };

});

app.controller("GiveTestInstanceCtrl", function ($scope, $uibModalInstance) {
    $scope.cancel = function () {
        $uibModalInstance.dismiss("cancel");
    };
});

app.controller("UserProfileCtrl", function ($scope, $uibModal, userService) {
    $scope.animationsEnabled = true;

    $scope.GiveTest = function (size) {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/User/GiveTest",
            controller: "GiveTestInstanceCtrl",
            size: size
        });
    };

    var userId = document.getElementById("UserId").value;

    getUserTestsResults(userId);

    function getUserTestsResults(userId) {
        debugger;
        var getUserTestsResultsData = userService.getUserTestsResults(userId);
        getUserTestsResultsData.then(function (userResult) {
            $scope.userResults = userResult.data;
        }, function () {
            alert("Ошибка получения результатов тестирования");
        });
    }
});

app.controller("QuestionsCtrl", function ($scope, $uibModal, testService) {

    var testId = document.getElementById("TestId").value;

    getAllQuestionsForTest(testId);

    function getAllQuestionsForTest(id) {
        debugger;
        var getQuestionsData = testService.getQuestions(id);
        getQuestionsData.then(function (question) {
            $scope.questions = question.data;
        }, function () {
            alert("Ошибка получения списка вопросов");
        });
    }

    $scope.animationsEnabled = true;

    $scope.CreateQuestion = function (size, id) {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/Question/Create/" + id,
            controller: "CreateTestInstanceCtrl",
            size: size
        });
    };

    $scope.DeleteQuestion = function (size, id) {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/Question/Delete/" + id,
            controller: "DeleteTestInstanceCtrl",
            size: size
        });
    };

    $scope.EditQuestion = function (size, id) {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/Question/Edit/" + id,
            controller: "EditTestInstanceCtrl",
            size: size
        });
    };

});

app.controller("AnswersCtrl", function ($scope, $uibModal, testService) {

    var questionId = document.getElementById("QuestionId").value;

    getAllAnswersForQuestion(questionId);

    function getAllAnswersForQuestion(id) {
        debugger;
        var getAnswersData = testService.getAnswers(id);
        getAnswersData.then(function (answer) {
            $scope.answers = answer.data;
        }, function () {
            alert("Ошибка получения списка ответов");
        });
    }

    $scope.animationsEnabled = true;

    $scope.CreateAnswer = function (size, id) {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/Answer/Create/" + id,
            controller: "CreateTestInstanceCtrl",
            size: size
        });
    };

    $scope.DeleteAnswer = function (size, id) {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/Answer/Delete/" + id,
            controller: "DeleteTestInstanceCtrl",
            size: size
        });
    };

    $scope.EditAnswer = function (size, id) {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/Answer/Edit/" + id,
            controller: "EditTestInstanceCtrl",
            size: size
        });
    };

});

app.controller("CategoryCtrl", function ($scope, $uibModal, categoryService) {

    getTestCategories();

    function getTestCategories() {
        debugger;
        var getCategoriesData = categoryService.getCategories();
        getCategoriesData.then(function (category) {
            $scope.categories = category.data;
        }, function () {
            alert("Ошибка получения списка категорий");
        });
    }

    function clearFields() {
        $scope.NameOfCategory = "";
        $scope.Desc = "";
    }

    $scope.CreateCategory = function () {
        $scope.trEdit = false;
        $scope.trDelete = false;
        clearFields();
        $scope.trAdd = true;
    }

    $scope.ShowEditCategory = function (item) {
        $scope.trAdd = false;
        $scope.trDelete = false;
        $scope.categoryId = item.Id;
        $scope.NameOfCategory = item.NameOfCategory;
        $scope.Desc = item.Desc;
        $scope.trEdit = true;
    }

    $scope.ShowDeleteCategory = function (item) {
        $scope.trAdd = false;
        $scope.trEdit = false;
        $scope.categoryId = item.Id;
        $scope.NameOfCategory = item.NameOfCategory;
        $scope.Desc = item.Desc;
        $scope.trDelete = true;
    }

    $scope.CancelCategory = function () {
        $scope.trAdd = false;
        $scope.trEdit = false;
        $scope.trDelete = false;
        clearFields();
    }

    $scope.AddCategory = function () {
        var category = {
            NameOfCategory: $scope.NameOfCategory,
            Desc: $scope.Desc
        };
        var getCategoriesData = categoryService.AddCategory(category);
        getCategoriesData.then(function () {
            $scope.trAdd = false;
            getTestCategories();
            clearFields();
        }, function () {
            alert("Ошибка добавления категории");
        });
    }

    $scope.DeleteCategory = function () {
        var getCategoriesData = categoryService.DeleteCategory($scope.categoryId);
        getCategoriesData.then(function () {
            $scope.trDelete = false;
            getTestCategories();
        }, function () {
            alert("Ошибка удаления выбранной категории");
        });
    }

    $scope.EditCategory = function () {
        var category = {
            NameOfCategory: $scope.NameOfCategory,
            Desc: $scope.Desc
        };

        category.Id = $scope.categoryId;

        var getCategoriesData = categoryService.EditCategory(category);
        getCategoriesData.then(function () {
            $scope.trEdit = false;
            getTestCategories();
        }, function () {
            alert("Ошибка редактирования выбранной категории");
        });
    }


});

app.filter("jsDate", function () {
    return function (x) {
        return new Date(parseInt(x.substr(6)));
    };
});