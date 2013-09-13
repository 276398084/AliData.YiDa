// 错误提示
ShowErrorMsg = function(title, msg) {
	Ext.MessageBox.show({
				title : title,
				msg : msg,
				buttons : Ext.MessageBox.OK,
				icon : Ext.MessageBox.ERROR
			})
}
// 错误提示
ShowWarningMsg = function(title, msg) {
	Ext.MessageBox.show({
				title : title,
				msg : msg,
				buttons : Ext.MessageBox.OK,
				icon : Ext.MessageBox.WARNING
			})
}
// 普通提示
ShowInfoMsg = function(title, msg) {
	Ext.MessageBox.show({
				title : title,
				msg : msg,
				buttons : Ext.MessageBox.OK,
				icon : Ext.MessageBox.INFO
			})
}

// 删除
DoDelete = function(url, params, store) {
	Ext.MessageBox.confirm('操作确认', '确定要删除选择的项吗?', function(btn) {
		if (btn == 'yes') {
			Ext.Ajax.request({
						url : url,
						async : false,
						params : params,
						success : function(response) {
							var result = Ext.JSON.decode(response.responseText);
							if (Ext.isDefined(result)) {
								store.load();
							};

						}
					});
		}
	}, this);
}

// 获取grid当前选中行的数据(单行)
GetGridSelectedRowData = function(grid) {
	var selModel = grid.getSelectionModel();
	if (Ext.isDefined(selModel.getSelection()[0]))
		return selModel.getSelection()[0].data;
	else
		return null;
}

// 返回枚举列
GetEnumCm = function(cmc) {
	var cm = cmc;
	var list;
	Ext.Ajax.request({
				url : cm.url,
				async : false,
				success : function(response) {
					list = Ext.JSON.decode(response.responseText);
				}
			});
	var filterOptions = new Array();
	Ext.each(list, function(item) {
				filterOptions[filterOptions.length] = {
					id : item.Value,
					text : item.Key
				};
			})
	cm.filter = {
		type : 'list',
		options : filterOptions,
		phpMode : true
	}
	cm.renderer = function(v) {
		var rr;
		Ext.each(list, function(item) {
					if (v == item.Value) {
						rr = item.Key;
					}
				})
		if (!rr)
			return "";
		return rr;
	};
	return cm
};
// 树结点全选子节点帮助类
ChildCheck = function(node, checked) {
	node.eachChild(function(child) {
				if (child.get('checked') != checked) {
					child.set('checked', checked);
					node.expand();
					ChildCheck(child, checked);
				}
			});
};
// 树结点全选父节点帮助类
ParentCheck = function(node, checked) {
	if (checked) {
		node.parentNode.set('checked', true);
	} else {
		var flag = false;
		node.parentNode.eachChild(function(child) {
					if (child.get('checked') == true) {
						flag = true;
						return;
					}
				}, this);
		node.parentNode.set('checked', flag);
	}
	if (node.get('depth') > 1) {
		ParentCheck(node.parentNode, checked);
	}
}

// 列的金额格式化
CnMoneyRenderer = function(s, n) {
	n = n > 0 && n <= 20 ? n : 2;
	s = parseFloat((s + "").replace(/[^\d\.-]/g, "")).toFixed(n) + "";
	var l = s.split(".")[0].split("").reverse(), r = s.split(".")[1];
	t = "";
	for (i = 0; i < l.length; i++) {
		t += l[i] + ((i + 1) % 3 == 0 && (i + 1) != l.length ? "," : "");
	}
	return t.split("").reverse().join("") + "." + r;

};


// 保存cookie
function SetCookie(name, value)// 两个参数，一个是cookie的名子，一个是值
{
	var Days = 3000; // 此 cookie 将被保存 30 天
	var exp = new Date(); // new Date("December 31, 9998");
	exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
	document.cookie = name + "=" + escape(value) + ";expires="
			+ exp.toGMTString();
}
// 获取cookie
function getCookie(name)// 取cookies函数
{
	var arr = document.cookie
			.match(new RegExp("(^| )" + name + "=([^;]*)(;|$)"));
	if (arr != null)
		return unescape(arr[2]);
	return null;

}
// 移除cookie
function delCookie(name)// 删除cookie
{
	var exp = new Date();
	exp.setTime(exp.getTime() - 1);
	var cval = getCookie(name);
	if (cval != null)
		document.cookie = name + "=" + cval + ";expires=" + exp.toGMTString();
}
