using System.Collections.Generic;
using System.Text;

public static class QueryUtility
{
    public static StringBuilder CreateWhereQuery(ref StringBuilder query, Dictionary<string,string> whereQuery)
    {
        query.Append(" WHERE ");
        foreach (var sql in whereQuery)
        {
            query.Append(sql.Key);
            query.Append("=");
            query.Append(sql.Value);
            query.Append(" AND ");
        }
        query.Remove(query.Length - 5, 5); // AND削除

        return query;
    }
}