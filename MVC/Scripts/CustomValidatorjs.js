/// <reference path="jquery.validate.unobtrusive.min.js" />

var validate = function () {
    function validateCheckbox(elementName, errorMessage) {
        var newclass = 'required_' + elementName;
        var defaultErrorMessage = 'The checkbox selection is empty';

        var elements = document.getElementsByName(elementName);
        $(elements).addClass(newclass);

        jQuery.validator.addMethod('required_group', function (value, element) {
            var $module = $(element).parents('form');
            return $module.find("input['newclass']:checked").length;
        }, errorMessage || defaultErrorMessage);

        jQuery.validator.addClassRules(newclass, { 'required_group': true });
    }

    return {
        checkbox: validateCheckbox
    }
}();