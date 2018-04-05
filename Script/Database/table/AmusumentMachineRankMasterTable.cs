using UnityEngine;
using System.Text;

public class AmusumentMachineRankMasterData : AbstractData {
	public int machineid = 0;
	public int rank = 0;

	public override void DebugPrint() {
		Debug.Log("AmusumentMachineMasterData machinenumber=" + machineid + ", machineName=" + rank);
	}
}

public class AmusumentMachineRankMasterTable : AbstractDbTable<AmusumentMachineRankMasterData>
{
    public static readonly string COL_MACHINEID = "machineid";
    public static readonly string COL_RANK = "rank";
    public static readonly string COL_VIEWBONUS = "viewbonus";

    protected override string[] PrimaryKeyName { get { return new string[] {COL_MACHINEID,COL_RANK}; } }

    protected override string[] ColList
    {
        get
        {
            return new string[] { COL_MACHINEID, COL_RANK };
        }
    }

    public AmusumentMachineRankMasterTable(ref SqliteDatabase db) : base(ref db)
    {
    }

    protected override string TableName
    {
        get
        {
            return "AmusumentMachineMaster";
        }
    }

    public override void MargeData(ref SqliteDatabase oldDb)
    {
    }

    public override void Update(AmusumentMachineRankMasterData data)
    {
    }

    protected override AmusumentMachineRankMasterData PutData(DataRow row)
    {
        AmusumentMachineRankMasterData data = new AmusumentMachineRankMasterData();
        data.machineid = GetIntValue(row, COL_MACHINEID);
        data.rank = GetIntValue(row, COL_RANK);
        return data;
    }

    public override AmusumentMachineRankMasterData PutJoinData(DataRow row)
    {
        AmusumentMachineRankMasterData data = new AmusumentMachineRankMasterData();
        data.machineid = GetIntValue(row, COL_MACHINEID);
        data.rank = GetIntValue(row, COL_RANK);
        return data;
    }
}