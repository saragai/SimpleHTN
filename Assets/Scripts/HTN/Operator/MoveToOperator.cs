using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HTN.Operator
{
    [CreateAssetMenu(fileName = "move_to_operator.asset", menuName = "Operator/Move To", order = 0)]
    public class MoveToOperator : Operator
    {
        [SerializeField] PlaceManager.PLACE m_Place;
        [SerializeField] float m_Velocity = 1f;

        public override IEnumerator Execute(IOperatable operatable)
        {
            var targetPos = PlaceManager.GetPosition(m_Place);

            while (true)
            {
                var transform = operatable.Transform;
                var dir = targetPos - (Vector2)transform.position;

                if (dir.magnitude < 0.1f)
                {
                    yield break;
                }

                dir.Normalize();

                // ������
                transform.position += (Vector3)(m_Velocity * dir * Time.deltaTime);
                yield return null;
            }
        }
    }
}
