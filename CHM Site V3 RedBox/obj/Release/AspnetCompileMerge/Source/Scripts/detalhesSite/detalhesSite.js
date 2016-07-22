//http://stackoverflow.com/questions/24523367/slick-carousel-with-angular-js


var myapp = angular.module('detalhesSiteApp', []);

myapp.filter('duration', function () {
    //Returns duration from milliseconds in hh:mm:ss format.
    // Feito pelo ricardo
    /*return function (millseconds) {

        var seconds = Math.floor(millseconds / 1000);
        var h = 3600;
        var m = 60;
        var hours = Math.floor(seconds / h);
        var minutes = Math.floor((seconds % h) / m);
        var scnds = Math.floor((seconds % m));
        var timeString = '';
        if (scnds < 10) scnds = "0" + scnds;
        if (hours < 10) hours = "0" + hours;
        if (minutes < 10) minutes = "0" + minutes;
        timeString = hours + ":" + minutes + ":" + scnds;
        return timeString;
    }*/
    // Ajuste feito pelo Eduardo 21/07/2016
    return function (hours) {

        if (hours >= 8760) {
            return Math.floor(hours / 8760) + " ano(s)";
        }

        if (hours >= 730 && hours < 8760) {
            return Math.floor(hours / 730) + " mês(es)";
        }

        if (hours >= 168 && hours < 730) {
            return Math.floor(hours / 168) + " semana(s)";
        }

        if (hours >= 24 && hours < 128) {
            return Math.floor(hours / 24) + " dia(s)";
        }

        if (hours >= 1 && hours < 24) {
            return Math.floor(hours / 1) + " hora(s)";
        }
    }
});


myapp.controller('detalhesSiteController', function ($http, $scope, $filter) {    
    $http({
        method: 'POST',
        url: 'DetalhesSite/GetIdle'
    }).then(function successCallback(response) {
        var idle = response.data.model;
        $scope.model = response.data.model;

    }, function errorCallback(response) {
        alert(response.statusText);
    });

    $scope.confirmeChangeStatus = function (site, gravador, ramal) {
        $scope.context = {};
        $scope.context.site = site;
        $scope.context.gravador = gravador;
        $scope.context.canal = ramal;

        $('#modal-change-status').modal('show');
    }

    $scope.changeStatus = function (context) {
        var newstatus = $('#dropdownNewStatus').find(":selected").text();

        if (newstatus == '') {
            return;
        }

        context.status = newstatus;

        $http({
            method: 'POST',
            url: 'DetalhesSite/ChangeStatus',
            data: { context: JSON.stringify(context) }
        }).then(function successCallback(response) {
            if (response.data == 'True') {
                $('#alert-title').html('Sucesso!');
                $('#title-message').html('Ramal alterado com êxito.');
                $('#title-sub-message').html('Você será redirecionado para a página Alarme.');
                $('#modal-alert').modal('show');                
            }
        }, function errorCallback(response) {
            alert(response.statusText);
        });
    }
});