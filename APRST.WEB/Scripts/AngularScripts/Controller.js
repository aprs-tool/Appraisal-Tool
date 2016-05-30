app.controller("TestsCtrl", function ($scope, $uibModal, testService) {

    $scope.animationsEnabled = true;
    getAllTests();

    function getAllTests() {
        var getTestsData = testService.getTests();
        getTestsData.then(function (test) {
            $scope.tests = test.data;
        }, function () {
            alert("Ошибка получения списка тестов");
        });
    }

    $scope.CreateTest = function (size) {
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/Test/Create",
            controller: "ModalInstanceCtrl",
            size: size
        });
    };

    $scope.DeleteTest = function (size, id) {
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/Test/Delete/" + id,
            controller: "ModalInstanceCtrl",
            size: size
        });
    };

    $scope.EditTest = function (size, id) {
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/Test/Edit/" + id,
            controller: "ModalInstanceCtrl",
            size: size
        });
    };

    $scope.showCategories = function (size) {
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/TestCategory/Index",
            controller: "ModalInstanceCtrl",
            size: size
        });
    };

});

app.controller("TestsingCtrl", function ($scope, testService) {

    $scope.divTestResult = false;
    $scope.divTest = true;

    var testId = document.getElementById("TestId").value;

    getAllQnA(testId);

    function getAllQnA(id) {
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

    $scope.animationsEnabled = true;
    getAllUsers();

    function getAllUsers() {
        var getUsersData = userService.getUsers();
        getUsersData.then(function (user) {
            $scope.users = user.data;
        }, function () {
            alert("Ошибка получения списка пользователей");
        });
    }
});

app.controller("UserProfileCtrl", function ($scope, $uibModal, userService) {

    $scope.animationsEnabled = true;

    $scope.GiveTest = function (size) {
        var userId = document.getElementById("UserId").value;
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/User/GiveTest/" + userId,
            controller: "ModalInstanceCtrl",
            size: size
        });
    };

    $scope.GetQuestionnaire = function (size) {
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/Questionnaire/Index/",
            controller: "ModalInstanceCtrl",
            size: size
        });
    };

    $scope.changeAvatar = function (size) {
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/User/UpdateProfileImage/",
            controller: "ModalInstanceCtrl",
            size: size
        });
    };

    $scope.editProfile = function (size) {
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/User/EditProfile/",
            controller: "ModalInstanceCtrl",
            size: size
        });
    };

    var userId = document.getElementById("UserId").value;

    getUserTestsResults(userId);

    function getUserTestsResults(userId) {
        var getUserTestsResultsData = userService.getUserTestsResults(userId);
        getUserTestsResultsData.then(function (userResult) {
            $scope.userResults = userResult.data;
        }, function () {
            alert("Ошибка получения результатов тестирования");
        });
    }
});

app.controller("UserProfileEditCtrl", function ($scope, userService) {

    getUserProfile();

    function getUserProfile() {
        var getProfileData = userService.getUserProfile();
        getProfileData.then(function (profile) {
            $scope.user = profile.data;
        }, function () {
            alert("Ошибка получения данных профиля");
        });
    }

    $scope.SaveProfile = function() {
        var getProfileData = userService.EditProfile($scope.user);
        getProfileData.then(function () {
        }, function () {
            alert("Ошибка редактирования профиля");
        });
    }

});

app.controller("QuestionsCtrl", function ($scope, $uibModal, testService) {

    var testId = document.getElementById("TestId").value;

    getAllQuestionsForTest(testId);

    function getAllQuestionsForTest(id) {
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
            controller: "ModalInstanceCtrl",
            size: size
        });
    };

    $scope.DeleteQuestion = function (size, id) {
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/Question/Delete/" + id,
            controller: "ModalInstanceCtrl",
            size: size
        });
    };

    $scope.EditQuestion = function (size, id) {
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/Question/Edit/" + id,
            controller: "ModalInstanceCtrl",
            size: size
        });
    };

});

app.controller("AnswersCtrl", function ($scope, $uibModal, testService) {

    var questionId = document.getElementById("QuestionId").value;

    getAllAnswersForQuestion(questionId);

    function getAllAnswersForQuestion(id) {
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
            controller: "ModalInstanceCtrl",
            size: size
        });
    };

    $scope.DeleteAnswer = function (size, id) {
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/Answer/Delete/" + id,
            controller: "ModalInstanceCtrl",
            size: size
        });
    };

    $scope.EditAnswer = function (size, id) {
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/Answer/Edit/" + id,
            controller: "ModalInstanceCtrl",
            size: size
        });
    };

});

app.controller("CategoryCtrl", function ($scope, $uibModal, categoryService) {

    getTestCategories();

    function getTestCategories() {
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
            clearFields();
            getTestCategories();
        }, function () {
            alert("Ошибка редактирования выбранной категории");
        });
    }

});

app.controller("QuestionnaireCtrl", function ($scope, questionnaireService) {

    getQuestionnaire();
    getQuestionnaireResult();

    var results = [];
    var questionnaireResult;
    $scope.rate = [];
    $scope.max = 4;
    $scope.isReadonly = false;

    function getQuestionnaire() {
        var getQuestionnaireData = questionnaireService.getQuestionnaire();
        getQuestionnaireData.then(function (questionnaire) {
            $scope.Questionnaire = questionnaire.data;
        }, function () {
            alert("Ошибка получения анкеты для заполнения");
        });
    }

    function getQuestionnaireResult() {
        var getQuestionnaireResultData = questionnaireService.getQuestionnaireResult();
        getQuestionnaireResultData.then(function (questionnaireResult) {
            questionnaireResult = questionnaireResult.data;

            for (var i = 0; i < questionnaireResult.QuestionnaireResults.length; i++) {
                $scope.rate[questionnaireResult.QuestionnaireResults[i]
                    .QuestionnaireQuestionId] = questionnaireResult.QuestionnaireResults[i].Answer;
                results[i] = questionnaireResult.QuestionnaireResults[i];
            }

        }, function () {
            alert("Ошибка получения результатов анкеты");
        });
    }

    function checkArray(array, keyText) {
        for (var i = 0; i < array.length; i++) {
            if (array[i].QuestionnaireQuestionId === keyText) {
                array[i].Answer = null;
            }
        }
    }

    function clearArray() {
        for (var i = 0; i < results.length; i++) {
            if (results[i].Answer === null) {
                delete results[i];
            }
        }
    }

    $scope.AnswerPush = function (id) {
        checkArray(results, id);
        var ratingObject = {
            QuestionnaireQuestionId: id,
            Answer: $scope.rate[id]
        }
        results.push(ratingObject);
    };

    $scope.finishQuestionnaire = function () {
        clearArray();
        questionnaireService.addQuestionnaire(results);
    };

});

app.controller("QuestionnaireManageCtrl", function ($scope, $uibModal, questionnaireService) {

    $scope.animationsEnabled = true;

    getAllQuestionnaires();

    function getAllQuestionnaires() {
        var getQuestionnairesData = questionnaireService.getQuestionnaires();
        getQuestionnairesData.then(function (questionnaire) {
            $scope.questionnaires = questionnaire.data;
        }, function () {
            alert("Ошибка получения списка анкет");
        });
    }

    $scope.QuestionnaireManage = function (size) {
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/QuestionnaireCategory/Index",
            controller: "ModalInstanceCtrl",
            size: size
        });
    };

    $scope.GetQuestionnaire = function (size) {
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/Questionnaire/Index/",
            controller: "ModalInstanceCtrl",
            size: size
        });
    };

});

app.controller("QuestionnaireManageMCtrl", function ($scope, $uibModal, questionnaireService) {

    $scope.trQuestions = false;
    $scope.trCategories = true;
    getQuestionnairesCategories();
    var CategoryId = 0;

    function getQuestionnairesCategories() {
        var getCategoriesData = questionnaireService.getCategories();
        getCategoriesData.then(function (category) {
            $scope.categories = category.data;
        }, function () {
            alert("Ошибка получения списка категорий");
        });
    };

    function getQuestionsForCategory(categoryId) {
        var getQuestionsData = questionnaireService.getQuestions(categoryId);
        getQuestionsData.then(function (question) {
            $scope.questions = question.data;
        }, function () {
            alert("Ошибка получения списка вопросов");
        });
    };

    function clearFields() {
        $scope.NameOfCategory = "";
        $scope.NameOfQuestion = "";
        $scope.Desc = "";
    };

    $scope.ShowQuestionsForCategory = function (item) {
        getQuestionsForCategory(item.Id);
        CategoryId = item.Id;
        $scope.CategoryName = item.NameOfCategory;
        $scope.trCategories = false;
        $scope.trQuestions = true;
    };

    $scope.toCategories = function () {
        $scope.trQuestions = false;
        $scope.trCategories = true;
    };

    $scope.ShowAddCategory = function () {
        $scope.trEditCategory = false;
        $scope.trDeleteCategory = false;
        $scope.trAddCategory = true;
    };

    $scope.ShowDeleteCategory = function (item) {
        $scope.trAddCategory = false;
        $scope.trEditCategory = false;
        $scope.categoryId = item.Id;
        $scope.NameOfCategory = item.NameOfCategory;
        $scope.Desc = item.Desc;
        $scope.trDeleteCategory = true;
    };

    $scope.ShowEditCategory = function (item) {
        $scope.trAddCategory = false;
        $scope.trDeleteCategory = false;
        $scope.categoryId = item.Id;
        $scope.NameOfCategory = item.NameOfCategory;
        $scope.Desc = item.Desc;
        $scope.trEditCategory = true;
    };

    $scope.CancelCategory = function () {
        $scope.trAddCategory = false;
        $scope.trEditCategory = false;
        $scope.trDeleteCategory = false;
    };

    $scope.AddCategory = function () {
        $scope.trAddCategory = false;
        var category = {
            NameOfCategory: $scope.NameOfCategory,
            Desc: $scope.Desc
        };
        var getCategoriesData = questionnaireService.AddCategory(category);
        getCategoriesData.then(function () {
            getQuestionnairesCategories();
            clearFields();
        },
            function () {
                alert("Ошибка добавления категории");
            });
    };

    $scope.EditCategory = function () {
        $scope.trEditCategory = false;
        var category = {
            NameOfCategory: $scope.NameOfCategory,
            Desc: $scope.Desc
        };

        category.Id = $scope.categoryId;

        var getCategoriesData = questionnaireService.EditCategory(category);
        getCategoriesData.then(function () {
            getQuestionnairesCategories();
            clearFields();
        },
            function () {
                alert("Ошибка редактирования выбранной категории");
            });
    };

    $scope.DeleteCategory = function () {
        $scope.trDeleteCategory = false;
        var getCategoriesData = questionnaireService.DeleteCategory($scope.categoryId);
        getCategoriesData.then(function () {
            getQuestionnairesCategories();
            clearFields();
        },
            function () {
                alert("Ошибка удаления выбранной категории");
            });
    };

    $scope.ShowAddQuestion = function () {
        $scope.trEditQuestion = false;
        $scope.trDeleteQuestion = false;
        $scope.trAddQuestion = true;
    };

    $scope.ShowDeleteQuestion = function (item) {
        $scope.trAddQuestion = false;
        $scope.trEditQuestion = false;
        $scope.questionId = item.Id;
        $scope.NameOfQuestion = item.NameOfQuestion;
        $scope.trDeleteQuestion = true;
    };

    $scope.ShowEditQuestion = function (item) {
        $scope.trAddQuestion = false;
        $scope.trDeleteQuestion = false;
        $scope.questionId = item.Id;
        $scope.NameOfQuestion = item.NameOfQuestion;
        $scope.trEditQuestion = true;
    };

    $scope.CancelQuestion = function () {
        $scope.trAddQuestion = false;
        $scope.trEditQuestion = false;
        $scope.trDeleteQuestion = false;
    };

    $scope.AddQuestion = function () {
        $scope.trAddQuestion = false;
        var question = {
            NameOfQuestion: $scope.NameOfQuestion,
            QuestionnaireCategoryId: CategoryId
        };
        var getQuestionsData = questionnaireService.AddQuestion(question);
        getQuestionsData.then(function () {
            getQuestionsForCategory(CategoryId);
            clearFields();
        },
            function () {
                alert("Ошибка добавления вопроса");
            });
    };

    $scope.EditQuestion = function () {
        $scope.trEditQuestion = false;
        var question = {
            NameOfQuestion: $scope.NameOfQuestion,
            QuestionnaireCategoryId: CategoryId
        };

        question.Id = $scope.questionId;

        var getQuestionsData = questionnaireService.EditQuestion(question);
        getQuestionsData.then(function () {
            getQuestionsForCategory(CategoryId);
            clearFields();
        },
            function () {
                alert("Ошибка редактирования выбранного вопроса");
            });
    };

    $scope.DeleteQuestion = function () {
        $scope.trDeleteQuestion = false;
        var getQuestionsData = questionnaireService.DeleteQuestion($scope.questionId);
        getQuestionsData.then(function () {
            getQuestionsForCategory(CategoryId);
            clearFields();
        },
            function () {
                alert("Ошибка удаления выбранного вопроса");
            });
    };

});

app.controller("AdminCtrl", function ($scope, adminService) {

    getLog();

    function getLog() {
        var getLogData = adminService.getLog();
        getLogData.then(function (log) {
            $scope.log = log.data;
        }, function () {
            alert("Ошибка получения лога");
        });
    }

});

app.controller("AvatarCtrl", function ($scope, userService) {

    getUserProfile();

    function getUserProfile() {
        var getProfileData = userService.getUserProfile();
        getProfileData.then(function (profile) {
            $scope.user = profile.data;
            if (profile.data.Avatar != null) {
                $scope.avatar = profile.data.Avatar;
            } else {
                $scope.avatar = "/content/images/no-avatar.png";
            }
        }, function () {
            alert("Ошибка получения данных профиля");
        });
    }

});

app.controller("ModalInstanceCtrl", function ($scope, $uibModalInstance, $window) {
    $scope.cancel = function () {
        $uibModalInstance.dismiss("cancel");
    };

    $scope.reload = function () {
        $window.location.href = "/User/Index";
    };
});

app.filter("jsDate", function () {
    return function (x) {
        return new Date(parseInt(x.substr(6)));
    };
});