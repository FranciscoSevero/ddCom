//http://stackoverflow.com/questions/24523367/slick-carousel-with-angular-js


var myapp = angular.module('sitesApp', []);

myapp.controller('sitesController', function ($http, $scope) {
    
    $scope.GetSites = function () {
        var oi = '';
        $http({
            method: 'POST',
            url: 'Sites/GetSites'
        }).then(function successCallback(response) {            
            $scope.sites = response.data.sites;

        }, function errorCallback(response) {
            alert(response.statusText);
        });
    }

    $scope.DetalhesPlataforma = function (model) {
        var i = model;
        $http({
            method: 'POST',
            url: 'Sites/SendPlataforma',
            data: { plataforma: model }
        }).then(function successCallback(response) {            
            if (response.status == 200) {
                window.location.href = 'DetalhesPlataforma';
            }

        }, function errorCallback(response) {
            alert(response.statusText);
        });
    }

    $scope.CadastrarSite = function (model) {
        if (model.nome_site == '')
            return;

        $http({
            method: 'POST',
            url: 'Sites/SaveSite',
            data: { site: model }
        }).then(function successCallback(response) {
            if (response.data == 'True') {
                window.location.reload(true);
            }
            else {
                alert('Falha ao salvar site, talvez não foi possível conectar na base');
            }
        }, function errorCallback(response) {
            alert(response.statusText);
        });
    }

    $scope.RemoveSite = function (model, action) {
        $scope.siteToRemove = model;
        $('#confirm-remove-site').modal('show');

        if (action == 'remove') {
            $http({
                method: 'POST',
                url: 'Sites/RemoveSite',
                data: { site: model }
            }).then(function successCallback(response) {
                if (response.data == 'True') {
                    window.location.reload(true);
                }
            }, function errorCallback(response) {
                alert(response.statusText);
            });
        }
    }

    $scope.CadastroPlataforma = function (site) {
        $http({
            method: 'POST',
            url: 'Plataforma/SendSite',
            data: { site: site }
        }).then(function successCallback(response) {
            if (response.status == 200)
                window.location.href = 'Plataforma';

        }, function errorCallback(response) {
            alert(response.statusText);
        });
    }
});