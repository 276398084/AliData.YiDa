Ext.define('SXD.ex.Grid', {
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
			// selModel : Ext.create('Ext.selection.CheckboxModel'),
			noPagging : true,
			operBar : {},// 操作栏
			modelFields : [],
			dataUrl : '',
			defSort : [],
			initComponent : function() {
				this.store = Ext.create('Ext.data.Store', {
							pageSize : 100,
							remoteSort : true,
							autoLoad : this.al,
							fields : this.modelFields,
							sorters : this.defSort,
							proxy : {
							    type: 'jsonp',
								url : this.dataUrl,
								reader : {
									root: 'topics',
									totalProperty: 'totalCount'
								}
							}
						});

				this.buildFilters = function() {
					var filtersArray = [];
					Ext.each(this.columns, function(c) {
								if (c.noFilter != true) {
									filtersArray[filtersArray.length] = {
										dataIndex : c.dataIndex,
										type : c.type
									};
								}
							});
					return filtersArray;
				};
				this.features = [{
							ftype : 'filters',
							encode : true,
							menuFilterText : '检索',
							updateBuffer : 1000,
							filters : this.buildFilters()
						}];
				if (this.noPagging == false) {
					this.bbar = Ext.create('Ext.PagingToolbar', {
								store : this.store,
								pageSize : 20,
								displayInfo : true,
								plugins : Ext.create('Ext.ux.ProgressBarPager',
										{}),
								items : [{
											icon : '/Content/16Icons/lightning.png',
											tooltip : '重置查询',
											scope : this,
											handler : function() {
												this.filters.clearFilters();
											}
										}],
								emptyMsg : "没有可显示的数据"
							});
				}

				this.tbar = this.operBar;
				this.callParent(arguments);
			}

		});