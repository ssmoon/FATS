$(document).ready(function () {    
    subjectFillerMng.initEvent();
    subjectFillerMng.initCtrls();
});

var subjectFillerMng = {
    initCtrls: function() {
        $("#navbar").hide();
        $("#subjectfiller .step[data-idx=1]").show();
        $("#subjectfiller :input[data-correct]").bind("focus", function () {
            $(this).removeClass("incorrect");
            $("#subjectfiller .errorarea").hide();
        });
    },

    initEvent: function() {
        $("#subjectnav").on("click", "button[data-step=help]", function() {
            $("#subjectfiller .helparea div").hide();
            $("#subjectfiller .helparea").show();
            $("#subjectfiller .helparea div[data-idx=" + $("#subjectfiller").attr("data-curr") + "]").slideDown();
        })
        $("#subjectnav").on("click", "button[data-step=auto]", function () {
            $("#subjectfiller .step").show();
            $("#subjectfiller :input[data-correct]").each(function () {
                $(this).val($(this).attr("data-correct"));
            });
            $("#subjectfiller .actarea").hide();
            $("#navbar a[data-step=check]").hide();
            $("#navbar a[data-step=auto]").hide();
            $("#subjectfiller .finalanswer").show();
            $("#navbar").show();
            navigationT1Mng.checkStatus = 1;
        })
        $("#subjectnav").on("click", "button[data-step=next]", function () {
            if ($("#subjectfiller").attr("data-curr") == "1") {
                var correctArr = new Array();
                var answerArr = new Array();
                $("#subjectfiller div[data-idx=1] input[data-correct]").each(function () {
                    correctArr.push($(this).attr("data-correct"));
                    answerArr.push(jQuery.trim($(this).val()));
                });
                if (correctArr.sort().join() != answerArr.sort().join()) {
                    $("#subjectfiller .errorarea").slideDown();
                    return;
                }
            }
            else {
                var allCorrect = true;
                $("#subjectfiller div[data-idx=" + $("#subjectfiller").attr("data-curr") + "] :input[data-correct]").each(function () {
                    $(this).removeClass("incorrect");
                    $(this).removeClass("correct");
                    if ($(this).attr("data-correct") != $(this).val()) {
                        allCorrect = false;
                        $(this).addClass("incorrect");
                    }
                    else $(this).addClass("correct");
                });
                if (!allCorrect) {
                    $("#subjectfiller .errorarea").slideDown();
                    return;
                }
            }
            var newSectionIdx = Number($("#subjectfiller").attr("data-curr")) + 1;
            $("#subjectfiller").attr("data-curr", newSectionIdx);
            $("#subjectfiller .errorarea").hide();
            $("#subjectfiller .helparea").hide();
            if (newSectionIdx == 7) {
                $("#subjectfiller .finalanswer").show();
            }
            if (newSectionIdx == 8) {
                $("#subjectfiller .actarea").hide();
                $("#navbar a[data-step=check]").hide();
                $("#navbar a[data-step=auto]").hide();
                $("#navbar").show();
                navigationT1Mng.checkStatus = 1;
            }
            $("#subjectfiller .step[data-idx=" + newSectionIdx + "]").slideDown();
        })       
    }
}

