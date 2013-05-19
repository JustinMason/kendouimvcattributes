$(function () {

    var MVCKendoObservable = function (options) {
        var result = kendo.observable(options);
        return result;
    };
     
    var viewModel = kendo.observable({
        
        comboBoxValue: null,
        displayComboBoxValue: function() {
            var comboBoxValue = this.get("comboBoxValue");
            return kendo.stringify(comboBoxValue);
    }});


    kendo.bind($(".kendoBound"), viewModel);

});
