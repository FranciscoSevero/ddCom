
var myApp = angular.module('LoginApp', []);

myApp.controller('Controller', function ($scope, $http) {        
    $scope.message = null;
    $scope.ValidUser = function (user) {
        $scope.message = null;

        //user.name = 'ricardo.saraiva';
        //user.pwd = 'Plm7418520';

        if (user == undefined || user.name == '' || user.name == undefined || user.pwd == undefined || user.pwd == '') {
            $scope.message = 'Preencha o usuário e senha.';
            return;
        }
        
        $('#loading').modal('show');

        $http({
            method: 'POST',
            url: 'Index/ValidUser',
            data: { username: user.name, pwd: user.pwd }
        }).then(function successCallback(response) {
            var authenticated = response.data;
            if (authenticated == 'True') {                
                window.location.href = 'Alarme';
            }
            else {
                $scope.message = 'Usuário ou senha inválido.';
                $('#loading').modal('hide');
            }

        }, function errorCallback(response) {
            alert('Erro session name. Favor entrar em contato com a ddCom Systems');
        });
    }

    //window.location.href = 'Home';    

});
