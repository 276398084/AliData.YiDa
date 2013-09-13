Ext.define('SXD.ex.CreditFieldSet', {
	extend : 'Ext.form.FieldSet',
	alias : ['widget.SXD.ex.CreditFieldSet', 'widget.CreditFieldSet'],
	initComponent : function() {
		this.callParent(arguments);
	},
	//重写基类里的这个方法
	afterRender : function() {
		this.callParent(arguments);
		
		var comboValue = Ext.getCmp('CreditBaseSearch_SearchString').getValue();

		if (this.count > 1)
			this.add(this.getDynamicGrid(this.tableId, comboValue, this.count));
		else
			this.add(this.getDynamicFrom(this.tableId, comboValue, this.count));
			
		

	},
	// 生成动态表单
	getDynamicFrom : function(tableId, objId, count) {
		var getFileds = function() {
			var result = null;
			Ext.Ajax.request({
						url : '/Biz/CreditBaseSearch/BuildFormFileds',
						async : false,
						params : {
							TableId : tableId,
							FiledsWidth : 290
						},
						success : function(response) {
							result = Ext.JSON.decode(response.responseText);
						}
					});
			return result;
		};
		var form = Ext.create('Ext.form.Panel', {
			id : 'CreditBaseSearch_DynamicFrom',
			border : false,
			waitMsgTarget : true,
			// autoScroll : true,
			bodyPadding : 5,
			frame : true,
			defaults : {
				labelAlign : 'right',
				labelWidth : 110,
				width : 310
			},
			layout : {
				scope : this,
				type : 'table',
				columns : 3
			},
			items : getFileds(),
			listeners : {
				scope : this,
				afterrender : function(f) {
					if (count < 1)// 如果没有记录返回
					{
						this.content.setTitle('<span style="color: red;" >无记录-'
								+ this.content.title + '</span>');
						return;
					}

					Ext.Ajax.request({
						url : '/Biz/CreditBaseSearch/FormLoad',
						async : false,
						params : {
							TableId : tableId,
							ObjId : objId
						},
						success : function(response) {
							result = Ext.JSON.decode(response.responseText);
							Ext.each(result, function(p) {
								var field = Ext
										.getCmp('CreditBaseSearch_DynamicFrom').form
										.findField('ExtField|' + p.fName);

								if (p.fType == 'oitDicCombo' && p.fValue != '')// 如果是字典
								{
									Ext.Ajax.request({
										url : '/DictionaryCommon/GetDicItemById',
										async : false,
										params : {
											Id : p.fValue
										},
										success : function(response) {
											var result = Ext.JSON
													.decode(response.responseText);
											if (Ext.isDefined(result)) {
												field.store.add({
															Id : result.Id,
															Text : result.Text
														})
											};

										}
									});
								}
								field.setValue(p.fValue);
							});

						}
					});
				}
			}
		});
		return form;
	},
	// 生成动态表格
	getDynamicGrid : function(tableId, objId, count) {
		var getColumns = function() {
			var result = null;
			Ext.Ajax.request({
						url : '/Biz/CreditBaseSearch/BuildGridColumns',
						async : false,
						params : {
							TableId : tableId
						},
						success : function(response) {
							result = Ext.JSON.decode(response.responseText);
						}
					});
			return result;
		};

		var grid = Ext.create('SXD.ex.AutoGrid', {
					// region : 'center',
					dataUrl : '/Biz/CreditBaseSearch/GetGridUsedInfo',
					storeParams : {
						TableId : tableId,
						ObjId : objId
					},
					columns : getColumns()
				});
		return grid;
	}
});