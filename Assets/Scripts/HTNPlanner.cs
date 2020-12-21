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

    Queue<IOperator> m_PlanList;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Awake()
    {
        m_PlanList = new Queue<IOperator>();
    }

    /// <summary>
    /// プランニングする
    /// </summary>
    /// <param name="rootTask">大元のタスク</param>
    public Queue<IOperator> Plan(ITask rootTask)
    {
        m_PlanList.Clear();
        var tmpState = m_WorldStateHolder.WorldState.CreateCopy();

        rootTask.TryPlanTask(tmpState, ref m_PlanList);

        Log();

        return m_PlanList;
    }

    /// <summary>
    /// プランニングを出力
    /// </summary>
    private void Log()
    {
        string str = "";

        foreach (var @operator in m_PlanList)
        {
            str += @operator.OperatorName + " -> ";
        }
        str += "END";

        Debug.Log(str);
    }
}
