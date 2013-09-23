/// easyUI  时间改写
Date.prototype.format = function (format) {
    var o = {
        "M+": this.getMonth() + 1, //month
        "d+": this.getDate(), //day
        "h+": this.getHours(), //hour
        "m+": this.getMinutes(), //minute
        "s+": this.getSeconds(), //second
        "q+": Math.floor((this.getMonth() + 3) / 3), //quarter
        "S": this.getMilliseconds() //millisecond
    }
    if (/(y+)/.test(format)) format = format.replace(RegExp.$1,
    (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o) if (new RegExp("(" + k + ")").test(format))
        format = format.replace(RegExp.$1,
        RegExp.$1.length == 1 ? o[k] :
        ("00" + o[k]).substr(("" + o[k]).length));
    return format;
}
function getDate(value) {
    var date = new Date(parseInt(value.replace("/Date(", "").replace(")/", ""), 10));
    return date.format("yyyy-MM-dd hh:mm:ss");
}

function getOnlyDate(value) {
    var date = new Date(parseInt(value.replace("/Date(", "").replace(")/", ""), 10));
    return date.format("yyyy-MM-dd");
}
function getStartDateTime(value, t) {
    var today = new Date();
    var enddate;
    if (t == "d")
        enddate = getDate(today.setDate(today.getDate() - value).toString());
    else {
        enddate = getDate(today.setHours(today.getHours() - value).toString());
    }
    return enddate;
}

function getStartDate(value) {
    var today = new Date();
    var enddate = getOnlyDate(today.setDate(today.getDate() - value).toString());
    return enddate;
}


function getTrue(value) {
    if (value == 1)
        return "是";
    else
        return "否";
}

function ajaxFrom(form, url) {
   
    $.ajax({
        url: url,
        type: "Post",
        data: $("#"+form).serialize(),
        dataType: "json",
        success: function (data) {
            if(data.IsSuccess){
                alert(1);
            }
            alert(2);
        }
    });
}

//获取选中行
function getselectedRow() {
    var row = $('#dg').datagrid('getSelected');
    if (row != undefined) {
        if (row.hasOwnProperty('Id')) {
            var id = row['Id'];
            return id;
        }
    }
    $.messager.alert('操作提示', '请选择数据!', 'warning');
    return (undefined);
}

//删除的按钮
function del(grid, url) {
    var rows = $('#' + grid).datagrid('getSelections');
    if (rows.length == 0) {
        $.messager.alert('操作提示', '请选择数据!', 'warning');
        return false;
    }
    var arr = [];
    for (var i = 0; i < rows.length; i++) {
        arr.push(rows[i].Id);
    }

    $.messager.confirm('操作提示', "确认删除这 " + arr.length + " 项吗？", function (r) {
        if (r) {
            $.post(url, { query: arr.join(",") }, function (res) {
                if (res == "OK") {
                    //移除删除的数据
                    $.messager.alert('操作提示', '删除成功!', 'info');
                    $("#flexigridData").datagrid("reload");
                    $("#flexigridData").datagrid("clearSelections");
                }
                else {
                    if (res == "") {
                        $.messager.alert('操作提示', '删除失败!请查看该数据与其他模块下的信息的关联，或联系管理员。', 'info');
                    }
                    else {
                        $.messager.alert('操作提示', res, 'info');
                    }
                }
            });
        }
    });
};


//跳出弹窗
function showdlg(url, dlg, handle) {
    $('#' + dlg).load(url, function () {
        $(this).dialog({
            title: '新建',
            modal: true,
            rownumbers: true,
            loadingMessage: '正在加载...',
            buttons: [{
                text: '提交',
                iconCls: 'icon-ok',
                handler: handle
            }, {
                text: '取消',
                handler: function () {
                    $('#' + dlg).dialog('close');
                }
            }]
        });
    }).dialog('open');
}