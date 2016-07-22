var myapp = angular.module('alarmesApp', []);

myapp.directive('pulse', function () {
    return {
        link: function ($scope) {
            // Wait for templates to render
            $scope.$evalAsync(function () {
                // Finally, directives are evaluated
                // and templates are renderer here                    
                $('.pulse').pulsate({ color: "#cc0000", speed: 600, reach: 15, glow: true });
            });
        },
    };
});

myapp.controller('alarmesController', function ($http, $scope) {
    $('#loading').modal('show');

    $http({
        method: 'POST',
        url: 'Alarme/TestConnection'
    }).then(function successCallback(response) {
        if (response.data == 'True') {            
            $('#loading').modal('hide');

            $http({
                method: 'POST',
                url: 'Alarme/GetIdle'
            }).then(function successCallback(response) {
                var error = response.data.error;
                if (error == 0) {
                    $scope.models = response.data.models;
                }
                else {
                    alert(response.data.message)
                }
            }, function errorCallback(response) {
                alert(response.statusText);
            });
        }
        else {
            $('#loading').modal('hide');
            $('#modal-error').modal('show');
        }
    }, function errorCallback(response) {
        alert(response.statusText);
    });                
    $scope.detailsAlarme = function (model) {
        $http({
            method: 'POST',
            url: 'Alarme/SendIdle',
            data: { site: model }
        }).then(function successCallback(response) {
            if (response.status == 200) {
                window.location.href = 'DetalhesSite'
            }
        }, function errorCallback(response) {
            alert(response.statusText);
        });
    }
});

