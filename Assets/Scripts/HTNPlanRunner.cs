using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HTN;

/// <summary>
/// HTN
/// </summary>
public class HTNPlanRunner : MonoBehaviour
{
    [SerializeField] HTNPlanner m_Planner;
    [SerializeField] Operatable m_Operatable;

    [SerializeField] Task m_Task;

    // Start is called before the first frame update
    void Start()
    {
        SetTask(m_Task);
    }

    public void SetTask(ITask task)
    {
        var plan = m_Planner.Plan(task);
        StartCoroutine(Execute(plan));
    }

    IEnumerator Execute(IEnumerable<IOperator> operators)
    {
        foreach(var @operator in operators)
        {
            yield return StartCoroutine(Execute(@operator));
        }
    }

    IEnumerator Execute(IOperator @operator)
    {
        yield return StartCoroutine(@operator.Execute(m_Operatable));
    }
}
