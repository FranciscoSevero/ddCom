var UIIdleTimeout = function () {

    return {

        //main function to initiate the module
        init: function (timeout) {

            // cache a reference to the countdown element so we don't have to query the DOM for it on each ping.
            var $countdown;

            var modal =
                '<div class="modal fade" id="idle-timeout-dialog" data-backdrop="static">' +
                        '<div class="modal-content">' +
                            '<div class="modal-header">' +
                                '<h4 class="modal-title">Atualização da página.</h4>' +
                            '</div>' +
                                '<div class="modal-body">' +
                                    '<p><i class="fa fa-warning"></i> A página irá atualizar em <span id="idle-timeout-counter"></span> segundos.</p>' +
                                    '<p>Deseja atualizar?</p>' +
                            '</div>' +
                            '<div class="modal-footer">' +
                                '<button id="idle-timeout-dialog-logout" type="button" class="btn btn-default">Sim, atualizar agora.</button>' +
                                '<button id="idle-timeout-dialog-keepalive" type="button" class="btn btn-primary" data-dismiss="modal">Não, cancelar atualização.</button>' +
                            '</div>' +
                    '</div>' +
                '</div>'

            $('body').append(modal);

            // start the idle timer plugin
            $.idleTimeout('#idle-timeout-dialog', '.modal-content button:last', {
                idleAfter: timeout, // app config
                timeout: 15000, //15 seconds to timeout                
                pollingInterval: 5, // 5 seconds
                //keepAliveURL: 'demo/idletimeout_keepalive.php',                
                serverResponseEquals: 'OK',
                onTimeout: function () {
                    var left = ($(window).width() / 2) - (900 / 2);
                    var top = ($(window).height() / 2) - (600 / 2);
                    window.location.href='Alarme'
                },
                onIdle: function () {
                    $('#idle-timeout-dialog').modal('show');
                    $countdown = $('#idle-timeout-counter');

                    $('#idle-timeout-dialog-keepalive').on('click', function () {
                        $('#idle-timeout-dialog').modal('hide');
                    });

                    $('#idle-timeout-dialog-logout').on('click', function () {
                        $('#idle-timeout-dialog').modal('hide');
                        $.idleTimeout.options.onTimeout.call(this);
                    });
                },
                onCountdown: function (counter) {
                    $countdown.html(counter); // update the counter
                }
            });

        }

    };

}();