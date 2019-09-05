$('.input').focus(function () {
    $(this).parent().find(".label-txt").addClass('label-active');
});

$(".input").focusout(function () {
    if ($(this).val() == '') {
        $(this).parent().find(".label-txt").removeClass('label-active');
    };
});

function CompleateRegisterResult(result, status, xhr) {
    if (typeof result.result === undefined) return;
    if (result.result === true) window.location.replace("/");
    else $('#error').html(result.err_msg);
}

function CompleateLogInResult(result, status, xhr) {
    if (typeof result.result === undefined) return;
    if (result.result === true) window.location.replace("/");
    else $('#error').html(result.err_msg);
}