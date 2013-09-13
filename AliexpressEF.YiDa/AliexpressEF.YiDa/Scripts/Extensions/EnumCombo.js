// 一次性读取数据的combo,约定了 Text,Code,Id
Ext.define('SXD.ex.EnumCombo', {
			extend : 'Ext.form.field.ComboBox',
			alias : 'widget.SXD.ex.EnumCombo',
			dataUrl : '',// 请求绑定数据的地址
			emptyText : "请选择...",
			mode : 'local',
			queryMode : 'local',
			forceSelection : true,
			triggerAction : 'all',
			typeAhead : true,
			selectOnFocus : true,
			valueField : 'Value',
			displayField : 'Key',
			initComponent : function() {
				this.store = Ext.create('Ext.data.Store', {
							fields : [{
										type : 'string',
										name : 'Key'
									}, {
										type : 'int',
										name : 'Value'
									}],
							proxy : {
								type : 'ajax',
								url : this.dataUrl,
								reader : {
									type : 'json'
								}
							}
						});
				this.store.load();
				this.callParent(arguments);
			}
		});
