Ext.define('SXD.ex.ModuleInstance', {
			mixins : {
				observable : 'Ext.util.Observable'
			},
			modId : '',
			constructor : function(config) {
				this.mixins.observable.constructor.call(this, config);
				this.parent = Ext.getCmp(this.modId);
				this.viewport = this.getViewPort();
				this.run();
				this.parent.add(this.viewport);
			},
			getViewPort : function() {
				var viewport = Ext.create('Ext.panel.Panel', {
							layout : {
								type : 'border'
							},
							border : false
						});
				return viewport;
			},
			run : Ext.emptyFn
		});