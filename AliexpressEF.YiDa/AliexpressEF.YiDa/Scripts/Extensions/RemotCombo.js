// 动态检索数据combo
Ext.define('SXD.ex.RemotCombo', {
			extend : 'Ext.form.field.ComboBox',
			alias : 'widget.SXD.ex.RemotCombo',
			minChars : 0,
			dataUrl : '',// 请求绑定数据的地址
			emptyText : "请选择...",
			forceSelection : true,
			triggerAction : 'all',
			modelFields : [],
			isPagging : true,
			initComponent : function() {
				if (this.isPagging == true)
					this.pageSize = 15;
				this.store = Ext.create('Ext.data.Store', {
							fields : this.modelFields,
							pageSize : 15,
							// autoLoad : true,
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