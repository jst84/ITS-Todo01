todoApp.factory("dbServices", function ($http) {
    return {
        getTodos: getPrivateTodos
    };
    function getPrivateTodos() {
        return $http({
            method: 'GET',
            url: 'http://localhost:54345/api/todo/getall'
        });
    }
});


todoApp.factory("mockServices", function ($http) {
    return {
        getTodos: getPrivateTodos
    };
    function getPrivateTodos() {

        var todos = [];
        for (var i = 0; i < 10; i++) {
            var todo = {
                name: "test_" + i,
                id: i
            };
           todos.push(todo);
        }

        return todos;


    }
});