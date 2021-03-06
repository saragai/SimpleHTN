using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HTN
{
    [CreateAssetMenu(fileName = "compound_task.asset", menuName = "Compound Task", order = 1)]
    public class CompoundTask : Task
    {
        [SerializeField] List<Method> m_Methods;

        public override bool TryPlanTask(WorldState state, ref Plan plan)
        {
            foreach (var method in m_Methods)
            {
                // 実行するタスクを見つける
                if (!method.Match(state))
                {
                    continue;
                }

                // 現在のplanを保存
                var currentPlan = new Plan(plan);

                // サブタスクを行う
                if (!method.TryPlanSubTasks(state, ref plan))
                {
                    // 失敗したときplanを元に戻す
                    plan = currentPlan;
                    continue;
                }

                // サブタスクが全て完了したので成功
                return true;
            }

            // 条件を満たすメソッドがなかったので失敗
            return false;
        }
    }
}
