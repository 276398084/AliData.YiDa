
Ext.Loader.setConfig({
    enabled: true,
    paths: {
        'Mod.Order': '/Scripts/Mod/Order',
        'SXD.ex': '/Scripts/Extensions',
        'Ext.ux': '/Scripts/ux'
    }
});

Ext.require([
    'Ext.grid.*',
    'Ext.data.*',
    'Ext.util.*',
    'Ext.toolbar.Paging',
    'Ext.ux.PreviewPlugin',
    'Ext.ModelManager',
    'Ext.tip.QuickTipManager'
]);

Ext.define('Ali.Classics', {
    mixins: {
        observable: 'Ext.util.Observable' 
    },
    constructor: function (config) {
        this.mixins.observable.constructor.call(this, config);

        this.run();

    },
    getTitle: function () {
        var title = Ext.create('Ext.panel.Panel', {
            region: 'north',
            baseCls: 'x-plain',
            id: 'title-logo',
            border: false,
            padding: '0 0 5px 0',
            height: 65
        });
        return title;
    },
    getPage: function () {
        var page = Ext.create('Ext.panel.Panel', {
            region: 'center',
            border: false,
            layout: {
                type: 'border'
            },
            items: [this.tabs, this.menu]

        });
        return page;
    },
    getViewPort: function () {
        var viewport = Ext.create('Ext.Viewport', {
            layout: {
                type: 'border'
            },
            items: [this.page, this.title]
        });
        return viewport;
    },
    getTabs: function () {
        var tabs = Ext.create('Ext.tab.Panel', {
            region: 'center',
            border: false,
            plugins: Ext.create('Ext.ux.TabCloseMenu', {
                closeTabText: '关闭当前页',
                closeOthersTabsText: '关闭其他页',
                closeAllTabsText: '关闭所有页'
            }),
            items: [{
                id: '/Reports/Center/CenterColumn',
                title: '首页',
                iconCls: 'house',
                layout: 'fit',
                closable: false,
                loader: {
                    url: '/Reports/Center/CenterColumn',
                    autoLoad: true,
                    scripts: true,
                    loadMask: true
                }
            }]
        });
        return tabs;
    },
    ShortcutTpl: ['<tpl for=".">', '<div  class="appButton2">',
			'<div class="appButton_appIcon {icon3}" ></div>',
			'  <div class="appButton_appName">',
			'<div  class="appButton_appName_inner">{text}</div>', ' </div>',
			'</div>', '</tpl>'],
    getMenu: function () {
        var menu = Ext.create('Ext.panel.Panel', {
            region: 'west',
            border: false,
            collapsible: true,
            titleCollapse: true,
            split: true,
            border: false,
            width: 220,
            iconCls: 'plugin',
            // title : '功能菜单',
            hideCollapseTool: true,
            layout: 'accordion'
        });
        return menu;
    },
    buildMenuData: function () {
        Ext.Ajax.request({
            url: '/Home/GetPageMenuView',
            type: 'post',
            async: false,
            scope: this,
            success: function (response) {
                var result = Ext.JSON.decode(response.responseText);
                if (Ext.isDefined(result)) {
                    Ext.each(result, function (data) {
                        this.menu.add({
                            title: data.text,
                            iconCls: data.icon1,
                            autoScroll: true,
                            items: [{
                                xtype: 'dataview',
                                overItemCls: 'x-view-over',
                                listeners: {
                                    itemclick: this.menuItemdblclick,
                                    scope: this
                                },
                                itemSelector: 'div.appButton2',
                                store: Ext.create('Ext.data.Store', {
                                    autoLoad: true,
                                    fields: [{
                                        name: 'id'
                                    }, {
                                        name: 'text'
                                    }, {
                                        name: 'icon3'
                                    }, {
                                        name: 'icon1'
                                    }, {
                                        name: 'winId'
                                    }],
                                    data: data.children
                                }),
                                tpl: new Ext.XTemplate(this.ShortcutTpl)
                            }]
                        });
                    }, this);
                };

            }
        });
    },
    menuItemdblclick: function (dataView, record) {

        var tab = this.tabs.getComponent(record.data.winId);
        if (!tab) {
            tab = Ext.create('Ext.panel.Panel', {
                id: record.data.winId,
                title: record.data.text,
                iconCls: record.data.icon1,
                border: false,
                layout: 'fit',
                closable: true,
                loader: {
                    url: record.data.winId,
                    autoLoad: true,
                    scripts: true,
                    loadMask: true,
                    autoScroll: true,
                    text: '页面加载中，请稍候....'
                }
            });
            this.tabs.add(tab);
        }
        this.tabs.setActiveTab(tab);
    },
    run: function () {
        this.tabs = this.getTabs();
        this.menu = this.getMenu();
        this.page = this.getPage();
        this.title = this.getTitle();
        this.viewport = this.getViewPort();

        this.buildMenuData();
    }
});
Ext.onReady(function () {
    Ext.create('Ali.Classics');
});
