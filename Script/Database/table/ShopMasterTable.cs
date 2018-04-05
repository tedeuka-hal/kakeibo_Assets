using UnityEngine;
using System.Text;
using System.Collections.Generic;

public class ShopMasterData : AbstractData {
	public int id = 0;
	public string ShopName = "";

	public override void DebugPrint() {
		Debug.Log("ShopMasterData id=" + id + ", ShopName=" + ShopName);
	}
}

public class ShopMasterTable : AbstractDbTable<ShopMasterData> {
	public static readonly string COL_ID = "id";
	public static readonly string COL_SHOPNAME = "ShopName";

	public ShopMasterTable(ref SqliteDatabase db) : base(ref db) {
	}

    protected override string[] ColList
    {
        get
        {
            return new string[] { COL_ID, COL_SHOPNAME };
        }
    }

    protected override string TableName {
		get {
			return "ShopMaster";
		}
	}

	public override void MargeData(ref SqliteDatabase oldDb) {
	}

	public override void Update(ShopMasterData data) {
		if (data.id <= DbDefine.DB_INVALID_PRIMARY_ID) {
			return;
		}

		StringBuilder query = new StringBuilder();
		ShopMasterData selectData = SelectFromPrimaryKey<int>(new Dictionary<string, string>() { {COL_ID, data.id.ToString() } })[0];
		if (selectData == null) {
			query.Append("INSERT INTO ");
			query.Append(TableName);
			query.Append(" VALUES(");
			query.Append(data.id);
			query.Append(",");
			query.Append("'");
			query.Append(data.ShopName);
			query.Append("'");
			query.Append(");");
		} else {
			query.Append("UPDATE ");
			query.Append(TableName);
			query.Append(" SET ");
			query.Append(COL_SHOPNAME);
			query.Append("=");
			query.Append("'");
			query.Append(data.ShopName);
			query.Append("'");
			query.Append(" WHERE ");
			query.Append(COL_ID);
			query.Append("=");
			query.Append(data.id);
			query.Append(";");
		}
		mDb.ExecuteNonQuery(query.ToString());
		
	}

	protected override ShopMasterData PutData(DataRow row) {
		ShopMasterData data = new ShopMasterData();
		data.id = GetIntValue(row, COL_ID);
		data.ShopName = GetStringValue(row, COL_SHOPNAME);
		return data;
	}

    public override ShopMasterData PutJoinData(DataRow row)
    {
        ShopMasterData data = new ShopMasterData();
        data.id = GetIntValue(row, ColAddTableName(COL_ID));
        data.ShopName = GetStringValue(row, ColAddTableName(COL_SHOPNAME));
        return data;
    }
}
