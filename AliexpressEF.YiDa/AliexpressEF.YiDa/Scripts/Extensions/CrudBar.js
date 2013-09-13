// 增删改查按钮组
Ext.define('SXD.ex.CrudBar', {
			extend : 'Ext.toolbar.Toolbar',
			pushItems : [],
			initComponent : function() {
				this.addEvents('operAdd', 'operEdit', 'operDel', 'operRefresh');
				this.items = [{
							scale : 'medium',
							text : '新增',
							icon : "/Content/24Icons/plus.png",
							listeners : {
								scope : this,
								click : function() {
									this.fireEvent('operAdd');
								}
							}
						}, '-', {
							scale : 'medium',
							text : '修改',
							icon : "/Content/24Icons/Edit.png",
							listeners : {
								scope : this,
								click : function() {
									this.fireEvent('operEdit');
								}
							}
						}, '-', {
							scale : 'medium',
							text : '删除',
							icon : "/Content/24Icons/DeleteRed.png",
							listeners : {
								scope : this,
								click : function() {
									this.fireEvent('operDel');
								}
							}
						}, '-', {
							scale : 'medium',
							text : '刷新',
							icon : "/Content/24Icons/Sync.png",
							listeners : {
								scope : this,
								click : function() {
									this.fireEvent('operRefresh');
								}
							}
						}];
				this.items.push(this.pushItems);
				this.callParent(arguments);
			}
		});
