
var FormWizardPlataforma = function () {    
    return {
        //main function to initiate the module
        init: function () {                        
            if (!jQuery().bootstrapWizard) {
                return;
            }

            function format(state) {
                if (!state.id) return state.text; // optgroup
                return "<img class='flag' src='../../assets/global/img/flags/" + state.id.toLowerCase() + ".png'/>&nbsp;&nbsp;" + state.text;
            }

            //$("#country_list").select2({
            //    placeholder: "Select",
            //    allowClear: true,
            //    formatResult: format,
            //    formatSelection: format,
            //    escapeMarkup: function (m) {
            //        return m;
            //    }
            //});

            var form = $('#submit_form_plataforma');
            var error = $('.alert-danger', form);
            var success = $('.alert-success', form);

            form.validate({
                doNotHideMessage: true, //this option enables to show the error/success messages on tab switch.
                errorElement: 'span', //default input error message container
                errorClass: 'help-block help-block-error', // default input error message class
                focusInvalid: false, // do not focus the last invalid input
                rules: {
                    //cadastro plataforma
                    nomePlataforma: {
                        minlength: 2,
                        maxlength: 20,
                        required: true
                    },
                    instanciaSql: {
                        minlength: 2,
                        maxlength: 50,
                        required: true
                    },
                    usuarioSql: {
                        minlength: 2,
                        maxlength: 50,
                        required: true
                    },
                    senhaSql: {
                        required: true
                    },                   
                    ociosidade: {
                        minlength: 1,
                        maxlength: 2,
                        required: true
                    }
                },

                messages: { // custom messages for radio buttons and checkboxes
                    'payment[]': {
                        required: "Please select at least one option",
                        minlength: jQuery.validator.format("Please select at least one option")
                    }
                },

                errorPlacement: function (error, element) { // render error placement for each input type
                    if (element.attr("name") == "gender") { // for uniform radio buttons, insert the after the given container
                        error.insertAfter("#form_gender_error");
                    } else if (element.attr("name") == "payment[]") { // for uniform checkboxes, insert the after the given container
                        error.insertAfter("#form_payment_error");
                    } else {
                        error.insertAfter(element); // for other inputs, just perform default behavior
                    }
                },

                invalidHandler: function (event, validator) { //display error alert on form submit   
                    success.hide();
                    error.show();
                    Metronic.scrollTo(error, -200);
                },

                highlight: function (element) { // hightlight error inputs
                    $(element)
                        .closest('.form-group').removeClass('has-success').addClass('has-error'); // set error class to the control group
                },

                unhighlight: function (element) { // revert the change done by hightlight
                    $(element)
                        .closest('.form-group').removeClass('has-error'); // set error class to the control group
                },

                success: function (label) {
                    if (label.attr("for") == "gender" || label.attr("for") == "payment[]") { // for checkboxes and radio buttons, no need to show OK icon
                        label
                            .closest('.form-group').removeClass('has-error').addClass('has-success');
                        label.remove(); // remove error label here
                    } else { // display success icon for other inputs
                        label
                            .addClass('valid') // mark the current input as valid and display OK icon
                        .closest('.form-group').removeClass('has-error').addClass('has-success'); // set success class to the control group
                    }
                },

                submitHandler: function (form) {
                    success.show();
                    error.hide();
                    //add here some ajax code to submit your form or just call form.submit() if you want to submit the form without ajax
                }

            });

            var displayConfirm = function () {
                var i = 0;
                $('#tab2 .form-control-static', form).each(function () {
                    var input = $('[name="' + $(this).attr("data-display") + '"]', form);
                    if (input.is(":radio")) {
                        input = $('[name="' + $(this).attr("data-display") + '"]:checked', form);
                    }
                    if (input.is(":text") || input.is("textarea")) {
                        $(this).html(input.val());
                    }
                    if (input[0].name == 'ociosidade') {
                        $(this).html(input[0].value + ' hora(s).');
                    } else if (input.is("select")) {
                        $(this).html(input.find('option:selected').text());
                    } else if (input.is(":radio") && input.is(":checked")) {
                        $(this).html(input.attr("data-title"));
                    } else if ($(this).attr("data-display") == 'payment[]') {
                        var payment = [];
                        $('[name="payment[]"]:checked', form).each(function () {
                            payment.push($(this).attr('data-title'));
                        });
                        $(this).html(payment.join("<br>"));
                    }
                    i++;
                });
            }

            var handleTitle = function (tab, navigation, index) {
                var total = navigation.find('li').length;
                var current = index + 1;
                // set wizard title
                //$('.step-title', $('#form_wizard_plataforma')).text('Step ' + (index + 1) + ' of ' + total);
                $('.step-title', $('#form_wizard_plataforma')).text('' + (index + 1) + ' de ' + total);
                // set done steps
                jQuery('li', $('#form_wizard_plataforma')).removeClass("done");
                var li_list = navigation.find('li');
                for (var i = 0; i < index; i++) {
                    jQuery(li_list[i]).addClass("done");
                }

                if (current == 1) {
                    $('#form_wizard_plataforma').find('.button-previous').hide();
                } else {
                    $('#form_wizard_plataforma').find('.button-previous').show();
                }

                if (current >= total) {
                    $('#form_wizard_plataforma').find('.button-next').hide();
                    $('#form_wizard_plataforma').find('.button-submit').show();
                    displayConfirm();
                } else {
                    $('#form_wizard_plataforma').find('.button-next').show();
                    $('#form_wizard_plataforma').find('.button-submit').hide();
                }
                Metronic.scrollTo($('.page-title'));
            }

            // default form wizard
            $('#form_wizard_plataforma').bootstrapWizard({
                'nextSelector': '.button-next',
                'previousSelector': '.button-previous',
                onTabClick: function (tab, navigation, index, clickedIndex) {
                    return false;
                    /*
                    success.hide();
                    error.hide();
                    if (form.valid() == false) {
                        return false;
                    }
                    handleTitle(tab, navigation, clickedIndex);
                    */
                },
                onNext: function (tab, navigation, index) {
                    success.hide();
                    error.hide();

                    if (form.valid() == false) {
                        return false;
                    }

                    handleTitle(tab, navigation, index);
                },
                onPrevious: function (tab, navigation, index) {
                    success.hide();
                    error.hide();

                    handleTitle(tab, navigation, index);
                },
                onTabShow: function (tab, navigation, index) {
                    var total = navigation.find('li').length;
                    var current = index + 1;
                    var $percent = (current / total) * 100;
                    $('#form_wizard_plataforma').find('.progress-bar').css({
                        width: $percent + '%'
                    });
                }
            });

            $('#form_wizard_plataforma').find('.button-previous').hide();
            $('#form_wizard_plataforma .button-submit').click(function () {

                var instanciaSql;
                var nome_plataforma;
                var usuario;
                var senha;                
                var ociosidade;

                $('#tab2 .form-control-static', form).each(function () {
                    var input = $('[name="' + $(this).attr("data-display") + '"]', form);

                    if (input[0].name == 'nomePlataforma')
                        nome_plataforma = input[0].value
                    else if (input[0].name == 'instanciaSql')
                        instanciaSql = input[0].value
                    else if (input[0].name == 'usuarioSql')
                        usuario = input[0].value;
                    else if (input[0].name == 'senhaSql')
                        senha = $('#senhaSql').val(); //input[0].value;                    
                    else if (input[0].name == 'ociosidade')
                        ociosidade = input[0].value;

                });

                var _plataforma = {
                    id_site: 1,
                    id_plataforma: 0,                    
                    plataforma: nome_plataforma,
                    instanciaSql: instanciaSql,
                    usuarioSql: usuario,
                    senhaSql: senha,
                    ociosidade: parseInt(ociosidade),
                    cadastro: new Date()
                }

                $.post("Plataforma/SavePlataforma", { plataforma: JSON.stringify(_plataforma) }, function (resp) {
                    if (resp == 'True') {
                        $('#alert-title').html('Sucesso!');
                        $('#title-message').html('Plataforma cadastrada com êxito.');
                        $('#title-sub-message').html('Você será redirecionado para a página Sites.');
                        $('#modal-alert').modal('show');
                    }
                });

            }).hide();

            $('#btnValidaConn').click(function () {
                var instancia = $('#instanciaSql').val();
                var usuario = $('#usuarioSql').val();
                var senha = $('#senhaSql').val();                

                $.get("Plataforma/TestConnectionPlataforma", { instanciaSql: instancia, usuarioSql: usuario, senhaSql: senha }, function (resp) {
                    if (resp == 'True') {
                        UIToastr.init('success', 'Sucesso!', 'Conexão realizada com êxito!', 'toast-top-right');
                    }
                    else {
                        UIToastr.init('error', 'Falha!', 'Não foi possível realizar a conexão com dos dados informados.', 'toast-top-right');
                    }
                });
            });
        }

    };
}();