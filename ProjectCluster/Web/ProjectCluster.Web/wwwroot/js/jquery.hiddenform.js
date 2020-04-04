$(document).ready(function () {
    $("select").change(function () {
        $('.optional').css('display', 'none');
        $("select option:selected").each(function () {
            if ($(this).val() == "InProgress") {
                $('.inprogress').css('display', 'block');
            }
        });
    });
});