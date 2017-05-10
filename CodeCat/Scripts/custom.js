$(document).ready(function () {
    console.log("fer inn i custom.js");
    $(function () {
        $('#btn-save').on('click', function () {

            var form = $(this);
            //console.log("form " + JSON.stringify(form));

            seen = [];

            console.log("hi from ajax");

            $.ajax({
                url: '/Document/Save',
                data: form.serialize(),
                method: 'POST',
                success: function (responseData) {

                    console.log("hi from ajax success");
                    console.log("hi" + responseData);
                }, error: function (responseData) {
                    console.log("hi from ajax error");
                    console.log(responseData);

                }
            });
            return false;

        });
    });
});