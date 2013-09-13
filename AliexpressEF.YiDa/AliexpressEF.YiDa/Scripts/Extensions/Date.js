
// 自定义Date
Ext.define('SXD.ex.Date', {
    extend: 'Ext.DatePicker',
    alias: 'widget.SXD.ex.Date',
    applyTo: 'txtDate',
    width: 110,
    format: 'Y年m月d日',
    emptyText: '请选择日期 ...',  
    initComponent: function () {
        this.callParent(arguments);
    }
});