using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace PetaPoco {
    public partial class Database {
        public Database() {
            var connStr = string.Empty;
            try {
                connStr = System.Configuration.ConfigurationManager.ConnectionStrings["dbconstr"].ConnectionString;
            } catch (Exception) {

            }
            _connectionString = connStr;
            _providerName = "System.Data.SqlClient";
            CommonConstruct();
        }

        public Database(string connStr) {
            _connectionString = connStr;
            _providerName = "System.Data.SqlClient";
            CommonConstruct();
        }

        public DataTable ExecuteDataTable(string sql, params object[] args) {
            DataTable dt = new DataTable();
            OpenSharedConnection();
            try {
                using (var cmd = CreateCommand(_sharedConnection, sql, args)) {
                    using (DbDataAdapter dbDataAdapter = _factory.CreateDataAdapter()) {
                        dbDataAdapter.SelectCommand = (DbCommand)cmd;
                        dbDataAdapter.Fill(dt);
                        return dt;
                    }
                }
            } catch (Exception x) {
                OnException(x);
                throw;
            } finally {
                CloseSharedConnection();
            }
        }
    }
}

namespace DbEntity {
    /// <summary>
    /// 文件属性
    /// </summary>
    public class FileProperty {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public string Size { get; set; }
        /// <summary>
        /// 文件类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 文件后缀名
        /// </summary>
        public string Eextension { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModifyDate { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
    }

}
