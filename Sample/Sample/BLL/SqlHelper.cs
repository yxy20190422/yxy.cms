using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Sample.Models;
using Sample.Models.DBModel;
namespace Sample.BLL
{
    public class SqlHelper
    {
        private static string connstr = "Data Source=172.168.18.208;Initial Catalog=CMS;Integrated Security=True; Pooling=true;Max Pool Size=100;";
        private SqlConnection conn = new SqlConnection(connstr);
        /// <summary>
        /// 执行增删改sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool ExcuteDMLSqlstring<T>(string sql, T t)
        {
            bool flag = false;
            using (conn)
            {
                try
                {
                    int res = conn.Execute(sql, t);
                    if (res > 0)
                    {
                        flag = true;
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.StackTrace.ToString());
                }               
            }
            return flag;
        }

        /// 查询单条指定的数据
        /// </summary>
        public T test_select_one<T>(string sql, T t) where T : new()
        {
            using (conn)
            {
                try
                {
                    t = conn.QueryFirstOrDefault<T>(sql, t);
                    return t;
                }
                catch (Exception ex)
                {
                    return default(T);
                    throw;
                }
            }
        }

        public List<T> select_list<T>(string sql,T t) where T : new ()
        {
            using (conn)
            {
                try
                {
                    var result = conn.Query<T>(sql, t).ToList();
                    return result;
                }
                catch (Exception ex)
                {
                    return default(List<T>);
                    throw;
                }
            }
        }

        /*执行关联查询*/
        public void ExcuiteQueryMultiple<T>(string sql, T t)
        {
            using (conn)
            {
                try
                {
                    var result = conn.QueryMultiple(sql, t);
                    var content = result.ReadFirstOrDefault<ContentWithComment>();
                    content.comments = result.Read<Comment>();

                }
                catch (Exception ex)
                {
                    
                    throw;
                }
            }
        }

    }
}
