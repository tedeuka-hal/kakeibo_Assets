using UnityEngine;
using System.Text;
using System.Collections.Generic;

public class MachineReferenceTransactionData : AbstractData {
	public int id = 0;
	public int machineid = 0;
	public int machineidref = 0;
	public int rank = 0;
	public int gamenum = 0;

	public override void DebugPrint() {
		Debug.Log("MachineReferenceTransactionData id=" + id + ", machineid=" + machineid + ", machineidref=" + machineidref + ", rank=" + rank + ", gamenum=" + gamenum);
	}
}

public class MachineReferenceTransactionTable : AbstractDbTable<MachineReferenceTransactionData> {
	public static readonly string COL_ID = "id";
    public static readonly string COL_MACHINEID = "machineid";
    public static readonly string COL_MACHINEIDREF = "machineidref";
    public static readonly string COL_RANK = "rank";
    public static readonly string COL_GAMENUM = "gamenum";

	public MachineReferenceTransactionTable(ref SqliteDatabase db) : base(ref db) {
	}

    protected override string[] ColList
    {
        get
        {
            return new string[] { COL_ID, COL_MACHINEID, COL_MACHINEIDREF, COL_RANK, COL_GAMENUM };
        }
    }

    protected override string TableName {
		get {
			return "MachineReferenceTransaction";
		}
	}

	public override void MargeData(ref SqliteDatabase oldDb) {
	}

	public override void Update(MachineReferenceTransactionData data) {
		if (data.id <= DbDefine.DB_INVALID_PRIMARY_ID) {
			return;
		}

		StringBuilder query = new StringBuilder();
		MachineReferenceTransactionData selectData = SelectFromPrimaryKey<int>(new Dictionary<string, string>() { { COL_ID, data.id.ToString()} })[0];

		query.Append("INSERT INTO ");
		query.Append(TableName);
		query.Append(" VALUES(");
		query.Append(data.id);
		query.Append(",");
		query.Append(data.machineid);
		query.Append(",");
		query.Append("null");
		query.Append(",");
		query.Append(data.rank);
		query.Append(",");
		query.Append(data.gamenum);
		query.Append(");");

		mDb.ExecuteNonQuery(query.ToString());
	}

	protected override MachineReferenceTransactionData PutData(DataRow row) {
		MachineReferenceTransactionData data = new MachineReferenceTransactionData();
		data.id = GetIntValue(row, COL_ID);
		data.machineid = GetIntValue(row, COL_MACHINEID);
		data.machineidref = GetIntValue(row, COL_MACHINEIDREF);
		data.rank = GetIntValue(row, COL_RANK);
		data.gamenum = GetIntValue(row, COL_GAMENUM);
		return data;
	}

    public override MachineReferenceTransactionData PutJoinData(DataRow row)
    {
        MachineReferenceTransactionData data = new MachineReferenceTransactionData();
        data.id = GetIntValue(row, ColAddTableName(COL_ID));
        data.machineid = GetIntValue(row, ColAddTableName(COL_MACHINEID));
        data.machineidref = GetIntValue(row, ColAddTableName(COL_MACHINEIDREF));
        data.rank = GetIntValue(row, ColAddTableName(COL_RANK));
        data.gamenum = GetIntValue(row, ColAddTableName(COL_GAMENUM));
        return data;
    }
}
