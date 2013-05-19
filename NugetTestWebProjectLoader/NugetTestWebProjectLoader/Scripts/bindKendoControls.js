var bindKendoControls = function (containerElement) {

    var container = $(containerElement);

    // Bind Kendo UI Tabs
    container.find('.tabs').kendoTabStrip({ animation: false });

    // Bind Kendo UI Date Pickers
    container.find('input[data-binding=kendoDatePicker]').kendoDatePicker();

    // Bind Kendo UI Date Pickers
    container.find('input[data-binding=kendoDateTimePicker]').kendoDateTimePicker();

    // Bind Kendo UI Numeric Textbox
    container.find('input[data-binding=kendoNumericTextBox]').each(function () {
        var input = $(this);
        input.kendoNumericTextBox(input.data("options"));
    });

    container.find('textarea[data-binding=kendoEditor]').each(function () {
        var input = $(this);
        input.kendoEditor({
                    encoded: false,    
                    tools: [
                        "bold",
                        "italic",
                        "underline"
                    ]
                });
    });

    //    container.find('input[data-binding=kendoNumericTextBox]').kendoNumericTextBox();


    // Bind Kendo UI DropDownLists
    container.find('input[data-binding=kendoComboBox]').each(function () {
        var target = $(this);

        if (target.data('kendoComboBox') === undefined) {
            target.attr("value", ""); // TODO: We don't really want to send down the value property with the EditorFor for dropdowns, this is a work around -WD
            
            var options = {
                dataTextField: target.data('textfield'),
                dataValueField: target.data('valuefield'),
                filter: "contains",
                placeholder: target.data('watermark'),
                delay: 200,
                dataBound: function() {
                    var selectedValue = target.attr("data-selected");

                    if (typeof selectedValue !== "undefined" && selectedValue != "") {
                        var comboBox = target.data("kendoComboBox");
                        
                        target.data('kendoComboBox').select(function(dataItem) { //dataItem is required for the eval on the next line, Don't remove.
                             return eval('dataItem.' + target.data('valuefield')) === selectedValue.toString();
                        });
                        comboBox.trigger("change");

                        //evaluateAllWatchers();
                    }
                },
                change: function () {
                    var comboBox = target.data("kendoComboBox");

                    if (typeof comboBox.dataItem() == "undefined") {
                        comboBox.value("");
                    }
                },
                requestEnd: function (e) {
                    //checkResponseForRedirect(e.response);
                }
            };

            var cascadeIds = target.data('cascadeid');

            if (typeof cascadeIds !== "undefined" && cascadeIds != "") {

                var enabled = options.enable = false;
                var cascadeIdList = cascadeIds.split(",");

                for (var i = 0; i < cascadeIdList.length; i++) {
                    var cascadeId = cascadeIdList[i];
                    var cascadeFrom = $("#" + cascadeId).data("kendoComboBox");

                    cascadeFrom.bind("change", function() {
                        var comboBox = target.data("kendoComboBox");

                        if (typeof cascadeFrom.dataItem() !== "undefined") {
                            comboBox.enable(enabled = true);
                            comboBox.dataSource.read();
                        } else {
                            comboBox.enable(enabled = false);
                        }

                        comboBox.value("");
                        //evaluateAllWatchers();
                    });

                }

                options.dataSource = new kendo.data.DataSource({
                    transport: {
                        read: target.data('endpoint'),
                        parameterMap: function () {

                            var cascadeparamList = target.data('cascadeparam').split(",");
                            var cascadeParams = "";

                            for (var i = 0; i < cascadeIdList.length; i++) {
                                cascadeParams += ' "' + cascadeparamList[i] + '": "' + $("#" + cascadeIdList[i]).data("kendoComboBox").value() + '" ';
                                if (i < cascadeIdList.length - 1) {
                                    cascadeParams += " , ";
                                }
                            }

                            var result = '{' + cascadeParams;
                            var params = buildParams(target.data('params'), target.data('containertype'));
                            result += params.length > 0 ? "," + params : "";
                            result += "}";
                            return jQuery.parseJSON(result);
                        }
                    },
                    requestStart: function(e) {
                        if (!enabled) {
                            e.preventDefault();
                        }
                    },
                    requestEnd: function(e) {
                        //checkResponseForRedirect(e.response);
                    },
                    error: function (error) {
                        var ex = error.xhr;
                        var messageText = "An error has occurred";
                        var detailText = null;
                        if (ex.status == 533) detailText = ex.responseText; // if the error came back from ProcessErrorsForAjaxResponse, attach the formatted message

                        if ($(".editorPopup").exists()) {
                            //displayFlyoutError(".editorPopup", messageText, detailText);
                        } else {
                            //displayFlyoutError("#main", messageText, detailText);
                        }
                    }
                });

            } else {
                options.dataSource = new kendo.data.DataSource({
                    transport: {
                        read: target.data('endpoint'),
                        parameterMap: function() {
                            var result = "{" + buildParams(target.data('params'), target.data('containertype')) + "}";
                            return jQuery.parseJSON(result);
                        }
                    },
                    requestEnd: function(e) {
                        //checkResponseForRedirect(e.response);
                    },
                    error: function (error) {
                        var ex = error.xhr;
                        var messageText = "An error has occurred";
                        var detailText = null;
                        if (ex.status == 533) detailText = ex.responseText; // if the error came back from ProcessErrorsForAjaxResponse, attach the formatted message

                        if ($(".editorPopup").exists()) {
                            //displayFlyoutError(".editorPopup", messageText, detailText);
                        } else {
                            //displayFlyoutError("#main", messageText, detailText);
                        }
                    }
                });
            }

            target.kendoComboBox(options);
            //After Binding the KendoComboBox wire up to the KeyDown event so the selected value attribute will be cleared when a user starts typing in the ComboBox
            $("input[name^=" + target.attr("id") + "]").keydown(function () {
                target.removeAttr("data-selected");
            });

          
        }
    });

    function buildParams(params, viewModel, selectedValue) {
        //viewModel = ;
        var result = "";
        var paramAry = params.split(',');

        for (var i = 0; i < paramAry.length; i++) {
            var param = paramAry[i];
            var alias = paramAry[i];

            // check to see if the property should be renamed to a new alias before submission
            if (param.indexOf(">>") != -1) {
                var sourceAndAlias = param.split(">>");
                param = sourceAndAlias[0];
                alias = sourceAndAlias[1];
            }

            if (param.indexOf("=") != -1) {
                var keyAndValue = param.split("=");// if the param is a custom value like foo=bar, just add it to the query string
                result += i > 0 && result.length > 0 ? "," : "";
                result += '"' + keyAndValue[0] + '": "' + keyAndValue[1] + '"';
            }
            else if (typeof $('#' + param).val() !== "undefined" && $('#' + param).val().length > 0) {
                result += i > 0 && result.length > 0 ? "," : "";
                result += '"' + alias.substring(alias.indexOf('_') + 1) + '": "' + $('#' + param).val() + '"';
            }
            else if (typeof $('#' + viewModel + "_" + param).val() !== "undefined") {
                result += i > 0 && result.length > 0 ? "," : "";
                if ($('#' + viewModel + "_" + param).val().length > 0) {
                    result += '"' + alias.substring(alias.indexOf('_') + 1) + '": "' + $('#' + viewModel + "_" + param).val() + '"';
                } else {
                    result += '"' + alias.substring(alias.indexOf('_') + 1) + '": "' + selectedValue + '"';
                }
            }
        }

        return result;
    }


    container.trigger('kendoControlsBound');
};