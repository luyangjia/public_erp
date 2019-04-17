//全局参数
var  log=true // console.log()的方法是否输出，true输出，false 不输出，开发测试用
var pageSize = 15;
var pageList = [15, 20, 25, 30, 50, 100];
var loadMsg = "Loading......";
//$.cookie('the_cookie', null);   //通过传递null作为cookie的值即可
 //默认语言。 English/Chinese 
if ($.cookie('Language') == null) {
    //  $.cookie('Language') = "English";
    $.cookie('Language', 'English', { path: '/' });
}
//加载中英文
 
if ($.cookie('Language') == "Chinese")
{
    zh_cn(); 
}
else
{
    zh_en(); 
} 
//弹出信息窗口 title:标题 msgString:提示信息 msgType:信息类型 [error,info,question,warning]
function msgShow(title, msgString, msgType) {
    $.messager.alert(title, msgString, msgType);
}
//显示该显示中文还是英文
function $setLang(english, chinese) {
    if ($.cookie('Language') == "Chinese") {
        value = chinese;
    }
    else
    {
        value = english;
    }
    return value;

}
//英文转换成中文
function $lang(value) { 
    if ($.cookie('Language') == "Chinese")
    {
        value = $SetChinese[value];
    }
    return value;

}
 var $SetChinese = {
    //*******************公共**************************
    "Save": "保存",
    "Close": "关闭",
    "Add": "增加",
    "Edit": "修改",
    "Delete": "删除",
    "Success": "成功",
    "Failed": "失败",
    "Language": "语言",
    "System Info": "系统信息",
    "Refresh": "刷新",
    "English": "英文",
    "Chinese": "中文",
    "Welcome": "欢迎您",
    "Search": "查询",
    "Search Condition": "搜索条件",
    "Password Modified Successfully": "密码修改成功",
    "Basic Information": "基础信息",
    "The System Prompt": "系统提示",
    "The Operation Successful": "操作成功！",
    "The Operation Failure": "操作失败！",
    "Validation Failure": "验证失败！",
    "Are You Sure Delete Selected Data ?": "您确定要删除选中的数据吗？",
    "Please Selected Data": "请选择要操作的数据！",
    "You Can Only Selected One Data": "每次只能选择一条数据！", 
    //*******************公共 结束*********************
    
     //*******************首页**************************
    "Refresh": "刷新",
    "Close All": "全部关闭",
    "Close Other": "关闭其它",
    "Exit": "退出", 
    "Edit Password": "修改密码",
    "New Password": "新密码",
    "Confirm Password": "确认密码",
    "Click For Change Language": "点击切换语言",
    "Click For Change Password": "点击修改密码",
    "Click Exit": "点击退出",
    //*******************首页 结束*********************
};


 function zh_en() {
     if ($.fn.pagination) {
         $.fn.pagination.defaults.beforePageText = 'Page';
         $.fn.pagination.defaults.afterPageText = 'of {pages}';
         $.fn.pagination.defaults.displayMsg = 'Displaying {from} to {to} of {total} items';
     }
     if ($.fn.datagrid) {
         $.fn.datagrid.defaults.loadMsg = 'Processing, please wait ...';
     }
     if ($.fn.treegrid && $.fn.datagrid) {
         $.fn.treegrid.defaults.loadMsg = $.fn.datagrid.defaults.loadMsg;
     }
     if ($.messager) {
         $.messager.defaults.ok = 'Ok';
         $.messager.defaults.cancel = 'Cancel';
     }
     $.map(['validatebox', 'textbox', 'passwordbox', 'filebox', 'searchbox',
             'combo', 'combobox', 'combogrid', 'combotree',
             'datebox', 'datetimebox', 'numberbox',
             'spinner', 'numberspinner', 'timespinner', 'datetimespinner'], function (plugin) {
                 if ($.fn[plugin]) {
                     $.fn[plugin].defaults.missingMessage = 'This field is required.';
                 }
             });
     if ($.fn.validatebox) {
         $.fn.validatebox.defaults.rules.email.message = 'Please enter a valid email address.';
         $.fn.validatebox.defaults.rules.url.message = 'Please enter a valid URL.';
         $.fn.validatebox.defaults.rules.length.message = 'Please enter a value between {0} and {1}.';
         $.fn.validatebox.defaults.rules.remote.message = 'Please fix this field.';
     }
     if ($.fn.calendar) {
         $.fn.calendar.defaults.weeks = ['S', 'M', 'T', 'W', 'T', 'F', 'S'];
         $.fn.calendar.defaults.months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
     }
     if ($.fn.datebox) {
         $.fn.datebox.defaults.currentText = 'Today';
         $.fn.datebox.defaults.closeText = 'Close';
         $.fn.datebox.defaults.okText = 'Ok';
     }
     if ($.fn.datetimebox && $.fn.datebox) {
         $.extend($.fn.datetimebox.defaults, {
             currentText: $.fn.datebox.defaults.currentText,
             closeText: $.fn.datebox.defaults.closeText,
             okText: $.fn.datebox.defaults.okText
         });
     }

 }

function zh_cn()
{
    if ($.fn.pagination){
        $.fn.pagination.defaults.beforePageText = '第';
        $.fn.pagination.defaults.afterPageText = '共{pages}页';
        $.fn.pagination.defaults.displayMsg = '显示{from}到{to},共{total}记录';
    }
    if ($.fn.datagrid){
        $.fn.datagrid.defaults.loadMsg = '正在处理，请稍待。。。';
        $.fn.datagrid.defaults.beforePageText = '第';
        $.fn.datagrid.defaults.afterPageText = '页 共{pages}页';
        $.fn.datagrid.defaults.displayMsg = '显示{from}到{to},共{total}条记录';
    }
    if ($.fn.treegrid && $.fn.datagrid){
        $.fn.treegrid.defaults.loadMsg = $.fn.datagrid.defaults.loadMsg;
    }
    if ($.messager){
        $.messager.defaults.ok = '确定';
        $.messager.defaults.cancel = '取消';
    }
    $.map(['validatebox','textbox','passwordbox','filebox','searchbox',
            'combo','combobox','combogrid','combotree',
            'datebox','datetimebox','numberbox',
            'spinner','numberspinner','timespinner','datetimespinner'], function(plugin){
                if ($.fn[plugin]){
                    $.fn[plugin].defaults.missingMessage = '该输入项为必输项';
                }
            });
    if ($.fn.validatebox){
        $.fn.validatebox.defaults.rules.email.message = '请输入有效的电子邮件地址';
        $.fn.validatebox.defaults.rules.url.message = '请输入有效的URL地址';
        $.fn.validatebox.defaults.rules.length.message = '输入内容长度必须介于{0}和{1}之间';
        $.fn.validatebox.defaults.rules.remote.message = '请修正该字段';
    }
    if ($.fn.calendar){
        $.fn.calendar.defaults.weeks = ['日','一','二','三','四','五','六'];
        $.fn.calendar.defaults.months = ['一月','二月','三月','四月','五月','六月','七月','八月','九月','十月','十一月','十二月'];
    }
    if ($.fn.datebox){
        $.fn.datebox.defaults.currentText = '今天';
        $.fn.datebox.defaults.closeText = '关闭';
        $.fn.datebox.defaults.okText = '确定';
        $.fn.datebox.defaults.formatter = function(date){
            var y = date.getFullYear();
            var m = date.getMonth()+1;
            var d = date.getDate();
            return y+'-'+(m<10?('0'+m):m)+'-'+(d<10?('0'+d):d);
        };
        $.fn.datebox.defaults.parser = function(s){
            if (!s) return new Date();
            var ss = s.split('-');
            var y = parseInt(ss[0],10);
            var m = parseInt(ss[1],10);
            var d = parseInt(ss[2],10);
            if (!isNaN(y) && !isNaN(m) && !isNaN(d)){
                return new Date(y,m-1,d);
            } else {
                return new Date();
            }
        };
    }
    if ($.fn.datetimebox && $.fn.datebox){
        $.extend($.fn.datetimebox.defaults,{
            currentText: $.fn.datebox.defaults.currentText,
            closeText: $.fn.datebox.defaults.closeText,
            okText: $.fn.datebox.defaults.okText
        });
    }
    if ($.fn.datetimespinner) {
        $.fn.datetimespinner.defaults.selections = [[0, 4], [5, 7], [8, 10], [11, 13], [14, 16], [17, 19]];
    }

}

//json 日期格式转换 m/d/y
function jsonDateFormat(jsonDate) {//json日期格式转换为正常格式
    try {
        var date = new Date(parseInt(jsonDate.replace("/Date(", "").replace(")/", ""), 10));
        var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
        var day = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
        var hours = date.getHours();
        var minutes = date.getMinutes();
        var seconds = date.getSeconds();
        var milliseconds = date.getMilliseconds();
       // return date.getFullYear() + "-" + month + "-" + day;
        return month + "/" + day + "/"+date.getFullYear();
    } catch (ex) {
        return "";
    }
}

//json 日期格式转换 y-m-d h:m:s
function jsonDateTimeFormat(jsonDate) {//json日期格式转换为正常格式
    try {
        var date = new Date(parseInt(jsonDate.replace("/Date(", "").replace(")/", ""), 10));
        var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
        var day = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
        var hours = date.getHours();
        var minutes = date.getMinutes();
        var seconds = date.getSeconds();
        var milliseconds = date.getMilliseconds();
        // return date.getFullYear() + "-" + month + "-" + day + " " + hours + ":" + minutes;
        return month + "/" + day + "/" + date.getFullYear() + " " + hours + ":" + minutes;
    } catch (ex) {
        return "";
    }

}
function consolelog(value)
{
    if (log == true)
    {
        console.log(value);
    }
  
}
//右键菜单datagrid****************************
function onRowContextMenu(e, rowIndex, rowData) {
    //三个参数：e里面的内容很多，真心不明白，rowIndex就是当前点击时所在行的索引，rowData当前行的数据
    e.preventDefault(); //阻止浏览器捕获右键事件
    $(this).datagrid("clearSelections"); //取消所有选中项
    $(this).datagrid("selectRow", rowIndex); //根据索引选中该行
    $('#menu').menu('show', {
        //显示右键菜单
        left: e.pageX,//在鼠标点击处显示菜单
        top: e.pageY
    });
}
//右键菜单treegrid****************************
function onTreeContextMenu(e, rowObject) {
    if (rowObject) {
        e.preventDefault();
        $(this).treegrid('select', rowObject.Id);
        $('#menu').menu('show', {
            //显示右键菜单
            left: e.pageX,//在鼠标点击处显示菜单
            top: e.pageY
        });

    }
}
//将时间装换成日期格式
function DateFormat(value, row, index) {
    var str = "";
    if (value != null)
        str = jsonDateFormat(value);
    return str;
}
//Enable 装换成打钩和打×****************************
function Enableformater(value, rowObject, index) {
    var html = "<img src='../images/cross.png' />";
    if (value == true)
        html = "<img src='../images/ok.png' />";

    return html;
}
//重新加载
function Reload(id) { 
    $(id).datagrid("reload");
    $(id).datagrid("clearSelections");
   
}
//计算天数差的函数，通用  
function DateDiff(sDate1, sDate2) {    //sDate1和sDate2是MM/DD/YYYY格式  
    var aDate, oDate1, oDate2, iDays
    aDate = sDate1.split("/")
    oDate1 = new Date(aDate[2] + '-' + aDate[0] + '-' + aDate[1])    //转换为12-18-2002格式  
    aDate = sDate2.split("/")
    oDate2 = new Date(aDate[2] + '-' + aDate[0] + '-' + aDate[1])
    iDays = parseInt(Math.abs(oDate1 - oDate2) / 1000 / 60 / 60 / 24)    //把相差的毫秒数转换为天数  
    return iDays
}
//标准的操作 修改和删除，多是可操作，其它每个页面自定义，函数名称统一用：Operationformatter
function Operation_formatter(value, rowObject, index) {
    var html = "";
    var edit = "editIcon" + index;
    var edit_disabled = "edit_disabledIcon" + index;
    var del = "delIcon" + index;
    var del_disabled = "del_disabledIcon" + index;
     html = html + "<a href=\"javascript:void(0)\" class=\"editIcon\" title='" + $setLang("Edit", "修改") + "' onclick='EditData(\"" + value + "\"," + JSON.stringify(rowObject) + ")' ></a>";
     html = html + "┆";
     html = html + "<a href=\"javascript:void(0)\"  class=\"deleteIcon\"  title='" + $setLang("Delete", "删除") + "' onclick='DeleteData(\"" + value + "\"," + JSON.stringify(rowObject) + ")' ></a>";
    return html;
      
}
//不预先加载，突变就显示不出来
function onLoadSuccess(data) {
    $('.editIcon').linkbutton({  plain: true, iconCls: 'icon-edit' });
    $('.editdisabledIcon').linkbutton({  plain: true, iconCls: 'icon-edit_disabled' });
    $('.deleteIcon').linkbutton({ plain: true, iconCls: 'icon-delete' });
    $('.deletedisabledIcon').linkbutton({ plain: true, iconCls: 'icon-delete_disabled' });
    $('.undoIcon').linkbutton({ plain: true, iconCls: 'icon-undo' });
    $('.undodisabledIcon').linkbutton({ plain: true, iconCls: 'icon-undo_disabled' });
    $('.pluginIcon').linkbutton({ plain: true, iconCls: 'icon-plugin' });
    $('.viewIcon').linkbutton({ plain: true, iconCls: 'icon-view' });
    $('.pencilIcon').linkbutton({ plain: true, iconCls: 'icon-pencil' });
 
} 
 








