$(document).ready(function () {
    if ($("#routineoverview").length > 0) {    
        $("#routineoverview .group[data-groupidx=" + $("#CurrGroup").val() + "]").addClass("currgroup");
        $("#routineoverview .arrowcontainer").css("height", $("#routineoverview .mainprocess").css("height"));
        var groupRelativePos = (Number($("#CurrGroup").val()) - 1) * 190;
        $("#routineoverview .arrowcontainer").css("background-position", "8px " + (groupRelativePos + 13) + "px");
        $("#routineoverview .currphase").css("top", (groupRelativePos == 0 ? 0 : (groupRelativePos - 20)) + "px");
        $("#routineoverview .group[data-node-id]").on("click", function() {
            window.location = "/Teachings/CommonNode/Guide/" + $(this).attr("data-node-id");
        })
    }
    navigationT1Mng.initEvent();
    if ($("#CurrGroup").length > 0)
        navigationT1Mng.checkStatus = 1;
    $("#routineoverview").on("click", "button[data-act=go]", function () {
        $("#navbar button[data-step=next]").click();
    })
    $("#fillerstepper").css("left", $(".maincont").offset().left);
    $("#fillerstepper").show();
});


var navigationT1Mng = {
    checkStatus: 0,
    navigationContext: null,

    initEvent: function () {
        $.ajax({
            type: "POST",
            url: "/Teachings/TeachingInit/GetNavigationContext",
            data: '{ "teachingRoutineID": "' + $("#TchRoutineID").val() + '", "teachingNodeID": "' + $("#TchNodeID").val() + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                //$("#navbar").children("span").remove();
                //$("#navbar").children().show();
                if (typeof (getUserContextCallBack) == "function") {
                    getUserContextCallBack();
                    $("#navbar").hide();
                    navigationT1Mng.checkStatus = 1;
                }
                navigationT1Mng.navigationContext = result;

                $("#navbar button[data-step=next]").bind("click", function () {
                    if (navigationT1Mng.checkStatus == 0)
                    {
                        $(this).popover({ title: '提示', content: '请先点击检查按钮', placement: 'top', container: 'body' });
                        $(this).popover('show');
                        $(".popover").css("zIndex", 10001);
                        setTimeout(function () {
                            $("#navbar button[data-step=next]").popover('destroy')
                        }, 1500);
                    }                        
                    else if (navigationT1Mng.checkStatus == -1) {
                        $(this).popover({ title: '提示', content: '尚有填写不正确的内容，请修正后再继续', placement: 'top', container: 'body' });
                        $(this).popover('show');
                        $(".popover").css("zIndex", 10001);
                        setTimeout(function () {
                            $("#navbar button[data-step=next]").popover('destroy')
                        }, 1500);
                    }
                    else {
                        if (navigationT1Mng.navigationContext.NextTchNodeID == -1) {
                            $('#pop_WaitingDiag .modal-body').html("本案例已结束，即将返回首页..");
                            $('#pop_WaitingDiag').modal('show');
                            setTimeout(function () {
                                window.location = "/Home/Index";
                            }, 1000);
                        }
                        else
                        {
                            $('#pop_WaitingDiag .modal-body').html("正在转到下一训练环节..");
                            $('#pop_WaitingDiag').modal('show');
                            setTimeout(function () {
                                window.location = "/Teachings/" + navigationT1Mng.navigationContext.NextTchNodeType + "/" + navigationT1Mng.navigationContext.NextTchNodeTag + "/" + navigationT1Mng.navigationContext.NextTchNodeID;
                            }, 500);
                        }
                            
                    }
                });
                $("#navbar button[data-step=prev]").bind("click", function () {
                    if (navigationT1Mng.navigationContext.PrevTchNodeID == -1) {
                        $(this).popover('show', { title: '提示', content: '这已经是本案例的第一步了', placement: 'top' });
                        setTimeout(function () {
                            $("#navbar button[data-step=prev]").popover('destroy')
                        }, 1000);
                    }                   
                });
                if (navigationT1Mng.navigationContext.IsTeacher == 0) {
                    $("a[data-step=auto]").remove();
                }
                if (window.location.href.indexOf("/Intro/") >= 0) {
                    $("a[data-step=auto]").remove();
                    $("a[data-step=check]").remove();
                    navigationT1Mng.checkStatus = 1;
                }
            }
        });

        $("input[data-operror]").bind("focus", function () {
            $("#responsearea").hide();
            if ($(this).parent().hasClass("incorrect")) {
                $("#responsearea .hinttext").html($(this).attr("data-operror"));
                $("#responsearea").fadeIn();
            }
        });

        $("button[data-step=check]").bind("click", function () {
            var isAllCorrect = true;
            $("input[data-correct]").each(function () {
                $(this).parent().removeClass("correct");
                $(this).parent().removeClass("incorrect");
                
                if ($(this).attr("data-correct") != jQuery.trim($(this).val())) {
                    $(this).parent().addClass("incorrect");
                    isAllCorrect = false;
                }
                else {
                    $(this).parent().addClass("correct");
                }               
            });
            $("#responsearea").hide();
            if (isAllCorrect) {
                navigationT1Mng.checkStatus = 1;
                $("#generalhint .text").html("<font color='green'>所有需要填写的内容都已通过检测，结果正确，请点击【下一步】继续</font>");
            }
            else {
                navigationT1Mng.checkStatus = -1;
                $("#responsearea .hinttext").html("<font color='red'>本练习中有未填写正确的内容，请逐一检查。</font>");
                $("#responsearea").fadeIn();
            }            

            $(".checkarea i").removeClass("glyphicon");
            $(".checkarea i").removeClass("glyphicon-ok");
            $(".checkarea i").removeClass("glyphicon-remove");
            $(".correct i").addClass("glyphicon glyphicon-ok");
            $(".incorrect i").addClass("glyphicon glyphicon-remove");
            $("#fillerstepper a").each(function () {               
                var allCorrect = true;
                var hasWordedOn = false;

                $("div[data-subject=" + $(this).attr("data-subject") + "]").find(".checkarea").each(function () {
                    if ($(this).hasClass("incorrect")) {
                        allCorrect = false;
                        hasWordedOn = true;
                    }
                    else if ($(this).hasClass("correct"))
                        hasWordedOn = true;
                });
                if ((hasWordedOn) && (allCorrect)) {
                    $(this).find(".glyphicon").removeClass("glyphicon-question-sign");
                    $(this).find(".glyphicon").addClass("glyphicon-ok");
                }
                else {
                    $(this).find(".glyphicon").addClass("glyphicon-question-sign");
                    $(this).find(".glyphicon").removeClass("glyphicon-ok");
                }
            });
        });

        $("button[data-step=auto]").bind("click", function () {
            $("input[data-correct]").each(function () {
                $(this).val($(this).attr("data-correct"));
            });
            $("a[data-step=check]").click();
        });
    }

}

