var myapp = angular.module('sharedApp', []);

myapp.controller('sharedController', function ($http, $scope) {
    var oi = '';
    $http({
        method: 'POST',
        url: 'Helper/GetSessionName'
    }).then(function successCallback(response) {
        if (response.status == 200) {
            $scope.username = response.data;
        }
        else {
            alert('Falha ao buscar ociosos.')
        }
    }, function errorCallback(response) {
        alert(response.statusText);
    });   
});

