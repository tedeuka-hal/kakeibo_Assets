using UnityEngine;

public class SceneController : MonoBehaviour {

    [SerializeField] private PopupController m_PopupController;

    private int m_AllGameCount      = 0;    // 総ゲーム数

    public int AllGameCount
    { get { return m_AllGameCount; } }

    public int StartGameCount { get; set; }

	// Use this for initialization
	void Start () {
        m_PopupController.StartPopupActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	}

    // 総ゲーム数カウント
    public void UpdateGameCount(int count)
    {
        m_AllGameCount += count;
    }
}
