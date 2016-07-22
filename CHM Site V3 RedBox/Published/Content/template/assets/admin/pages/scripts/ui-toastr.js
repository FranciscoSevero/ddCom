var UIToastr = function () {

    return {
        //main function to initiate the module
        init: function (_type, _title, _msg, _position) {
                var shortCutFunction = _type; 
                var msg = _msg; 
                var title = _title 
                var $showDuration = 1000;
                var $hideDuration = 1000;
                var $timeOut = 5000 
                var $extendedTimeOut = 1000; 
                var $showEasing = 'swing';
                var $hideEasing = 'linear';
                var $showMethod = 'fadeIn';
                var $hideMethod = 'fadeOut';                

                toastr.options = {
                    "closeButton": true,
                    "debug": false,
                    "positionClass": _position, 
                    "onclick": null,
                    "showDuration": $showDuration,
                    "hideDuration": $hideDuration,
                    "timeOut": $timeOut,
                    "extendedTimeOut": $extendedTimeOut,
                    "showEasing": $showEasing,
                    "hideEasing": $hideEasing,
                    "showMethod": $showMethod,
                    "hideMethod": $hideMethod
                }                

                var $toast = toastr[shortCutFunction](msg, title); // Wire up an event handler to a button in the toast, if it exists
                $toastlast = $toast;                                       
        }

    };

}();