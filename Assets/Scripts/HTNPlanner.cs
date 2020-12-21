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

    Plan m_PlanList;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Awake()
    {
        m_PlanList = new Plan();
    }

    /// <summary>
    /// プランニングする
    /// </summary>
    /// <param name="rootTask">大元のタスク</param>
    public Plan Plan(ITask rootTask)
    {
        m_PlanList.Clear();
        var tmpState = m_WorldStateHolder.WorldState.CreateCopy();

        rootTask.TryPlanTask(tmpState, ref m_PlanList);

        Log();

        return m_PlanList;
    }

    [SerializeField] UnityEngine.UI.Text m_Text;
    /// <summary>
    /// プランニングを出力
    /// </summary>
    private void Log()
    {
        string str = "プラン： ";

        foreach (var @operator in m_PlanList.Operators)
        {
            str += @operator.OperatorName + " → ";
        }
        str += "END";

        m_Text.text = str;
    }
}
