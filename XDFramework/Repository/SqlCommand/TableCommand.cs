using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;

namespace XD.Framework.Repository.SqlCommand
{
    public class Tablecommand
    {
        private readonly SqlDatabase sqldb = (SqlDatabase)DatabaseFactory.CreateDatabase("defaultConnection");

        /// <summary>
        /// 创建表
        /// </summary>
        /// <param name="tableName"></param>
        public void CreateTable(string tableName)
        {
            DbCommand cmd = sqldb.GetStoredProcCommand("CreateTable");
            sqldb.AddInParameter(cmd, "@TableName", System.Data.SqlDbType.NVarChar, tableName);

            sqldb.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// 重命名表
        /// </summary>
        /// <param name="objName"></param>
        /// <param name="newName"></param>
        public void RenameTable(string objName, string newName)
        {
            DbCommand cmd = sqldb.GetStoredProcCommand("sp_rename");   //改表名
            sqldb.AddInParameter(cmd, "@objname", System.Data.SqlDbType.NVarChar, objName);
            sqldb.AddInParameter(cmd, "@newname", System.Data.SqlDbType.NVarChar, newName);
            sqldb.ExecuteNonQuery(cmd);

            DbCommand cmd2 = sqldb.GetStoredProcCommand("sp_rename");  //改主键ID名
            sqldb.AddInParameter(cmd2, "@objname", System.Data.SqlDbType.NVarChar, newName + "." + objName + "_ID");
            sqldb.AddInParameter(cmd2, "@newname", System.Data.SqlDbType.NVarChar, newName + "_ID");
            sqldb.AddInParameter(cmd2, "@objtype", System.Data.SqlDbType.NVarChar, "COLUMN");
            sqldb.ExecuteNonQuery(cmd2);
        }

        /// <summary>
        /// 删除表
        /// </summary>
        /// <param name="tableName"></param>
        public void DropTable(string tableName)
        {
            DbCommand cmd = sqldb.GetStoredProcCommand("DropTable");
            sqldb.AddInParameter(cmd, "@TableName", System.Data.SqlDbType.NVarChar, tableName);

            sqldb.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// 添加列
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        /// <param name="dataType"></param>
        public void CreateColumn(string tableName, string columnName, string dataType)
        {
            DbCommand cmd = sqldb.GetStoredProcCommand("CreateColumn");
            sqldb.AddInParameter(cmd, "@TableName", System.Data.SqlDbType.NVarChar, tableName);
            sqldb.AddInParameter(cmd, "@ColumnName", System.Data.SqlDbType.NVarChar, columnName);
            sqldb.AddInParameter(cmd, "@DataType", System.Data.SqlDbType.NVarChar, dataType);

            sqldb.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// 删除列
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        public void DropColumn(string tableName, string columnName)
        {
            DbCommand cmd = sqldb.GetStoredProcCommand("DropColumn");
            sqldb.AddInParameter(cmd, "@TableName", System.Data.SqlDbType.NVarChar, tableName);
            sqldb.AddInParameter(cmd, "@ColumnName", System.Data.SqlDbType.NVarChar, columnName);

            sqldb.ExecuteNonQuery(cmd);
        }
    }
}
