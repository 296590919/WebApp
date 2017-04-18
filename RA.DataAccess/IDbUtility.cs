using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using DataAccess.MsSqlDbUtility;

namespace DataAccess
{
    public interface IDbUtility
    {
        SqlSession<T> GetSqlExpression<T>() where T : class;
        List<T> GetList<T>(SqlSession<T> exp) where T : class;
        List<Target> GetList<Target, T>(SqlSession<T> exp) where T : class where Target : class;
        List<T> Paged<T>(Expression<Func<T, object>> By, int pageIndex, int pageSize = 1) where T : class;
        T GetSingle<T>(Expression<Func<T, bool>> func) where T : class;
        int Delete<T>(Expression<Func<T, bool>> func) where T : class;
        int Add<T>(T obj) where T : class;
        int RunSingleSql<T>(string sql) where T : class;
        DataTable GetDataBySql<T>(string sql) where T : class;
        int Update<T>(T obj, Expression<Func<T, bool>> func) where T : class;
        int AddList<T>(List<T> objs) where T : class;
        int Count<T>(Expression<Func<T, bool>> func = null) where T : class;
        Target Scala<T, Target>(Expression<Func<T, Target>> field, Expression<Func<T, bool>> func);
    }
}