

// create the Data Store


function renderTopic(value, p, record) {
    return Ext.String.format(
        '<b><a href="http://sencha.com/forum/showthread.php?t={2}" target="_blank">{0}</a></b><a href="http://sencha.com/forum/forumdisplay.php?f={3}" target="_blank">{1} Forum</a>',
        value,
        record.data.forumtitle,
        record.getId(),
        record.data.forumid
    );
}

function renderLast(value, p, r) {
    return Ext.String.format('{0}<br/>by {1}', Ext.Date.dateFormat(value, 'M j, Y, g:i a'), r.get('lastposter'));
}


var pluginExpanded = true;
Ext.define('Mod.Order.OrderList', {
    extend: 'SXD.ex.ModuleInstance',
    alias: 'Mod.Order.OrderList',
    getForm: function () {
        var from = Ext.create('Ext.form.Panel', {
            region: 'north',
            width: 550,
            fieldDefaults: {
                labelWidth: 95,
                autoFitErrors: false
            },
            defaultType: 'textfield',
            items: [
                {
                    xtype: 'fieldset',
                    title: '123123',
                    defaultType: 'textfield',
                    margin: '0 0 5 0',
                    items: [{
                        xtype: 'container',
                        layout: 'hbox',
                        defaultType: 'textfield',
                        margin: '0 0 5 0',
                        items: [{
                            fieldLabel: 'Email Address',
                            name: 'email',
                            width: 200,
                            vtype: 'email',
                            flex: 1,
                            allowBlank: false
                        }, {
                            fieldLabel: 'Phone Number',
                            labelWidth: 100,
                            name: 'phone',
                            width: 200,
                            emptyText: 'xxx-xxx-xxxx',
                            maskRe: /[\d\-]/,
                            regex: /^\d{3}-\d{3}-\d{4}$/,
                            regexText: 'Must be in the format xxx-xxx-xxxx'
                        }]
                    }]
                }]
        });
        return from;
    },
    getGrid: function (store) {
        var grid = Ext.create('Ext.grid.Panel', {

            region: 'center',
            store: store,
            disableSelection: true,
            loadMask: true,
            viewConfig: {
                id: 'gv',
                trackOver: false,
                stripeRows: false,
                plugins: [{
                    ptype: 'preview',
                    bodyField: 'excerpt',
                    expanded: true,
                    pluginId: 'preview'
                }]
            },
            columns: [{
                id: 'topic',
                text: "Topic",
                dataIndex: 'title',
                flex: 1,
                renderer: renderTopic,
                sortable: false
            }, {
                text: "Author",
                dataIndex: 'username',
                width: 100,
                hidden: true,
                sortable: true
            }, {
                text: "Replies",
                dataIndex: 'replycount',
                width: 70,
                align: 'right',
                sortable: true
            }, {
                id: 'last',
                text: "Last Post",
                dataIndex: 'lastpost',
                width: 150,
                renderer: renderLast,
                sortable: true
            }],
            // paging bar on the bottom
            bbar: Ext.create('Ext.PagingToolbar', {
                store: store,
                displayInfo: true,
                displayMsg: '当前显示记录 {0} - {1} of {2}',
                emptyMsg: "No topics to display",
                items: [
                    '-', {
                        text: 'Show Preview',
                        pressed: pluginExpanded,
                        enableToggle: true,
                        toggleHandler: function (btn, pressed) {
                            var preview = Ext.getCmp('gv').getPlugin('preview');
                            preview.toggleExpanded(pressed);
                        }
                    }]
            }),
            dockedItems: [{
                xtype: 'toolbar',
                dock: 'top',
                ui: 'footer',
                items: [{
                    iconCls: 'icon-save',
                    itemId: 'save',
                    text: '同步订单',
                    disabled: true,
                    scope: this,
                    handler: this.onSave
                }, {
                    iconCls: 'icon-user-add',
                    text: 'Create',
                    scope: this,
                    handler: this.onCreate
                }, {
                    iconCls: 'icon-reset',
                    text: 'Reset',
                    scope: this,
                    handler: this.onReset
                }]
            }]

        });
        return grid;

    },
    getStore: function () {
        var store = Ext.create('Ext.data.Store', {
            pageSize: 100,
            model: 'ForumThread',
            remoteSort: true,
            proxy: {
                type: 'jsonp',
                url: 'http://www.sencha.com/forum/topics-browse-remote.php',
                reader: {
                    root: 'topics',
                    totalProperty: 'totalCount'
                },
                simpleSortMode: true
            },
            sorters: [{
                property: 'lastpost',
                direction: 'DESC'
            }]
        });
        return store;
    },
    run: function () {
        var me = this;
        store = me.getStore();
        me.north = me.getForm();
        me.center = me.getGrid(store);
        store.loadPage(1);
        me.viewport.add([me.north, me.center]);
    }
});

Ext.define('ForumThread', {
    extend: 'Ext.data.Model',
    fields: [
        'title', 'forumtitle', 'forumid', 'username',
        { name: 'replycount', type: 'int' },
        { name: 'lastpost', mapping: 'lastpost', type: 'date', dateFormat: 'timestamp' },
        'lastposter', 'excerpt', 'threadid'
    ],
    idProperty: 'threadid'
});







