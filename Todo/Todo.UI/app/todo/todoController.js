todoApp.controller('todoController', ["$rootScope", "$scope", "dbServices", function ($rootScope, $scope, services) {
    $scope.saluto = "";
    $scope.todos = [];
    $scope.selectedTodo = {};
    //$scope.test = moment().startOf('day').fromNow(); 
    $scope.delete = deleteTodo;
    $scope.edit = editTodo;
    $scope.save = saveTodo;
    $scope.reset = reset;
    getTodos();

    function reset() {
        $scope.selectedTodo = {};
    }
    function editTodo(todo) {
        $scope.selectedTodo = angular.copy(todo);
    }
    function getTodos() {
        //for (var i = 0; i < 10; i++) {
        //    var todo = {
        //        name: "test_" + i,
        //        id: i
        //    };
        //    $scope.todos.push(todo);
        //}
        services.getTodos().then(function (response) {
            var todos = response.data;
            console.log(todos);
            $scope.todos = todos;
            //alert('chiamata ajax asincrona');
        });
        //alert('sincrono');

    }

    function saveTodo() {
        var selectedTodo = $scope.selectedTodo;

        services.upsertTodo(selectedTodo).then(
            function (response) {
                if (response.data == true) {
                    alert("Aggiornamento eseguito con successo");
                    getTodos();
                } else {
                    alert('error dal backend');
                }
            },
            function () {
                alert('error generico');
            });
        //for (var i = 0; i < $scope.todos.length; i++) {
        //    if ($scope.todos[i].id === selectedTodo.id) {
        //        $scope.todos[i].name = selectedTodo.name;
        //    }
        //}
    }
    function deleteTodo(todo) {
        services.deleteTodo(todo).then(
            function (response) {
                if (response.data == true) {
                    alert("Eliminazione eseguita con successo");
                    getTodos();
                } else {
                    alert('error dal backend');
                }
            },
            function () {
                alert('error generico');
            });
        //for (var i = 0; i < $scope.todos.length; i++) {
        //    if ($scope.todos[i].id === todo.id) {
        //        $scope.todos.splice(i, 1);
        //    }
        //}
    }
}]);


