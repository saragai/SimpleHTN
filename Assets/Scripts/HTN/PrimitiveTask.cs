using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HTN
{
    [CreateAssetMenu(fileName ="primitive_task.asset", menuName = "Primitive Task", order = 0)]
    public class PrimitiveTask : Task
    {
        [SerializeField] List<Condition> m_Preconditions;
        [SerializeField] Operator.Operator m_Operator;
        [SerializeField] List<Effect> m_Effects;

        public override bool TryPlanTask(WorldState state, ref Queue<IOperator> plan)
        {
            foreach (var condition in m_Preconditions)
            {
                if (!condition.Match(state))
                    return false;
            }

            foreach(var effect in m_Effects)
                effect.ApplyTo(state);

            plan.Enqueue(m_Operator);

            return true;
        }
    }
}
