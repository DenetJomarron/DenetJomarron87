jQuery.noConflict();
(function ($, undefined) {
    $(document).ready(function () {

      $('#InformationButton').on('click', function (e) {
       //   $("#InformationButton").click(function () {
         
       
            var elem = $(e.currentTarget);
            var URL = elem.attr("href").trim();

            $.ajax({


                url: URL,
                type: 'get',
                contentType: '',
                data: '',
                success: (function (result) {

                    elem.body.html(result);
                    App.attachBehaviors();
                }),
                error: function (xhr, status) {
                    alert(status);
                }
            });
            return false;

      


        });


    });
})(jQuery);
