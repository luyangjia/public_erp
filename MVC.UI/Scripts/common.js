var onlyOpenTitle = "Home";//不允许关闭的标签的标题
$(function () {
    tabClose();
    tabCloseEven();
})

function tabClose() {
    /*双击关闭TAB选项卡*/
    $(".tabs-inner").dblclick(function () {
        var subtitle = $(this).children(".tabs-closable").text();
        $('#tabs').tabs('close', subtitle);
    })
    /*为选项卡绑定右键*/
    $(".tabs-inner").bind('contextmenu', function (e) {
        $('#mm').menu('show', {
            left: e.pageX,
            top: e.pageY
        });
        var subtitle = $(this).children(".tabs-closable").text();
        $('#mm').data("currtab", subtitle);
        $('#tabs').tabs('select', subtitle);
        return false;
    });
}
//绑定右键菜单事件
function tabCloseEven() {
    $('#mm').menu({
        onClick: function (item) {
            closeTab(item.id);
        }
    });
    return false;
}

//创建/移除tab
var index = 0;
function addTab(subtitle, url, icon) {
    index++;
    if (!$('#tabs').tabs('exists', subtitle)) {
        $('#tabs').tabs('add', {
            title: subtitle,
            content: createFrame(url),
            closable: true,
            icon: icon
        });
    } else {
        $('#tabs').tabs('select', subtitle);
        $('#mm-tabupdate').click();
    }
    tabClose();
}
function removeTab() {
    var tab = $('#tabs').tabs('getSelected');
    if (tab) {
        var index = $('#tabs').tabs('getTabIndex', tab);
        $('#tabs').tabs('close', index);
    }
}
//创建Frame
function createFrame(url) {
    var s = '<iframe scrolling="no" frameborder="0"  src="' + url + '" style="width:100%;height:99%;"></iframe>';
    return s;
}

//关闭tab
function closeTab(action) {
    var alltabs = $('#tabs').tabs('tabs');
    var currentTab = $('#tabs').tabs('getSelected');
    var allTabtitle = [];
    $.each(alltabs, function (i, n) {
        allTabtitle.push($(n).panel('options').title);
    })
    switch (action) {
        case "refresh":
            var iframe = $(currentTab.panel('options').content);
            var src = iframe.attr('src');
            $('#tabs').tabs('update', {
                tab: currentTab,
                options: {
                    content: createFrame(src)
                }
            })
            break;
        case "close":
            var currtab_title = currentTab.panel('options').title;
            if (currtab_title != onlyOpenTitle) {
                $('#tabs').tabs('close', currtab_title);
            }
           
            break;
        case "closeall":
            $.each(allTabtitle, function (i, n) {
                if (n != onlyOpenTitle) {
                    $('#tabs').tabs('close', n);
                }
            });
            break;
        case "closeother":
            var currtab_title = currentTab.panel('options').title;
            $.each(allTabtitle, function (i, n) {
                if (n != currtab_title && n != onlyOpenTitle) {
                    $('#tabs').tabs('close', n);
                }
            });
            break; 
        case "exit":
            $('#closeMenu').menu('hide');
            break;
    }
}

// 全部打开或关闭
 function collapseAll(treeid){
     $(treeid).tree('collapseAll');
    }
 function expandAll(treeid) {
    $(treeid).tree('expandAll');
}
 
 

