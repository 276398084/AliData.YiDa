
Ext.define('Mod.Order.Index', {
    extend: 'SXD.ex.ModuleInstance',
    alias: 'Mod.Order.Index',
    getCenterPanel: function () {
        var panel = Ext.create('Ext.panel.Panel', {
            title: '中间的',
            region: 'center',
            border: false,
            items: [{
                xtype: 'button',
                scale: 'medium',
                text: '点我啊！！！',
                icon: "/Content/imgs/24Icons/plus.png",
                listeners: {
                    scope: this,
                    click: function () {
                        ShowErrorMsg('弦哥～', '哦也哦也～～～');
                    }
                }
            }]
        });
        return panel;
    },
    getLeftPanel: function () {
        var panel = Ext.create('Ext.panel.Panel', {
            title: '左边的',
            collapsible: true,
            hideCollapseTool: true,
            titleCollapse: true,
            split: true,
            width: '60%',
            region: 'west',
            border: false,
            html: '我们是按需加载进来的哦'
        });
        return panel;
    },

    run: function () {
        var me = this;
        me.left = me.getLeftPanel();
        me.center = me.getCenterPanel();
        me.viewport.add([me.left, me.center]);

    }
});
