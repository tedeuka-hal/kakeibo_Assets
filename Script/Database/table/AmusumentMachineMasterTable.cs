using UnityEngine;
using System.Text;
using System.Collections.Generic;

public class AmusumentMachineMasterData : AbstractData {
	public int machinenumber = 0;
	public string machineName = "";

	public override void DebugPrint() {
		Debug.Log("AmusumentMachineMasterData machinenumber=" + machinenumber + ", machineName=" + machineName);
	}
}

public class AmusumentMachineMasterTable : AbstractDbTable<AmusumentMachineMasterData> {

	public static readonly string COL_MACHINEID = "machineid";
    public static readonly string COL_MACHINENAME = "machineName";

    protected override string[] ColList
    {
        get
        {
            return new string[] { COL_MACHINEID, COL_MACHINENAME };
        }
    }

    public AmusumentMachineMasterTable(ref SqliteDatabase db) : base(ref db) {
	}

    protected override string TableName {
		get {
			return "AmusumentMachineMaster";
		}
	}

	public override void MargeData(ref SqliteDatabase oldDb) {
	}

    public override void Update(AmusumentMachineMasterData data) {
        if (data.machinenumber <= DbDefine.DB_INVALID_PRIMARY_ID) {
            return;
        }

        StringBuilder query = new StringBuilder();
        AmusumentMachineMasterData selectData = SelectFromPrimaryKey<int>(new Dictionary<string, string>() { { COL_MACHINEID,data.machinenumber.ToString() } })[0];
		if (selectData == null) {
			query.Append("INSERT INTO ");
			query.Append(TableName);
			query.Append(" VALUES(");
			query.Append(data.machinenumber);
			query.Append(",");
			query.Append("'");
			query.Append(data.machineName);
			query.Append("'");
			query.Append(");");
		} else {
			query.Append("UPDATE ");
			query.Append(TableName);
			query.Append(" SET ");
			query.Append(COL_MACHINENAME);
			query.Append("=");
			query.Append("'");
			query.Append(data.machineName);
			query.Append("'");
			query.Append(" WHERE ");
			query.Append(COL_MACHINEID);
			query.Append("=");
			query.Append(data.machinenumber);
			query.Append(";");
		}
		mDb.ExecuteNonQuery(query.ToString());
	}

	protected override AmusumentMachineMasterData PutData(DataRow row) {
		AmusumentMachineMasterData data = new AmusumentMachineMasterData();
		data.machinenumber = GetIntValue(row, COL_MACHINEID);
		data.machineName = GetStringValue(row, COL_MACHINENAME);
		return data;
	}

    public override AmusumentMachineMasterData PutJoinData(DataRow row)
    {
        AmusumentMachineMasterData data = new AmusumentMachineMasterData();
        data.machinenumber = GetIntValue(row, ColAddTableName(COL_MACHINEID));
        data.machineName = GetStringValue(row, ColAddTableName(COL_MACHINENAME));
        return data;
    }
}
