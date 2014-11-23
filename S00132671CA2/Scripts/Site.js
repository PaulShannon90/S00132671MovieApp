$(function () {


    var ajaxFormSubmit = function () {

        var form = $(this);
        var options = {
            url: form.attr("action"),
            type: form.attr("method"),
            data: form.serialize()
        };
    

    $.ajax(options).done(function (data) {
        var target = $(form.attr("data-myscripts-target"));
        target.replaceWith(data);
        var newHtml = $(data);
        target.replaceWith(newHtml);
        newHtml.effect("highlight");
    });

    return false;

    };

    
    var createAutocomplete = function () {
        var input = $(this);

        var options = {
            source: input.attr("data-myscripts-autocomplete")
          

        };

        input.autocomplete(options);
    };

    var getPage = function () {
        var $a = $(this);
        var options =
            {
                url: $a.attr("href"),
                type: "get"
            };

        $.ajax(options).done(function (data) {
            var target = $a.parents("div.pagedList").attr("data-myscripts-target");
            $(target).replaceWith(data);
        });
        return false;
    };


    $("form[data-myscripts-ajax='true']").submit(ajaxFormSubmit);
    $("input[data-myscripts-autocomplete]").each(createAutocomplete);

    $(".main-content").on("click", ".pagedList a", getPage);
});