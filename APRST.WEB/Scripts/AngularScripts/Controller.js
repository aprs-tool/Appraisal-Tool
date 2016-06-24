/////Start Test Ctrls/////
app.controller("TestsCtrl", function ($rootScope, $scope, $uibModal, testService, scopes, testsPut) {

    $scope.animationsEnabled = true;
    $scope.itemsPerPage = 10;
    $scope.currentPage = 1;
    $scope.selectedClass = "col-md-12";

    getAllTests();

    $scope.ShowQuestions = function (item) {
        $scope.selectedClass = "col-md-7";
        $scope.questions = "/Content/Views/Tests/Questions.html";
        scopes.store("currentTest", item);
        $rootScope.$emit("getQuestionsForCurrentTest", {});
    };

    function getAllTests() {
        $scope.TestsResource = testService.getTests();
        $scope.TestsResource.query()
            .$promise
            .then(fulfilled, rejected);
    };

    function fulfilled(result) {
        $scope.tests = result;
        $scope.TotalItems = $scope.tests.length;
    };

    function rejected(error) {
        if (error.status === 404) {
            alert(error.data);
        }
        if (error.status === 500) {
            alert("Ошибка сервера.");
        }
    };

    function createTest(item) {
        new $scope.TestsResource(item).$save().then(function () {
            getAllTests();
        });
    };

    function editTest(item) {
        testsPut.update(item);
    };

    function deleteTest(item) {
        item.$delete().then(function () {
            $scope.tests.splice($scope.tests.indexOf(item), 1);
        });
    };

    $scope.CreateTest = function (size) {
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/Content/Views/Tests/Modals/CreateOrEdit.html",
            controller: "CreateOrEditTestCtrl",
            resolve: {
                items: function () {
                    return null;
                }
            },
            size: size
        });

        modalInstance.result.then(function (test) {
            createTest(test);
        });
    };

    $scope.EditTest = function (size, item) {
        $scope.copy = angular.copy(item);
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/Content/Views/Tests/Modals/CreateOrEdit.html",
            controller: "CreateOrEditTestCtrl",
            resolve: {
                items: function () {
                    return $scope.copy;
                }
            },
            size: size
        });

        modalInstance.result.then(function (test) {
            editTest(test);
            var updatedTest = scopes.get("testForPush");
            item.NameOfTest = updatedTest.NameOfTest;
            item.Desc = updatedTest.Desc;
            item.Category = updatedTest.Category;
        });
    };

    $scope.DeleteTest = function (size, item) {
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/Content/Views/Tests/Modals/Delete.html",
            controller: "DeleteTestCtrl",
            resolve: {
                items: function () {
                    return item;
                }
            },
            size: size
        });

        modalInstance.result.then(function (test) {
            deleteTest(test);
        });
    };

    $scope.showCategories = function (size) {
        $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/Content/Views/Tests/CategoriesModals/Categories.html",
            controller: "TestsCategoriesCtrl",
            size: size
        });
    };

});

app.controller("QuestionsCtrl", function ($rootScope, $scope, $uibModal, testsQuestionsService, scopes, testsQuestionsPut) {

    $scope.animationsEnabled = true;
    $scope.itemsPerPage = 10;
    $scope.currentPage = 1;
    getAllQuestionsForTest(scopes.get("currentTest").Id);

    $rootScope.$on("getQuestionsForCurrentTest", function () {
        getAllQuestionsForTest(scopes.get("currentTest").Id);
    });

    function getAllQuestionsForTest(id) {
        $scope.QuestionsResource = testsQuestionsService.getQuestions();
        $scope.QuestionsResource.get({ Id: id })
        .$promise.then(fulfilled, rejected);
    };

    function fulfilled(result) {
        $scope.questions = result;

        $scope.TotalItems = $scope.questions.QuestionsDTO.length;
    };

    function rejected(error) {
        if (error.status === 404) {
            alert(error.data);
        }
        if (error.status === 500) {
            alert("Ошибка сервера.");
        }
    };

    function createQuestion(item) {
        new $scope.QuestionsResource(item).$save().then(function () {
            getAllQuestionsForTest(scopes.get("currentTest").Id);
        });
    };

    function editQuestion(item) {
        testsQuestionsPut.update(item);
    };

    function deleteQuestion(item) {
        testsQuestionsPut.delete(item);
        $scope.questions.QuestionsDTO.splice($scope.questions.QuestionsDTO.indexOf(item), 1);
    };

    $scope.CreateQuestion = function (size) {
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/Content/Views/Tests/QuestionsModals/CreateOrEdit.html",
            controller: "CreateOrEditTestQuestionCtrl",
            resolve: {
                items: function () {
                    return null;
                }
            },
            size: size
        });

        modalInstance.result.then(function (question) {
            createQuestion(question);
        });
    };

    $scope.EditQuestion = function (size, item) {
        $scope.copy = angular.copy(item);
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/Content/Views/Tests/QuestionsModals/CreateOrEdit.html",
            controller: "CreateOrEditTestQuestionCtrl",
            resolve: {
                items: function () {
                    return $scope.copy;
                }
            },
            size: size
        });

        modalInstance.result.then(function (question) {
            editQuestion(question);
            item.Question = question.Question;
        });
    };

    $scope.DeleteQuestion = function (size, item) {
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/Content/Views/Tests/QuestionsModals/Delete.html",
            controller: "DeleteTestQuestionCtrl",
            resolve: {
                items: function () {
                    return item;
                }
            },
            size: size
        });

        modalInstance.result.then(function (question) {
            deleteQuestion(question);
        });
    };

    $scope.ShowAnswers = function (size, item) {
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/Content/Views/Tests/AnswersModals/Answers.html",
            controller: "TestsAnswersCtrl",
            resolve: {
                items: function () {
                    return item;
                }
            },
            size: size
        });

        modalInstance.result.then(function (question) {
            deleteQuestion(question);
        });
    };

});
/////End Test Ctrls/////

/////Start Questionnaire Ctrls/////
app.controller("QuestionnairesCtrl", function ($scope, $uibModal, questionnairesService) {

    getAllQuestionnaires();
    $scope.itemsPerPage = 10;
    $scope.currentPage = 1;

    function getAllQuestionnaires() {
        $scope.QuestionnairesResource = questionnairesService.get();
        $scope.QuestionnairesResource.query()
            .$promise
            .then(fulfilled, rejected);
    };

    function fulfilled(result) {
        $scope.questionnaires = result;
        $scope.TotalItems = $scope.questionnaires.length;
    };

    function rejected(error) {
        if (error.status === 404) {
            alert(error.data);
        }
        if (error.status === 500) {
            alert("Ошибка сервера.");
        }
    };

    $scope.QuestionnairesManage = function (size) {
        $uibModal.open({
            animation: true,
            templateUrl: "/Content/Views/Questionnaires/Modals/Manage.html",
            controller: "QuestionnairesManageCtrl",
            size: size
        });
    };

    $scope.GetQuestionnaire = function (size) {
        $uibModal.open({
            animation: true,
            templateUrl: "/Content/Views/Questionnaires/Modals/Questionnaire.html",
            controller: "QuestionnaireCtrl",
            resolve: {
                items: function () {
                    return null;
                }
            },
            size: size
        });
    };

    $scope.GetUserQuestionnaire = function (size, user) {
        $uibModal.open({
            animation: true,
            templateUrl: "/Content/Views/Questionnaires/Modals/Questionnaire.html",
            controller: "QuestionnaireCtrl",
            resolve: {
                items: function () {
                    return user;
                }
            },
            size: size
        });
    };

});
/////End Questionnaire Ctrls/////

/////Start Users Ctrls/////
app.controller("UsersCtrl", function ($scope, $uibModal, usersService) {

    getAllUsers();
    $scope.itemsPerPage = 10;
    $scope.currentPage = 1;

    function getAllUsers() {
        $scope.UsersResource = usersService.get();
        $scope.UsersResource.query()
            .$promise
            .then(fulfilled, rejected);
    };

    function fulfilled(result) {
        $scope.users = result;
        $scope.TotalItems = $scope.users.length;
    };

    function rejected(error) {
        if (error.status === 404) {
            alert(error.data);
        }
        if (error.status === 500) {
            alert("Ошибка сервера.");
        }
    };

    $scope.more = function (size, userId) {
        $uibModal.open({
            animation: true,
            templateUrl: "/Content/Views/User/Modals/UserProfileModal.html",
            controller: "UserProfileInstanceCtrl",
            resolve: {
                items: function () {
                    return userId;
                }
            },
            size: size
        });
    };
});

app.controller("UserProfileCtrl", function ($rootScope, $scope, $uibModal, $window, userService, adminApi, userProfilePut, scopes) {

    if (scopes.get("userData") == undefined) {
        getUserProfile();
    } else {
        $scope.userProfile = scopes.get("userData");
        $scope.avatar = scopes.get("userAvatar");
    };

    $rootScope.$on("updateProfile", function () {
        reloadPage();
    });

    $scope.itemsPerPage = 10;
    $scope.currentPage = 1;

    $scope.animationsEnabled = true;

    function getUserProfile() {
        $scope.UserResource = userService.get();
        $scope.UserResource.get()
            .$promise
            .then(fulfilled, rejected);
    };

    function fulfilled(result) {
        $scope.userProfile = result;
        scopes.store("userData", result);
        if (result.Avatar != null) {
            $scope.avatar = '<img src="' + result.Avatar + '" alt="Ваш аватар">';
            scopes.store("userAvatar", $scope.avatar);
        } else {
            $scope.avatar = '<img src="/content/images/no-avatar.png" alt="Загрузите аватар">';
            scopes.store("userAvatar", $scope.avatar);
        }

        if (result.TestResults.length === 0) {
            $scope.userNoTestsResults = true;
        }
        if (result.Tests.length === 0) {
            $scope.userNoTests = true;
        }
        if (result.Role === "Admin") {
            $scope.isAdmin = true;
        }

        $scope.TotalItems = $scope.userProfile.Tests.length;
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
            animation: $scope.animationsEnabled,
            templateUrl: "/Content/Views/User/Modals/GiveTest.html",
            controller: "GiveTestInstanceCtrl",
            size: size
        });

        modalInstance.result.then(function (test) {
            giveTest(test);
        });
    };

    $scope.changeAvatar = function (size) {
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/Content/Views/User/Modals/ChangeAvatar.html",
            controller: "ChangeAvatarInstanceCtrl",
            size: size
        });

        modalInstance.result.then(function (file) {
            userService.changeAvatar(file);
            reloadPage();
        });
    };

    $scope.editProfile = function (size) {
        $scope.copy = angular.copy($scope.userProfile);
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "/Content/Views/User/Modals/EditProfile.html",
            controller: "EditProfileInstanceCtrl",
            resolve: {
                items: function () {
                    return $scope.copy;
                }
            },
            size: size
        });

        modalInstance.result.then(function (userProfile) {
            saveProfile(userProfile);
        });
    };

    $scope.sendTest = function (test) {
        scopes.store("currentTesting", test);
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

    function saveProfile(userProfile) {
        userProfilePut.update(userProfile);
        $scope.userProfile = userProfile;
    };

    function reloadPage() { window.location.reload(); };
});
/////End Users Ctrls/////

/////Start Settings Ctrl/////
app.controller("SettingsCtrl", function ($scope, $uibModal) {
    $scope.ShowSettings = function () {
        $uibModal.open({
            animation: true,
            templateUrl: "/Content/Views/Admin/Modals/Settings.html",
            controller: "SettingsInstanceCtrl",
            size: "sm"
        });
    };
});
/////End Settings Ctrl/////

/////Start Admin Ctrl/////
app.controller("AdminCtrl", function ($scope, adminService) {

    getCounters();
    getLog();

    $scope.itemsPerPage = 10;
    $scope.currentPage = 1;

    function getLog() {
        adminService.getLog().query()
            .$promise
            .then(fulfilledLog, rejected);
    };

    function getCounters() {
        adminService.getCounters().get()
            .$promise
            .then(fulfilledCounters, rejected);
    };

    function fulfilledLog(result) {
        $scope.log = result;
        $scope.TotalItems = $scope.log.length;
    };

    function fulfilledCounters(result) {
        $scope.counters = result;
    };

    function rejected(error) {
        if (error.status === 404) {
            alert(error.data);
        }
        if (error.status === 500) {
            alert("Ошибка сервера.");
        }
    };

});
/////End Admin Ctrl/////

app.controller("TestsingCtrl", function ($rootScope, $scope, testingService, scopes) {

    $scope.divTestResult = false;
    $scope.divTest = true;

    var currentTest = scopes.get("currentTesting");
    $scope.nameoftest = currentTest.NameOfTest;

    getAllQnA(currentTest.Id);

    function getAllQnA(id) {
        $scope.QuestionnaireAnswersResource = testingService.get();
        $scope.QuestionnaireAnswersResource.query({ Id: id })
        .$promise.then(fulfilled, rejected);
    };

    function fulfilled(result) {
        $scope.QnAs = result;
    };

    $scope.updateProfile = function() {
        $rootScope.$emit("updateProfile", {});
    };

    function rejected(error) {
        if (error.status === 404) {
            alert(error.data);
        }
        if (error.status === 500) {
            alert("Ошибка сервера.");
        }
    };

    $scope.finishTest = function () {
        $scope.divTest = false;
        $scope.divTestResult = true;
        var testData = $("input[type=radio]").serializeArray();
        testData.TestId = currentTest.Id;
        testingService.finishTest(testData, currentTest.Id);
    };
});

//----------------directives----------------//

app.directive("fileModel", ["$parse", function ($parse) {
    return {
        restrict: "A",
        link: function (scope, element, attrs) {
            var model = $parse(attrs.fileModel);
            var modelSetter = model.assign;

            element.bind("change", function () {
                scope.$apply(function () {
                    modelSetter(scope, element[0].files[0]);
                });
            });
        }
    };
}]);

app.directive("noScrollbar", ["$rootScope",
      function ($rootScope) {

          return {
              restrict: "C",
              link: function (scope, element, attrs) {
                  if (!$rootScope.scrollbarWidth) {
                      var scrollDiv = document.createElement("div");
                      scrollDiv.className = "scrollbar-measurer";
                      document.body.appendChild(scrollDiv);
                      $rootScope.scrollbarWidth = scrollDiv.offsetWidth - scrollDiv.clientWidth;
                      document.body.removeChild(scrollDiv);
                  }

                  element.css("padding-right", parseInt(element.css("padding-right")) + $rootScope.scrollbarWidth);
              }
          };

      }
]);

//----------------directives----------------//