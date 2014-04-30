$(document).ready(function () {
    $('#frmCaseInfo').bootstrapValidator({
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            CaseName: {
                validators: {
                    notEmpty: {
                        message: '名称不可以为空'
                    }
                }
            },
            CaseText: {
                validators: {
                    notEmpty: {
                        message: '案例的描述文字不可以为空'
                    }
                }
            }
        }
    });
    $("#frmCaseInfo").on("click", "button[data-act=savecase]", function () {
        $("#frmCaseInfo").bootstrapValidator('validate');
        if (!$("#frmCaseInfo").data('bootstrapValidator').isValid())
            return;
        $(this).button('loading');

        var dataCarrier = new Object();
        dataCarrier.caseText = $("#CaseText").val();
        dataCarrier.caseName = jQuery.trim($("#CaseName").val());
        dataCarrier.tchRoutineID = $("#hidTchRoutineID").val();
       
        $.ajax({
            type: "POST",
            url: "/Settings/Teaching1Setting/UpdateCase",
            data: JSON.stringify(dataCarrier),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                var saveObj = $("#frmCaseInfo button[data-act=savecase]");
                saveObj.button('reset');
                saveObj.popover({ content: "保存成功" });
                saveObj.popover('show');
                setTimeout(function () {
                    saveObj.popover('destroy');
                }, 1500);
            },
            error: function (ex) {

            }
        });
    });
})