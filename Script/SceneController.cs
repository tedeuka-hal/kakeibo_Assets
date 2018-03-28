using UnityEngine;

public class SceneController : MonoBehaviour {

    [SerializeField] private PopupController m_PopupController;
    [SerializeField] private InputAmusementmachineController m_AmusumentMachineController;

    private int m_AllGameCount      = 0;    // 総ゲーム数

    public int AllGameCount
    {
        get { return GameCount > 0 ? GameCount : 0; }
        set { m_AllGameCount = value; }
    }

    private int GameCount
    {
        get { return (m_AllGameCount - StartGameCount); }
    }

    public int StartGameCount { get { return m_PopupController.GetStartGameNum; } }

	// Use this for initialization
	void Start () {
        m_PopupController.StartPopupActive(true,()=>
        {
            m_AmusumentMachineController.SetGameCount(StartGameCount);
        });
	}
	
    public void UpdateGameCount(int count)
    {
        m_AllGameCount += count;
    }

    public void OpenBonusPopup()
    {
        m_PopupController.BonusPopupActive(true);
    }
}