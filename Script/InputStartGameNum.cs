using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InputStartGameNum : MonoBehaviour {

	[SerializeField]
	private Button m_RegistButton;
	[SerializeField]
	private DataBaseController m_DatabaseController;
    [SerializeField]
    private PopupController m_PopupController;
	[SerializeField]
	private InputField m_GameNum;

    private int m_GameCount = 0;
    public System.Action m_OnClickAction { get; set; }
    public int GameNum
    {
        get { return m_GameCount; }
        set {
            m_GameCount = value >= 0 ? value : 0;
        }
    }
	
	/// <summary>
	/// ゲーム数登録ボタン
	/// </summary>
	public void OnClickRegistButton()
	{
        GameNum = int.Parse(m_GameNum.text);
        m_OnClickAction?.Invoke();
        m_PopupController.StartPopupActive(false);

    }
	/// <summary>
	/// ゲーム数+1クリック時
	/// </summary>
	public void OnClickAddGameNum1()
	{
		Debug.Log(int.Parse(m_GameNum.text) + 1);
        m_GameNum.text = AddGameCountToString(1);
    }
	/// <summary>
	/// ゲーム数+5クリック時
	/// </summary>
	public void OnClickAddGameNum5()
	{
        m_GameNum.text = AddGameCountToString(5);
    }
	/// <summary>
	/// ゲーム数+10クリック時
	/// </summary>
	public void OnClickAddGameNum10()
	{
        m_GameNum.text = AddGameCountToString(10);
    }
	/// <summary>
	/// ゲーム数+50クリック時
	/// </summary>
	public void OnClickAddGameNum50()
	{
        m_GameNum.text = AddGameCountToString(50);
    }
	/// <summary>
	/// ゲーム数+100クリック時
	/// </summary>
	public void OnClickAddGameNum100()
	{
        m_GameNum.text = AddGameCountToString(100);
    }
	/// <summary>
	/// ゲーム数+500クリック時
	/// </summary>
	public void OnClickAddGameNum500()
	{
        m_GameNum.text = AddGameCountToString(500);

    }

    public void ResetStartGame()
    {
        GameNum = 0;
        m_GameNum.text = GameNum.ToString(); 
    }

    private string AddGameCountToString(int num)
    {
        GameNum += num;
        return GameNum.ToString();
    }
        
    public void OnEditEnd()
    {
        GameNum = int.Parse(m_GameNum.text);
    }
}
