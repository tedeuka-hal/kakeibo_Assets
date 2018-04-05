using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;


public class DataBaseController : MonoBehaviour, MyDatabaseListener {

	// Use this for initialization
	void Awake () {
		// データベース初期化、ゲーム起動時などで1回だけ実行すればOK
		MyDatabase.Init(this, this);
	}

	public void OnDatabaseInit() {
		// データベースの初期化の後に行いたい処理を実装する、例えばデータベース内の値を使った他の何かの初期化とか
	}

	/// <summary>
	/// 店舗テーブルから1件取得
	/// </summary>
	/// <param name="id">shop id</param>
	/// <returns></returns>
	public ShopMasterData SelectShopMaster(int id)
	{
		// 以下は実際に使用する時の使い方の例
		MyDatabase db = MyDatabase.Instance;

		// データベースのテーブルを取得
		ShopMasterTable shopMasterTable = db.GetShopMasterTable();

		return shopMasterTable.SelectFromPrimaryKey<int>(new Dictionary<string, string> { {ShopMasterTable.COL_ID, "" } })[0];
	}

	/// <summary>
	/// 店舗テーブルから全件取得
	/// </summary>
	/// <returns></returns>
	public List<ShopMasterData> SelectShopMaster()
	{
		// 以下は実際に使用する時の使い方の例
		MyDatabase db = MyDatabase.Instance;

		// データベースのテーブルを取得
		ShopMasterTable shopMasterTable = db.GetShopMasterTable();

		return shopMasterTable.SelectAll();
	}

	/// <summary>
	/// 店舗テーブルの登録／更新
	/// </summary>
	/// <param name="id">主キー</param>
	/// <param name="name">店舗名</param>
	/// <returns></returns>
	public bool InsertUpdateShopMaster(int id, string name)
	{
		// 以下は実際に使用する時の使い方の例
		MyDatabase db = MyDatabase.Instance;

		// データベースのテーブルを取得
		ShopMasterTable shopMasterTable = db.GetShopMasterTable();

		ShopMasterData shopMasterData = shopMasterTable.SelectFromPrimaryKey<int>(new Dictionary<string, string>() { { ShopMasterTable.COL_ID , id.ToString()} } )[0];

		// InsertまたはUpdate
		// ※同一の主キーのデータがあればUpdate、無ければInsertとなる
		shopMasterData.id = id;
		shopMasterData.ShopName = name;

		shopMasterTable.Update(shopMasterData);
		return true;
	}

	/// <summary>
	/// 収支テーブルから全件取得
	/// </summary>
	/// <returns></returns>
	public List<InvestmentTransactionData> SelectInvestmentTransaction()
	{
		// 以下は実際に使用する時の使い方の例
		MyDatabase db = MyDatabase.Instance;

		// データベースのテーブルを取得
		InvestmentTransactionTable investmentTransactionTable = db.GetInvestmentTransactionTable();

		return investmentTransactionTable.SelectAll();
	}


    /// <summary>
    /// 機械テーブルから全件取得
    /// </summary>
    /// <returns></returns>
    public List<AmusumentMachineMasterData> SelectMachineMaster()
    {
        // 以下は実際に使用する時の使い方の例
        MyDatabase db = MyDatabase.Instance;

        // データベースのテーブルを取得
        AmusumentMachineMasterTable amusumentMachineMasterTable = db.GetAmusumentMachineMasterTable();

        return amusumentMachineMasterTable.SelectAll();
    }

    /// <summary>
    /// 子役テーブル/機械子役テーブルから全件取得
    /// </summary>
    /// <returns></returns>
    public List<AmusumentMachineRankMasterData> SelectMachineRank(int machineid)
    {
        // 以下は実際に使用する時の使い方の例
        MyDatabase db = MyDatabase.Instance;

        // データベースのテーブルを取得
        var AmusumentMachineRankMaster = db.GetSelectJoinTable();
        // AmusumentMachineRankMaster.ExcecuteJoinQuery<AmusumentMachineRankMasterData, AmusumentMachineRankMasterTable>();

        return AmusumentMachineRankMaster.SelectFromPrimaryKey<int>(new Dictionary<string, string>() { { AmusumentMachineRankMasterTable.COL_MACHINEID, machineid.ToString() } });
    }


    /// <summary>
    /// 収支テーブルの登録／更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public bool InsertUpdateInvestmentTransaction(int shopId, int machineId, int machineNumber, int investment, int collection)
	{
		// 以下は実際に使用する時の使い方の例
		MyDatabase db = MyDatabase.Instance;

		// データベースのテーブルを取得
		InvestmentTransactionTable investmentTransaction = db.GetInvestmentTransactionTable();
		// トランザクションのためinsertしか行わない。更新はしない
		InvestmentTransactionData investmentData = new InvestmentTransactionData();

		// InsertまたはUpdate
		// ※同一の主キーのデータがあればUpdate、無ければInsertとなる
		investmentData.shopid = shopId;
		investmentData.machineid = machineId;
		investmentData.machinenumber = machineNumber;
		investmentData.investment = investment;
		investmentData.collectionmoney = collection;
		investmentTransaction.Update(investmentData);
		return true;
	}

	/// <summary>
	/// マシン詳細テーブルの登録／更新
	/// </summary>
	/// <param name="id"></param>
	/// <param name="name"></param>
	/// <returns></returns>
	public bool InsertMachineReferenceTransaction(int shopId, int machineId , int rank, int gameNum)
	{
		// 以下は実際に使用する時の使い方の例
		MyDatabase db = MyDatabase.Instance;

		// データベースのテーブルを取得
		MachineReferenceTransactionTable MachineReferenceTransaction = db.GetMachineReferenceTransactionTable();
		// トランザクションのためinsertしか行わない。更新はしない
		MachineReferenceTransactionData MachineReferenceData = new MachineReferenceTransactionData();

		// InsertまたはUpdate
		// ※同一の主キーのデータがあればUpdate、無ければInsertとなる
		MachineReferenceData.id = shopId;
		MachineReferenceData.machineid = machineId;
		MachineReferenceData.rank = rank;
		MachineReferenceData.gamenum= gameNum;
		MachineReferenceTransaction.Update(MachineReferenceData);
		return true;
	}

}
