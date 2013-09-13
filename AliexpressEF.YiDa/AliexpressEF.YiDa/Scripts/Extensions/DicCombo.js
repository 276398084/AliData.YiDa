// 动态检索数据combo
Ext.define('SXD.ex.DicCombo', {
			extend : 'Ext.form.field.ComboBox',
			alias : ['widget.SXD.ex.DicCombo','widget.oitDicCombo'],
			minChars : 0,
			dataUrl : '/DictionaryCommon/GetDicItemView',// 请求绑定数据的地址
			emptyText : "请选择...",
			forceSelection : true,
			triggerAction : 'all',
			valueField : 'Id',
			displayField : 'Text',
			dicCode : '',
			modelFields : [{
						name : 'Id'
					}, {
						name : 'Text'
					}, {
						name : 'Code'
					}],
			initComponent : function() {
				this.store = Ext.create('Ext.data.Store', {
							fields : this.modelFields,
							proxy : {
								type : 'ajax',
								url : this.dataUrl,
								extraParams : {
									code : this.dicCode
								},
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