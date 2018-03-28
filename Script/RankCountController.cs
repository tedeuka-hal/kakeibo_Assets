using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class RankCountController : MonoBehaviour {

    [SerializeField] private Text m_RankProbability;
    [SerializeField] private Text m_RankAllCount;
    [SerializeField] private Button m_BonusButton;

    public int TotalRankCount { get; private set; } = 0;    // 子役カウント
    public int TotalGameCount { private get; set; } = 0;    // 総ゲーム数
    public UnityAction CountAction;                         // 子役カウントコールバック
    public UnityAction BonusAction;                         // ボーナスコールバック

    // Use this for initialization
    void Start () {
        string zero = "0";
        m_RankAllCount.text = zero;
        m_RankProbability.text = zero;
    }
	
    /// <summary>
    /// 初期化処理
    /// </summary>
    /// <param name="count">子役カウントアップ時のコールバック</param>
    /// <param name="bonus">ボーナスカウントアップ時のコールバック</param>
    /// <param name="viewBonus">ボーナスボタン表示可否</param>
    public void Initialize(UnityAction count, UnityAction bonus, bool viewBonus)
    {
        CountAction = count;
        BonusAction = bonus;
        m_BonusButton.gameObject.SetActive(viewBonus);
    }

    /// <summary>
    /// 子役カウントアップ
    /// </summary>
    public void OnClickCountUp()
    {
        TotalRankCount++;
        m_RankAllCount.text = TotalRankCount.ToString();
        ProbabilityCalculation();
    }

    /// <summary>
    /// ボーナスカウントアップ
    /// </summary>
    public void OnClickBonusCountUp()
    {
        BonusAction?.Invoke();
    }

    /// <summary>
    /// 確率計算
    /// </summary>
    public void ProbabilityCalculation()
    {
        CountAction?.Invoke();
        if (TotalRankCount <= 0) return;
        float probability = TotalGameCount >0 ? TotalGameCount / TotalRankCount : 0;
        m_RankProbability.text = "1/" + probability.ToString();
    }
}
