// 动态检索数据combo
Ext.define('SXD.ex.RemotBoxCombo', {
			extend : 'Ext.ux.form.BoxSelect',
			alias : 'widget.SXD.ex.RemotBoxCombo',
			minChars : 0,
			dataUrl : '',// 请求绑定数据的地址
			emptyText : "请选择...",
			forceSelection : true,
			triggerAction : 'all',
			pageSize : 15,
			modelFields : [],
			initComponent : function() {
				this.store = Ext.create('Ext.data.Store', {
							fields : this.modelFields,
							pageSize : 15,
					//		autoLoad : true,
							proxy : {
								type : 'ajax',
								url : this.dataUrl,
								reader : {
									type : 'json',
									root : 'data',
									totalProperty : 'total'
								}
							}
						});
				this.callParent(arguments);
			}
		});