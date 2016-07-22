//http://stackoverflow.com/questions/24523367/slick-carousel-with-angular-js


var myapp = angular.module('detalhesPlataformaApp', []);


myapp.controller('detalhesPlataformaCtrl', function ($http, $scope) {
    $scope.getRecorder = function (value) {
        $scope.form_cad_recorder = false;
        $scope.recordersCadastrados = {};
        $scope.recordersDisponiveis = {};        

        $('#loading').modal('show');

        $http({
            method: 'POST',
            url: 'DetalhesPlataforma/FindRecorders',
            data: { versao: value }
        }).then(function successCallback(response) {           
            $("#select2-chosen-1").text("Selecione...");
            $('#loading').modal('hide');

            var hasErrorCadastrados = response.data.recordersCadastrados[0];
            var hasErrorDisponiveis = response.data.recordersDisponiveis[0];

            var lenCadastrados = response.data.recordersCadastrados.length;
            var lenDisponiveis = response.data.recordersDisponiveis.length;

            if (hasErrorCadastrados == -1)
                UIToastr.init('error', 'Aviso!', 'Ocorreu uma falha ao tentar conectar na base do Channel Monitor.', 'toast-top-right');
            else if (lenCadastrados == 0)
                UIToastr.init('warning', 'Aviso!', 'Não há gravador cadastrado para esta plataforma.', 'toast-top-right');

            if (hasErrorDisponiveis == -1)
                UIToastr.init('error', 'Aviso!', 'Ocorreu uma falha ao tentar conectar na base desta versão.', 'toast-top-right');
            else if (hasErrorDisponiveis == -2)
                UIToastr.init('error', 'Aviso!', 'Ocorreu uma falha ao executar busca na base. Entre em contato com a ddCom Systems.', 'toast-top-right');
            else if (lenDisponiveis == 0)
                UIToastr.init('warning', 'Aviso!', 'Não há gravador disponível para cadastro para esta versão.', 'toast-top-right');

            if (response.status == 200) {
                $scope.plataforma = response.data.plataforma;
                if (hasErrorCadastrados != -1)
                    $scope.recordersCadastrados = response.data.recordersCadastrados;
                if (hasErrorDisponiveis != -1 && hasErrorDisponiveis != -2)
                    $scope.recordersDisponiveis = response.data.recordersDisponiveis;
                else {
                    $('select[name^="recordersDisp"] option[value="Selecione..."]').attr("selected", "selected");
                }
            }
           
        }, function errorCallback(response) {
            $('#loading').modal('hide');
            alert(response.statusText);
        });
    }

    $scope.recorderCadastro = function (teste) {
        var serial = $("#recordersDisp option:selected").text();
        var value = $("#radio-form input[type='radio']:checked").val();        

        if (serial != '') {
            $scope.recorder = {};
            $scope.versaoRecorder = value;
            $scope.form_cad_recorder = true;
            $scope.serialrec = serial;
        }
        else            
            $scope.form_cad_recorder = false;
    }

    $scope.RemovePlataforma = function (plataforma, action) {
        $scope.plataformaToRemove = plataforma;
        $('#confirm-remove-plataforma').modal('show');

        if (action == 'remove') {
            $http({
                method: 'POST',
                url: 'DetalhesPlataforma/RemovePlataforma',
                data: { plataforma: plataforma }
            }).then(function successCallback(response) {
                if (response.data == 'True') {
                    window.location.href = 'Sites'
                }
            }, function errorCallback(response) {
                alert(response.statusText);
            });
        }
    }
});