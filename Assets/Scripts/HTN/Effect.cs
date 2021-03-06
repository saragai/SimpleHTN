using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HTN
{
    [System.Serializable]
    public class Effect
    {
        [SerializeField] WorldState.TYPE m_Type;
        [SerializeField] bool m_Value;

        /// <summary>
        /// 状態を指定して、新たな状態を設定する
        /// </summary>
        /// <param name="state">状態</param>
        public void ApplyTo(WorldState state)
        {
            state.Set(m_Type, m_Value);
        }
    }
}
