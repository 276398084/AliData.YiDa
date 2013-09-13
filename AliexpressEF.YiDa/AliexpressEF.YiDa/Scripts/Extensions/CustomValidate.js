// 密码相等验证
Ext.apply(Ext.form.VTypes, {

			password : function(val, field) {
				if (field.initialPassField) {
					var pwd = field.findParentByType('form').getForm().findField(field.initialPassField);
					if (val == pwd.getValue()) {
						pwd.clearInvalid();
						return true;
					} else {
						return false;
					}
				}
				return true;
			},

			passwordText : '两次输入不一致，请重新输入'
		});
// 大小比较的验证
Ext.apply(Ext.form.VTypes, {
			compareNum : function(val, field) {
				if (field.initialNumField) {
					var otherField =  field.findParentByType('ev-generalform').getForm().findField(field.initialNumField);
					this.compareNumText = field.compareNumText;
					if (Ext.isNumber(otherField.getValue())&&otherField.getValue()>=0) {
						if (field.maxOrMin == "max") {
							if (val >= otherField.getValue()) {
								otherField.clearInvalid();
								return true;
							} else {
								return false;
							}
						} else if (field.maxOrMin == "min") {
							if (val <= otherField.getValue()) {
								otherField.clearInvalid();
								return true;
							} else {
								return false;
							}
						}
					} else {
						return false;
					}
				}
				return true;
			}
		});
// 日期范围验证
Ext.apply(Ext.form.VTypes, {
			daterange : function(val, field) {
				var date = field.parseDate(val);
				if (!date) {
					return;
				}
				if (field.startDateField
						&& (!this.dateRangeMax || (date.getTime() != this.dateRangeMax
								.getTime()))) {
					var start = field.findParentByType('ev-generalform').getForm().findField(field.startDateField);
					start.setMaxValue(date);
					start.validate();
					this.dateRangeMax = date;
				} else if (field.endDateField
						&& (!this.dateRangeMin || (date.getTime() != this.dateRangeMin
								.getTime()))) {
					var end = field.findParentByType('ev-generalform').getForm().findField(field.endDateField);
					end.setMinValue(date);
					end.validate();
					this.dateRangeMin = date;
				}
				return true;
			}
		});
