using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InputBonusGameNum : MonoBehaviour {

	[SerializeField]
	private Button m_RegistButton;
	[SerializeField]
	private DataBaseController m_DatabaseController;
	[SerializeField]
	private InputField m_GameNum;

	/// <summary>
	/// ゲーム数登録ボタン
	/// </summary>
	public void OnClickRegistButton()
	{
		m_DatabaseController.InsertMachineReferenceTransaction(0, 0, 0, 0);
	}
		
	/// <summary>
	/// ゲーム数+1クリック時
	/// </summary>
	public void OnClickAddGameNum1()
	{
		Debug.Log(int.Parse(m_GameNum.text) + 1);
		m_GameNum.text =   (int.Parse(m_GameNum.text) + 1).ToString();
	}

	/// <summary>
	/// ゲーム数+5クリック時
	/// </summary>
	public void OnClickAddGameNum5()
	{
		m_GameNum.text = (int.Parse(m_GameNum.text) + 5).ToString();
	}

	/// <summary>
	/// ゲーム数+10クリック時
	/// </summary>
	public void OnClickAddGameNum10()
	{
		m_GameNum.text = (int.Parse(m_GameNum.text) + 10).ToString();
	}

	/// <summary>
	/// ゲーム数+50クリック時
	/// </summary>
	public void OnClickAddGameNum50()
	{
		m_GameNum.text = (int.Parse(m_GameNum.text) + 50).ToString();
	}

	/// <summary>
	/// ゲーム数+100クリック時
	/// </summary>
	public void OnClickAddGameNum100()
	{
		m_GameNum.text = (int.Parse(m_GameNum.text) + 100).ToString();
	}

	/// <summary>
	/// ゲーム数+500クリック時
	/// </summary>
	public void OnClickAddGameNum500()
	{
		m_GameNum.text = (int.Parse(m_GameNum.text) + 500).ToString();
	}
}
