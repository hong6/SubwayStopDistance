$(function () {
    $('form').submit(function (e) {
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (html) {
                $('body').empty().html(html);
            }
        });
        e.preventDefault();
    });
});