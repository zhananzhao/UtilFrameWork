using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Util.Datas.Ef;
using Util.Domains;
using Util.Domains.Repositories;

namespace Util.Datas.Dapper
{
    public static class DapperExtention
    {

        public static IEnumerable<TResult> ExecStroedSql<TEntity, TKey, TResult>(this IRepository<TEntity, TKey> rep, string spName, object param, CommandType type = CommandType.StoredProcedure) where TEntity : class, IAggregateRoot<TKey>
        {
            DbContext content = rep.GetUnitOfWork() as DbContext;
            if (content == null)
                return default(IEnumerable<TResult>);
            var conn = content.Database.Connection;
            return conn.Query<TResult>(spName, param, commandType: type);
        }

        
    }





}
