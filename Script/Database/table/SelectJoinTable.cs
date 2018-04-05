using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// テーブル結合を行う際に使用
/// </summary>
public class SelectJoinTable
{
    // データベース
    private SqliteDatabase mDb;

    public SelectJoinTable(ref SqliteDatabase db)
    {
        mDb = db;
    }

    public dynamic ExcecuteJoinQuery<T,U>(ref AbstractDbTable<T> tableT,ref AbstractDbTable<U> tableU,string joinKey, Dictionary<string,string> whereKey = null) 
        where T :AbstractData where U : AbstractData
    {
        StringBuilder query = new StringBuilder();

        query.Append("SELECT");

        foreach (var select in tableT.ColAddTableName())
        {
            query.Append(select);
        }
        foreach (var select in tableU.ColAddTableName())
        {
            query.Append(select);
        }

        query.Append("FROM");
        query.Append(tableT.GetTableName());
        query.Append("LEFT OUTER JOIN");
        query.Append(tableU.GetTableName());
        query.Append("IN");
        query.Append(tableT +"."+ joinKey + "=" + tableU + "." + joinKey);

        if (whereKey != null)
        {
            QueryUtility.CreateWhereQuery(ref query, whereKey);
        }

        query.Append(";");

        Debug.Log(query);

        DataTable dt = mDb.ExecuteQuery(query.ToString());

        if (dt.Rows.Count == 0)
        {
            return null;
        }
        else
        {
            var tableTListData = new List<T>();
            var tableUListData = new List<U>();

            foreach(var row in dt.Rows)
            {
                tableTListData.Add(tableT.PutJoinData(row));
                tableUListData.Add(tableU.PutJoinData(row));
            }

            return new
            {
                tableTListData,
                tableUListData
            };
        }
    }
}