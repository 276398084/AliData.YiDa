// 系统中的表单基类
Ext.define('SXD.ex.FormWin', {
	extend : 'Ext.window.Window',
	border : false,
	layout : 'fit',
	plain : true,
	saveParams : {},
	closeAction : 'destroy',
	closable : true,
	modal : true,
	iconCls : 'application_form',
	operType : '',// 操作类型,
	formWinItems : [],// 表单包含的字段
	formColumns : 1,// 有几列
	formWinLabelWidth : 100,// 字段label的宽度
	formWinFieldWidth : 280,// 字段的总宽度
	saveUrl : '',// 提交的url地址
	loadUrl : '',// 读取数据的Url地址
	fPanel : null,// 操作的父页面对象
	objId : null,// 要修改的数据的id
	disableFields : [],// 编辑时要禁用的字段['Text', 'Code']
	getBaseForm : function() {
		return this.form.form;
	},
	initComponent : function() {
		this.form = Ext.create('Ext.form.Panel', {
					waitMsgTarget : true,
					autoScroll : true,
					bodyPadding : 5,
					frame : true,
					border : false,
					defaults : {
						labelAlign : 'right',
						labelWidth : this.formWinLabelWidth,
						width : this.formWinFieldWidth
					},
					layout : {
						scope : this,
						type : 'table',
						columns : this.formColumns
					},
					items : this.formWinItems,
					listeners : {
						scope : this,
						afterrender : function() {
							if (this.operType == 'edit') {
								this.form.form.load({
											scope : this,
											url : this.loadUrl,
											params : {
												Id : this.objId
											},
											waitMsg : ''
										});

								Ext.each(this.disableFields, function(i) {
											this.form.form.findField(i)
													.disable(true);
										}, this);

							}

						}
					}
				});

		this.items = [this.form];
		switch (this.operType) {
			case 'add' :
				if (this.title == null)
					this.title = '新增';
				this.dockedItems = [{
					xtype : 'toolbar',
					dock : 'bottom',
					ui : 'footer',
					layout : {
						pack : 'center'
					},
					items : [{
						scale : 'medium',
						text : '提交',
						style : 'margin:1px,1px,1px,1px',
						icon : "/Content/24Icons/clean.png",
						width : 80,
						height : 35,
						listeners : {
							scope : this,
							click : function() {
								var form = this.form.form;
								if (form.isValid()) {
									form.submit({
												scope : this,
												params : this.saveParams,
												url : this.saveUrl,
												success : function(form, action) {
													this.fPanel.getStore()
															.load();
													this.close();
												}
											});
								}
							}
						}
					}, {
						scale : 'medium',
						text : '重置',
						style : 'margin:1px,1px,1px,1px',
						icon : "/Content/24Icons/new-view-refresh.png",
						width : 80,
						height : 35,
						listeners : {
							scope : this,
							click : function() {
								this.form.form.reset();
							}
						}
					}, {
						scale : 'medium',
						text : '退出',
						style : 'margin:1px,1px,1px,1px',
						icon : "/Content/24Icons/Cancel.png",
						width : 80,
						height : 35,
						listeners : {
							scope : this,
							click : function() {
								this.close();
							}
						}
					}]
				}];

				break;
			case 'edit' :
				if (this.title == null)
					this.title = '修改';
				this.dockedItems = [{
					xtype : 'toolbar',
					dock : 'bottom',
					ui : 'footer',
					layout : {
						pack : 'center'
					},
					items : [{
						scale : 'medium',
						text : '提交',
						style : 'margin:1px,1px,1px,1px',
						icon : "/Content/24Icons/clean.png",
						width : 80,
						height : 35,
						listeners : {
							scope : this,
							click : function() {
								var form = this.form.form;
								if (form.isValid()) {
									form.submit({
												scope : this,
												url : this.saveUrl,
												params : {
													Id : this.objId
												},
												success : function(form, action) {
													this.fPanel.getStore()
															.load();
													this.close();
												}
											});
								}
							}
						}
					}, {
						scale : 'medium',
						text : '重置',
						style : 'margin:1px,1px,1px,1px',
						icon : "/Content/24Icons/new-view-refresh.png",
						width : 80,
						height : 35,
						listeners : {
							scope : this,
							click : function() {

								this.form.form.reset();
							}
						}
					}, {
						scale : 'medium',
						text : '退出',
						style : 'margin:1px,1px,1px,1px',
						icon : "/Content/24Icons/Cancel.png",
						width : 80,
						height : 35,
						listeners : {
							scope : this,
							click : function() {
								this.close();
							}
						}
					}]
				}];
				break;
		}
		this.callParent(arguments);
	}
});