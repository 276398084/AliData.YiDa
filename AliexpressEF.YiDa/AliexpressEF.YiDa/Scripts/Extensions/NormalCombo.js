Ext.define('SXD.ex.NormalComboModel', {
			extend : "Ext.data.Model",
			fields : [{
						type : 'string',
						name : 'Id'
					}, {
						type : 'string',
						name : 'Text'
					}, {
						type : 'string',
						name : 'Code'
					}]
		});
// 一次性读取数据的combo,约定了 Text,Code,Id
Ext.define('SXD.ex.NormalCombo', {
			extend : 'Ext.form.field.ComboBox',
			alias : 'widget.SXD.ex.NormalCombo',
			dataUrl : '',// 请求绑定数据的地址
			emptyText : "请选择...",
			mode : 'local',
			queryMode : 'local',
			forceSelection : true,
			triggerAction : 'all',
			typeAhead : true,
			selectOnFocus : true,
			valueField : 'Id',
			displayField : 'Text',
			initComponent : function() {
				this.store = Ext.create('Ext.data.Store', {
							model : 'SXD.ex.NormalComboModel',
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
