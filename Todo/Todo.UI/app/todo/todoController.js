todoApp.controller('todoController', function ($scope) {
    $scope.saluto = "";
    $scope.todos = [];
    $scope.selectedTodo = {};

    $scope.delete = deleteTodo;
    $scope.update = editTodo;
    $scope.save = saveTodo;
    getTodos();


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

        $scope.todos = serviceGetTodos();

        function serviceGetTodos() {
            return $http({
                method: 'GET',
                url: '' //url di chiamata
            });
        }
    }

    function saveTodo() {
        var selectedTodo = $scope.selectedTodo;
        for (var i = 0; i < $scope.todos.length; i++) {
            if ($scope.todos[i].id === selectedTodo.id) {
                $scope.todos[i].name = selectedTodo.name;
            }
        }
    }
    function deleteTodo(todo) {
        for (var i = 0; i < $scope.todos.length; i++) {
            if ($scope.todos[i].id === todo.id) {
                $scope.todos.splice(i, 1);
            }
        }
    }
});


