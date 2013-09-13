Ext.define('SXD.ex.AutoGrid', {
			extend : 'Ext.grid.Panel',
			border : false,
			forceFit : true,
			frame : true,
			layout : 'fit',
			columnLines : true,
			loadMask : true,
			al : true,// 自动加载
			viewConfig : {
				stripeRows : true
			},
			storeParams : {},// 参数
			noPagging : false,
			dataUrl : '',
			initComponent : function() {

				var modelArray = [];
				Ext.each(this.columns, function(c) {
							modelArray[modelArray.length] = {
								name : c.dataIndex,
								type : c.type
							}
						});

				this.store = Ext.create('Ext.data.Store', {
							autoLoad : this.al,
							fields : modelArray,
							proxy : {
								type : 'ajax',
								url : this.dataUrl,
								extraParams : this.storeParams,
								reader : {
									type : 'json'
								}
							}
						});
				this.callParent(arguments);
			}

		});