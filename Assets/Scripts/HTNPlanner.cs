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

        foreach (var @operator in m_PlanList)
        {
            Debug.Log(@operator.OperatorName);
        }
        Debug.Log(tmpState);

        return m_PlanList;
    }
}
