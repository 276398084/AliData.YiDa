// 自定义checkBox
Ext.define('SXD.ex.CheckBox', {
			extend : 'Ext.form.field.Checkbox',
			alias : ['widget.oitCheckbox', 'widget.SXD.ex.Checkbox'],
			inputValue : 'true',
			uncheckedValue : 'false',
			initComponent : function() {
				this.callParent(arguments);
			}
		});