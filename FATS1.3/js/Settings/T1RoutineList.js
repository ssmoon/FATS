﻿$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/Settings/Teaching1Setting/LoadCase",
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            alert(result.length);
        }
    });
    caseSettingMgr.initTable();

    $(".currname button").click(function () {
        caseSettingMgr.reloadCaseTable();
    });
    
    $("#accordion").on("click", "a.list-group-item", function () {
        if ($(this).hasClass("active"))
            return;
        $("#casearea .currname .namelabel").html($(this).html());
        caseSettingMgr.tableData = { tmpRoutineID: $(this).attr("data-dbid") };
        caseSettingMgr.reloadCaseTable();
        $("#accordion a.list-group-item").removeClass("active");
        $(this).addClass("active");
    });
    $("#accordion a.list-group-item:eq(0)").click();

   
})


var caseSettingMgr = {
    caseTable: null,
    tableData: null,

    initTable: function () {
        caseSettingMgr.caseTable = $('#caselist').dataTable({
            "bSort": false,
            "bInfo": false,
            "bFilter": false,
            "bLengthChange": false,
            "bPaginate": false,
            "bProcessing": true,           
            "sAjaxSource": "/Settings/Teaching1Setting/LoadCase",
            "fnServerData": function (sSource, aoData, fnCallback) {
                aoData= caseSettingMgr.tableData,
                $.ajax( {
                    "dataType": 'json',
                    "type": "POST",
                    "url": sSource,
                    "data": aoData,
                    "success": fnCallback
                } )
            },
            "aoColumns": [
                { "sTitle": "案例名称", "mData": "CaseName" },
                {
                    "sTitle": "状态", "mData": "CurrStatus", "mRender": function (data, type, row) {
                        if (data > 0)
                            return "<span class='text-success'>可用</span>";
                        else return "<span class='text-danger'>不可用</span>";
                    }
                },
                {
                    "sTitle": "操作", "mData": "Row_ID", "mRender": function (data, type, row) {
                        return "<a href='javascript:void(0)' data-act='edit'>编辑</a>&nbsp;&nbsp;&nbsp;<a href='javascript:void(0)' data-act='del'>删除</a>";
                    }
                }
            ],
            "fnDrawCallback": function (oSettings) {            
                $("#caselist a[data-act=del]").confirm({
                    title: "删除确认",
                    text: "真的要删除这个案例吗？删除后将无法恢复?",
                    confirm: function (button) {
                        var aPos = caseSettingMgr.caseTable.fnGetPosition(button.closest('tr').get(0));
                        caseSettingMgr.caseTable.fnDeleteRow(aPos);
                    },
                    cancel: function (button) {
                       
                    },
                    confirmButton: "确定",
                    cancelButton: "取消"
                });
            }
        });
    },

    reloadCaseTable: function () {
        caseSettingMgr.caseTable.fnReloadAjax();
    }
}
