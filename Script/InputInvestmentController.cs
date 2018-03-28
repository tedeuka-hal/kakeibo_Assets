using UnityEngine;
using System.Collections;
using System.Text;
using UnityEngine.UI;

public class InputInvestmentController : MonoBehaviour
{

	[SerializeField]
	private Dropdown m_ShopDrowDown;
	[SerializeField]
	private Text m_MachineIdText;
	[SerializeField]
	private Text m_MachineNumberText;
	[SerializeField]
	private Text m_InvestmentText;
	[SerializeField]
	private Text m_CollectionText;
	[SerializeField]
	private DataBaseController m_DatabaseController;
    
	private const string NEWSHOPDATASTRING = "新規登録";

    public Vector2 scrollPosition;

    public int ShopId
	{
		get { return m_ShopDrowDown.value - 1; }
	}

	public int MachineId
	{
		get { return int.Parse(m_MachineIdText.text); }
	}

	public int MachineNumber
	{
		get { return int.Parse(m_MachineNumberText.text); }
	}
	public int Investment
	{
		get { return int.Parse(m_InvestmentText.text); }
	}
	public int Collection
	{
		get { return int.Parse(m_CollectionText.text); }
	}

	// Use this for initialization
	void Start()
	{
		print(Application.persistentDataPath);
		Dropdown.OptionData registOption = new Dropdown.OptionData { text = NEWSHOPDATASTRING };	// 新規登録を追加
		m_ShopDrowDown.options.Add(registOption);

		foreach (ShopMasterData shopdata in m_DatabaseController.SelectShopMaster())
		{ 
			registOption = new Dropdown.OptionData {text = shopdata.ShopName};
			m_ShopDrowDown.options.Add(registOption);
		}
    }

	// Update is called once per frame
	void Update()
	{

	}

	/// <summary>
	/// 登録ボタン押下時
	/// </summary>
	public void OnClickRegist()
	{
		m_DatabaseController.InsertUpdateInvestmentTransaction(ShopId,MachineId, MachineNumber, Investment, Collection);
		foreach(InvestmentTransactionData dt in m_DatabaseController.SelectInvestmentTransaction())
		{
			Debug.Log("登録されているデータ：" + dt.id);
		}
	}

}
