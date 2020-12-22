using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HTN;

/// <summary>
/// HTNによって行動のプランニングをする
/// </summary>
public class HTNPlanner : MonoBehaviour
{
    [SerializeField]
    WorldStateHolder m_WorldStateHolder;

    Plan m_Plan;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Awake()
    {
        m_Plan = new Plan();
    }

    /// <summary>
    /// プランニングする
    /// </summary>
    /// <param name="rootTask">大元のタスク</param>
    public Plan DoPlan(ITask rootTask)
    {
        m_Plan.Clear();

        // WorldStateのコピーを取って自由に書き換えられるようにする
        var tmpState = m_WorldStateHolder.WorldState.CreateCopy();
        rootTask.TryPlanTask(tmpState, ref m_Plan);

        Log();

        return m_Plan;
    }

    [SerializeField] UnityEngine.UI.Text m_Text;
    /// <summary>
    /// プランニングを出力
    /// </summary>
    private void Log()
    {
        string str = "プラン： ";

        foreach (var @operator in m_Plan.Operators)
        {
            str += @operator.OperatorName + " → ";
        }
        str += "END";

        m_Text.text = str;
    }
}
