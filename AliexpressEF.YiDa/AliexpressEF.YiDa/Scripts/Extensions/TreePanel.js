
// 系统中表示树形结构的控件
Ext.define('SXD.ex.TreePanel', {
			extend : 'Ext.tree.Panel',
			singleExpand : true,
			rootVisible : false,
			loadMask : true,
			isGrid : false,// 如果不为空，就是TreeGrid
			ajaxUrl : '',// 请求数据的地址
			modelName : '',// Model名称
			operBar : {},
			selectedId : '',
			listeners : {
				itemclick : function(view, record, item, index, e) {
					this.selectedId = record.raw.id
				}

			},
			initComponent : function() {

				if (this.isGrid == false) {
					this.store = Ext.create('Ext.data.TreeStore', {
								proxy : {
									type : 'ajax',
									url : this.ajaxUrl
								},
								root : {
									text : '.',
									id : 'root',
									expanded : true
								},
								folderSort : true
							});
				} else {
					this.store = Ext.create('Ext.data.TreeStore', {
								model : this.modelName,
								proxy : {
									type : 'ajax',
									url : this.ajaxUrl
								},
								root : {
									text : 'root',
									id : 'root',
									expanded : true
								},
								folderSort : true
							});
				}
				this.tbar = this.operBar;
				this.callParent(arguments);
			}
		});