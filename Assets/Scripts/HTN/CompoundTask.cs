using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HTN
{
    [CreateAssetMenu(fileName ="compound_task.asset", menuName = "Compound Task", order = 1)]
    public class CompoundTask : Task
    {
        [SerializeField] List<Method> m_Methods;

        [System.NonSerialized]
        static int m_RecurrentCount = 0;

        /// <summary>
        /// 状態を指定して実行するOperator
        /// </summary>
        /// <param name="state"></param>
        /// <param name="plan"></param>
        /// <returns></returns>
        public override bool TryPlanTask(WorldState state, ref Queue<IOperator> plan)
        {
            // 無限再帰を防ぐ
            m_RecurrentCount++;
            //Debug.Log($"{m_RecurrentCount}: {this.name}");
            if (m_RecurrentCount > 5)
            {
                return false;
            }

            foreach (var method in m_Methods)
            {
                // 実行するタスクを見つける
                if (method.Match(state))
                {
                    // 現在のplanを保存
                    var currentPlan = new Queue<IOperator>(plan);

                    // サブタスクを行う
                    foreach (var task in method.SubTasks)
                    {
                        if (!task.TryPlanTask(state, ref plan))
                        {
                            // 失敗したときplanを元に戻す
                            plan = currentPlan;
                            return false;
                        }
                    }

                    // サブタスクが全て完了したので成功
                    return true;
                }
            }

            // 条件を満たすメソッドがなかったので失敗
            return false;
        }
    }
}
