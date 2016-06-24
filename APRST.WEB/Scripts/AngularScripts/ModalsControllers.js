//---Start Tests Modals---//
app.controller("CreateOrEditTestCtrl", function ($scope, $uibModalInstance, testsCategoriesService, scopes, items) {

    getCategories();
    $scope.modalTitle = "Создание нового теста";
    $scope.buttonTitle = "Добавить";

    if (items != null) {
        $scope.test = items;
        $scope.test.TestCategoryId = items.TestCategoryId.toString();
        $scope.modalTitle = "Редактирование теста";
        $scope.buttonTitle = "Сохранить изменения";
    }

    function getCategories() {
        $scope.categoryResource = testsCategoriesService.getCategories();
        $scope.categoryResource
            .query()
            .$promise
            .then(fulfilled, rejected);
    }

    function fulfilled(result) {
        $scope.categories = result;
    };

    function rejected(error) {
        if (error.status === 404) {
            alert(error.data);
        }
        if (error.status === 500) {
            alert("Ошибка сервера.");
        }
    };

    function findCategory(test) {
        var nameOfCategory = "";
        for (var i = 0; i < $scope.categories.length; i++) {
            if ($scope.categories[i].Id === parseInt(test.TestCategoryId)) {
                nameOfCategory = $scope.categories[i].NameOfCategory;
            }
        }
        return nameOfCategory;
    };

    $scope.ok = function (test) {
        $scope.testForPush = {
            NameOfTest: test.NameOfTest,
            Desc: test.Desc,
            Category: findCategory(test),
            TestCategoryId: test.TestCategoryId
        }
        scopes.store("testForPush", $scope.testForPush);
        $uibModalInstance.close(test);
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss();
    };
});

app.controller("DeleteTestCtrl", function ($scope, $uibModalInstance, items) {
    $scope.test = items;

    $scope.delete = function () {
        $uibModalInstance.close($scope.test);
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss();
    };
});
//---End Tests Modals---//

//---Start TestsQuestions Modals---//
app.controller("CreateOrEditTestQuestionCtrl", function ($scope, $uibModalInstance, scopes, items) {

    $scope.modalTitle = "Добавление вопроса к тесту";
    $scope.buttonTitle = "Добавить вопрос";

    if (items != null) {
        $scope.question = items;
        $scope.modalTitle = "Редактирование вопроса теста";
        $scope.buttonTitle = "Сохранить изменения";
    }

    $scope.ok = function (question) {
        question.TestId = scopes.get("currentTest").Id;
        $uibModalInstance.close(question);
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss();
    };
});

app.controller("DeleteTestQuestionCtrl", function ($scope, $uibModalInstance, items) {
    $scope.question = items;

    $scope.delete = function () {
        $uibModalInstance.close($scope.question);
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss();
    };
});
//---End TestsQuestions Modals---//

//---Start TestsAnswers Modals---//
app.controller("TestsAnswersCtrl", function ($scope, $uibModal, $uibModalInstance, testsAnswersService, items, scopes, testsAnswersPut) {

    $scope.QuestionName = items.Question;
    getAllAnswersForQuestion(items.Id);

    function getAllAnswersForQuestion(id) {
        $scope.AnswersResource = testsAnswersService.getAnswers();
        $scope.AnswersResource.get({ Id: id })
        .$promise.then(fulfilled, rejected);
    };

    function fulfilled(result) {
        $scope.answers = result;
        $scope.totalPoints = getTotalPoints();
    };

    function rejected(error) {
        if (error.status === 404) {
            alert(error.data);
        }
        if (error.status === 500) {
            alert("Ошибка сервера.");
        }
    };

    function getTotalPoints() {
        var total = 0;
        for (var i = 0; i < $scope.answers.AnswersDTO.length; i++) {
            total += $scope.answers.AnswersDTO[i].Point;
        }
        return total;
    };

    function createAnswer(item) {
        new $scope.AnswersResource(item).$save().then(function () {
            getAllAnswersForQuestion(items.Id);
        });
    };

    function editAnswer(item) {
        testsAnswersPut.update(item);
    };

    $scope.DeleteAnswer = function (item) {
        testsAnswersPut.delete(item);
        $scope.trDelete = false;
        $scope.answers.AnswersDTO.splice($scope.answers.AnswersDTO.indexOf(item), 1);
    };

    $scope.CreateAnswer = function (size) {
        scopes.store("Question", items);
        var modalInstance = $uibModal.open({
            animation: true,
            templateUrl: "/Content/Views/Tests/AnswersModals/CreateOrEdit.html",
            controller: "CreateOrEditTestAnswerCtrl",
            resolve: {
                items: function () {
                    return null;
                }
            },
            size: size
        });

        modalInstance.result.then(function (answer) {
            createAnswer(answer);
        });
    };

    $scope.EditAnswer = function (size, item) {
        $scope.copy = angular.copy(item);
        scopes.store("Question", items);
        var modalInstance = $uibModal.open({
            animation: true,
            templateUrl: "/Content/Views/Tests/AnswersModals/CreateOrEdit.html",
            controller: "CreateOrEditTestAnswerCtrl",
            resolve: {
                items: function () {
                    return $scope.copy;
                }
            },
            size: size
        });

        modalInstance.result.then(function (answer) {
            editAnswer(answer);
            item.Answer = answer.Answer;
            item.Point = answer.Point;
            $scope.totalPoints = getTotalPoints();
        });
    };

    $scope.showDelete = function (item) {
        $scope.deleteItem = item;
        $scope.trDelete = true;
    };

    $scope.CancelDeleting = function () {
        $scope.trDelete = false;
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss();
    };
});

app.controller("CreateOrEditTestAnswerCtrl", function ($scope, $uibModalInstance, items, scopes) {
    $scope.modalTitle = "Добавление ответа к вопросу";
    $scope.buttonTitle = "Добавить ответ";

    if (items != null) {
        $scope.answer = items;
        $scope.buttonTitle = "Сохранить изменения";
        $scope.modalTitle = "Редактирование ответа";
    };

    $scope.ok = function () {
        $scope.answer.QuestionId = scopes.get("Question").Id;
        $uibModalInstance.close($scope.answer);
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss();
    };
});
//---End TestsAnswers Modals---//

//---Start TestsCategories Modals---//
app.controller("TestsCategoriesCtrl", function ($scope, $uibModalInstance, testsCategoriesService, testsCategoriesPut) {

    getCategories();

    function getCategories() {
        $scope.CategoryResource = testsCategoriesService.getCategories();
        $scope.CategoryResource
            .query()
            .$promise
            .then(fulfilled, rejected);
    };

    function fulfilled(result) {
        $scope.categories = result;
    };

    function rejected(error) {
        if (error.status === 404) {
            alert(error.data);
        }
        if (error.status === 500) {
            alert("Ошибка сервера.");
        }
    };

    function clearFields() {
        $scope.category = null;
    };

    $scope.CreateCategory = function () {
        clearFields();
        $scope.copy = angular.copy($scope.categories);
        $scope.trEdit = true;
        $scope.btnAdd = true;
        $scope.btnEdit = false;
        $scope.btnDelete = false;
        $scope.deleteClass = null;
    };

    $scope.ShowEditCategory = function (item) {
        clearFields();
        $scope.copy = angular.copy($scope.categories);
        $scope.category = item;
        $scope.trEdit = true;
        $scope.btnAdd = false;
        $scope.btnEdit = true;
        $scope.btnDelete = false;
        $scope.deleteClass = null;
    };

    $scope.ShowDeleteCategory = function (item) {
        clearFields();
        $scope.copy = angular.copy($scope.categories);
        $scope.category = item;
        $scope.trEdit = true;
        $scope.btnAdd = false;
        $scope.btnEdit = false;
        $scope.btnDelete = true;
        $scope.deleteClass = "input-g-delete";
    };

    $scope.CancelCategory = function () {
        $scope.trEdit = false;
        $scope.categories = $scope.copy;
        clearFields();
    };

    $scope.AddCategory = function () {
        new $scope.CategoryResource($scope.category).$save().then(function () {
            $scope.trEdit = false;
            clearFields();
            getCategories();
        });
    };

    $scope.EditCategory = function () {
        testsCategoriesPut.update($scope.category);
        $scope.trEdit = false;
        clearFields();
    };

    $scope.DeleteCategory = function () {
        $scope.category.$delete().then(function () {
            $scope.categories.splice($scope.categories.indexOf($scope.category), 1);
            $scope.trEdit = false;
        });
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss();
    };

});
//---End TestsCategories Modals---//

//---Start Questionnaires Modals---//
app.controller("QuestionnairesManageCtrl", function ($scope, $uibModalInstance, questionnaireService, questionnairesCategoriesApi, questionnairesQuestionsApi, scopes) {

    $scope.trQuestions = false;
    $scope.trCategories = true;

    getQuestionnaire();

    function getQuestionnaire() {
        $scope.QuestionnaireResource = questionnaireService.get();
        $scope.QuestionnaireResource.query()
            .$promise
            .then(fulfilled, rejected);
    };

    function fulfilled(result) {
        $scope.questionnaire = result;
        $scope.category = searchCategoryById(scopes.get("currentCategory"));
    };

    function rejected(error) {
        if (error.status === 404) {
            alert(error.data);
        }
        if (error.status === 500) {
            alert("Ошибка сервера.");
        }
    };

    function searchCategoryById(categoryId) {
        var category = null;
        for (var i = 0; i < $scope.questionnaire.length; i++) {
            if ($scope.questionnaire[i].Id === categoryId) {
                category = $scope.questionnaire[i];
            }
        }
        return category;
    };

    function clearFieldsCategory() {
        $scope.category = null;
    };

    function clearFieldsQuestion() {
        $scope.question = null;
    };

    $scope.ShowQuestionsForCategory = function (item) {
        $scope.category = item;
        $scope.trCategories = false;
        $scope.trQuestions = true;
    };

    $scope.toCategories = function () {
        $scope.trQuestions = false;
        $scope.trCategories = true;
    };

    $scope.ShowAddCategory = function () {
        clearFieldsCategory();
        $scope.copy = angular.copy($scope.questionnaire);
        $scope.btnAdd = true;
        $scope.btnEdit = false;
        $scope.btnDelete = false;
        $scope.trEditCategory = true;
    };

    $scope.ShowDeleteCategory = function (item) {
        clearFieldsCategory();
        $scope.copy = angular.copy($scope.questionnaire);
        $scope.btnAdd = false;
        $scope.btnEdit = false;
        $scope.btnDelete = true;
        $scope.trEditCategory = true;
        $scope.category = item;
    };

    $scope.ShowEditCategory = function (item) {
        clearFieldsCategory();
        $scope.copy = angular.copy($scope.questionnaire);
        $scope.btnAdd = false;
        $scope.btnEdit = true;
        $scope.btnDelete = false;
        $scope.trEditCategory = true;
        $scope.category = item;
    };

    $scope.CancelCategory = function () {
        $scope.trEditCategory = false;
        $scope.questionnaire = $scope.copy;
        clearFieldsCategory();
    };

    $scope.AddCategory = function () {
        $scope.trEditCategory = false;
        questionnairesCategoriesApi.add($scope.category).$promise
            .then(getQuestionnaire, rejected);
        clearFieldsCategory();
    };

    $scope.EditCategory = function () {
        $scope.trEditCategory = false;
        questionnairesCategoriesApi.update($scope.category);
        clearFieldsCategory();
    };

    $scope.DeleteCategory = function () {
        $scope.trEditCategory = false;
        questionnairesCategoriesApi.delete($scope.category);
        $scope.questionnaire.splice($scope.questionnaire.indexOf($scope.category), 1);
        clearFieldsCategory();
    };

    $scope.ShowAddQuestion = function () {
        clearFieldsQuestion();
        $scope.copyQuestions = angular.copy($scope.category.QuestionnaireQuestionDtos);
        $scope.btnAddQ = true;
        $scope.btnEditQ = false;
        $scope.btnDeleteQ = false;
        $scope.trEditQuestion = true;
    };

    $scope.ShowDeleteQuestion = function (item) {
        clearFieldsQuestion();
        $scope.copyQuestions = angular.copy($scope.category.QuestionnaireQuestionDtos);
        $scope.btnAddQ = false;
        $scope.btnEditQ = false;
        $scope.btnDeleteQ = true;
        $scope.question = item;
        $scope.trEditQuestion = true;
    };

    $scope.ShowEditQuestion = function (item) {
        clearFieldsQuestion();
        $scope.copyQuestions = angular.copy($scope.category.QuestionnaireQuestionDtos);
        $scope.btnAddQ = false;
        $scope.btnEditQ = true;
        $scope.btnDeleteQ = false;
        $scope.question = item;
        $scope.trEditQuestion = true;
    };

    $scope.CancelQuestion = function () {
        $scope.trEditQuestion = false;
        $scope.category.QuestionnaireQuestionDtos = $scope.copyQuestions;
        clearFieldsQuestion();
    };

    $scope.AddQuestion = function () {
        $scope.trEditQuestion = false;
        $scope.question.QuestionnaireCategoryId = $scope.category.Id;
        scopes.store("currentCategory", $scope.category.Id);
        questionnairesQuestionsApi.add($scope.question).$promise
            .then(getQuestionnaire, rejected);
        clearFieldsQuestion();
    };

    $scope.EditQuestion = function () {
        $scope.trEditQuestion = false;
        questionnairesQuestionsApi.update($scope.question);
        clearFieldsQuestion();
    };

    $scope.DeleteQuestion = function () {
        $scope.trEditQuestion = false;
        questionnairesQuestionsApi.delete($scope.question);
        $scope.category.QuestionnaireQuestionDtos.splice($scope.category.QuestionnaireQuestionDtos.indexOf($scope.question), 1);
        clearFieldsQuestion();
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss();
    };

});

app.controller("QuestionnaireCtrl", function ($scope, $uibModalInstance, questionnaireService, questionnairesService, questionnairesApi, scopes, items) {

    getQuestionnaire();

    if (items != null) {
        getQuestionnaireResult(items.UserId);
        $scope.isReadonly = true;
        $scope.userSave = false;
        $scope.userName = "пользователя: " + items.UserProfile;
    } else {
        getQuestionnaireResult(scopes.get("userData").Id);
        $scope.isReadonly = false;
        $scope.userSave = true;
        $scope.userName = "пользователя: " + scopes.get("userData").UserIdentityName;
    }

    var results = [];
    $scope.rate = [];
    $scope.max = 4;

    function getQuestionnaire() {
        $scope.QuestionnaireResource = questionnaireService.get();
        $scope.QuestionnaireResource.query()
            .$promise
            .then(fulfilledQuestionnaire, rejected);
    };

    function getQuestionnaireResult(id) {
        $scope.QuestionnaireAnswersResource = questionnairesService.get();
        $scope.QuestionnaireAnswersResource.get({ Id: id })
        .$promise.then(fulfilledQuestionnaireResult, rejected);
    };

    function fulfilledQuestionnaire(result) {
        $scope.Questionnaire = result;
    };

    function fulfilledQuestionnaireResult(result) {
        for (var i = 0; i < result.QuestionnaireResults.length; i++) {
            $scope.rate[result.QuestionnaireResults[i]
                .QuestionnaireQuestionId] = result.QuestionnaireResults[i].Answer;
            results[i] = result.QuestionnaireResults[i];
        }
    };

    function rejected(error) {
        if (error.status === 404) {
            alert(error.data);
        }
        if (error.status === 500) {
            alert("Ошибка сервера.");
        }
    };

    function checkArray(array, keyText) {
        for (var i = 0; i < array.length; i++) {
            if (array[i].QuestionnaireQuestionId === keyText) {
                array[i].Answer = null;
            }
        }
    };

    function clearArray() {
        for (var i = 0; i < results.length; i++) {
            if (results[i].Answer === null) {
                delete results[i];
            }
        }
    };

    $scope.AnswerPush = function (id) {
        checkArray(results, id);
        var ratingObject = {
            QuestionnaireQuestionId: id,
            Answer: $scope.rate[id]
        };
        results.push(ratingObject);
    };

    $scope.finishQuestionnaire = function () {
        clearArray();
        questionnairesApi.update(results);
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss();
    };

});
//---End Questionnaires Modals---//

//---Start Users Modals---//
app.controller("UserProfileInstanceCtrl", function ($scope, $uibModal, $uibModalInstance, usersService, adminApi, items, scopes, userProfilePut) {

    getUserProfile(items);

    function getUserProfile(userId) {
        $scope.UserResource = usersService.get();
        $scope.UserResource.get({ Id: userId })
        .$promise.then(fulfilled, rejected);
    };

    function fulfilled(result) {
        $scope.userProfile = result;

        if (result.Avatar != null) {
            $scope.avatar = '<img src="' + result.Avatar + '" alt="Ваш аватар">';
        } else {
            $scope.avatar = '<img src="/content/images/no-avatar.png" alt="Загрузите аватар">';
        }

        if (result.TestResults.length === 0) {
            $scope.userNoTestsResults = true;
        }
        if (result.Tests.length === 0) {
            $scope.userNoTests = true;
        }
        if (scopes.get("userData").Role === "Admin") {
            $scope.isAdmin = true;
        }
    };

    function rejected(error) {
        if (error.status === 404) {
            alert(error.data);
        }
        if (error.status === 500) {
            alert("Ошибка сервера.");
        }
    };

    $scope.giveTest = function (size) {
        var modalInstance = $uibModal.open({
            animation: true,
            templateUrl: "/Content/Views/User/Modals/GiveTest.html",
            controller: "GiveTestInstanceCtrl",
            size: size
        });

        modalInstance.result.then(function (test) {
            giveTest(test);
        });
    };

    $scope.changeRole = function (size) {
        var modalInstance = $uibModal.open({
            animation: true,
            templateUrl: "/Content/Views/User/Modals/ChangeRole.html",
            controller: "ChangeRoleInstanceCtrl",
            size: size
        });

        modalInstance.result.then(function (role) {
            changeRole(role);
        });
    };

    function giveTest(test) {

        var userTest = {
            userid: $scope.userProfile.Id,
            testid: test.Id
        };

        var consist = false;
        
        for (var i = 0; i < $scope.userProfile.Tests.length; i++) {
            if ($scope.userProfile.Tests[i].Id === test.Id) {
                consist = true;
            }
        };
        if (consist === false) {
            adminApi.giveTest(userTest);
            $scope.userNoTests = false;
            $scope.userProfile.Tests.push(test);
        };
    };

    function changeRole(role) {
        $scope.userProfile.UserRoleId = role.Id;
        $scope.userProfile.Role = role.RoleName;
        userProfilePut.update($scope.userProfile);
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss();
    };
});

app.controller("ChangeAvatarInstanceCtrl", function ($scope, $uibModalInstance) {
    $scope.ok = function () {
        var file = $scope.fileAvatar;

        if (file.type === "image/png" || file.type === "image/jpeg") {
            $uibModalInstance.close(file);
        } else {
            $scope.errorType = true;
        }
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss();
    };
});

app.controller("EditProfileInstanceCtrl", function ($scope, $uibModalInstance, items) {
    $scope.userProfile = items;

    $scope.ok = function () {
        $uibModalInstance.close($scope.userProfile);
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss();
    };
});
//---End Users Modals---//

//---Start Admin Modals---//
app.controller("GiveTestInstanceCtrl", function ($scope, $uibModalInstance) {
    $scope.ok = function (test) {
        $uibModalInstance.close(test);
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss("cancel");
    };
});

app.controller("ChangeRoleInstanceCtrl", function ($scope, $uibModalInstance, adminService) {
    getRoles();

    function getRoles() {
        adminService.getRoles().query()
            .$promise
            .then(fulfilled, rejected);
    };

    function fulfilled(result) {
        $scope.roles = result;
    };

    function rejected(error) {
        if (error.status === 404) {
            alert(error.data);
        }
        if (error.status === 500) {
            alert("Ошибка сервера.");
        }
    };

    $scope.ok = function (role) {
        $uibModalInstance.close(role);
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss();
    };
});
//---End Admin Modals---//

//--Settings--//

app.controller("SettingsInstanceCtrl", function ($scope, $uibModalInstance) {
    $scope.cancel = function () {
        $uibModalInstance.dismiss();
    };
});

//--Settings--//