using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XD.Framework.AbstractModel.Mapping
{
    public abstract class TreeNodeMap<T> : BaseEntityMap<T> where T : TreeNode
    {
        public TreeNodeMap()
        {
            Map(t => t.Code, "CODE");
            Map(t => t.IsLeaf, "IS_LEAF");
            Map(t => t.NodeLevel, "NODE_LEVEL");
            Map(t => t.Parent, "PARENT");
            Map(t => t.Text, "`TEXT`");
            Map(t => t.TreeIds, "TREE_IDS");
        }
    }
}
