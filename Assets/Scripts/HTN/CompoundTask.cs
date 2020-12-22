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
                // ���s����^�X�N��������
                if (!method.Match(state))
                {
                    continue;
                }

                // ���݂�plan��ۑ�
                var currentPlan = new Plan(plan);

                // �T�u�^�X�N���s��
                if (!method.TryPlanSubTasks(state, ref plan))
                {
                    // ���s�����Ƃ�plan�����ɖ߂�
                    plan = currentPlan;
                    continue;
                }

                // �T�u�^�X�N���S�Ċ��������̂Ő���
                return true;
            }

            // �����𖞂������\�b�h���Ȃ������̂Ŏ��s
            return false;
        }
    }
}
