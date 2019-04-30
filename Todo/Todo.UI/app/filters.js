todoApp.filter('truncateFriendly', function () {
    return function (text,maxLength) {

        if (text.length > maxLength) {
            return text.substring(0, maxLength) + "...";
        }

        return text;
    };
});

