using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HTN
{
    /// <summary>
    /// 世界の状態
    /// </summary>
    [System.Serializable]
    public class WorldState
    {
        /// <summary>
        /// 状態の種類
        /// </summary>
        public enum TYPE
        {
            IsHungry,
            HaveMoney,
            HaveMeal,

            MaxCount,
        }
        public static int NumStates => (int)TYPE.MaxCount;

        [SerializeField]
        private bool[] m_States;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public WorldState()
        {
            m_States = new bool[(int)TYPE.MaxCount];
        }

        /// <summary>
        /// 種類と値を指定して状態を設定
        /// </summary>
        /// <param name="type">種類</param>
        /// <param name="value">値</param>
        public void Set(TYPE type, bool value)
        {
            m_States[(int)type] = value;
        }

        /// <summary>
        /// 種類を指定して状態の値を取得
        /// </summary>
        /// <param name="type">種類</param>
        /// <returns>値</returns>
        public bool Get(TYPE type)
        {
            return m_States[(int)type];
        }

        /// <summary>
        /// 自身を複製する
        /// </summary>
        /// <returns>自身の複製</returns>
        public WorldState CreateCopy()
        {
            var copy = new WorldState();
            for (int i = 0; i < NumStates; i++)
            {
                copy.m_States[i] = m_States[i];
            }
            return copy;
        }

        public override string ToString()
        {
            string text = "";
            for (int i = 0; i < NumStates; i++)
            {
                text += $"{(TYPE)i}: {m_States[i]}\n";
            }
            return text;
        }

#if UNITY_EDITOR
        public static string StatesName => nameof(m_States);
#endif 
    }
}

#if UNITY_EDITOR
namespace HTN.Editor
{
    using UnityEditor;

    /// <summary>
    /// WorldStateのエディタ拡張
    /// </summary>
    [CustomPropertyDrawer(typeof(WorldState))]
    public class WorldStateDrawer : PropertyDrawer
    {
        static float LineHeight => EditorGUIUtility.singleLineHeight;
        static float Spacing => EditorGUIUtility.standardVerticalSpacing;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // 複数選択しているときは何もしない
            if (property.hasMultipleDifferentValues)
                return;

            position.height = LineHeight;
            EditorGUI.LabelField(position, label);
            position.y += LineHeight + Spacing;

            EditorGUI.indentLevel++;
            {
                DrawContent();
            }
            EditorGUI.indentLevel--;

            return;

            // WorldStateの内容を描画
            void DrawContent()
            {
                var statesProperty = property.FindPropertyRelative(WorldState.StatesName);

                for (int i = 0; i < WorldState.NumStates; i++)
                {
                    var stateProperty = statesProperty.GetArrayElementAtIndex(i);
                    var stateLabel = ((WorldState.TYPE)i).ToString();

                    stateProperty.boolValue = EditorGUI.Toggle(position, stateLabel, stateProperty.boolValue);

                    position.y += LineHeight + Spacing;
                }
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            //複数選択しているときはなにもしない
            if (property.hasMultipleDifferentValues)
                return 0f;

            var numState = (int)WorldState.TYPE.MaxCount + 1;
            return (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing) * numState;
        }
    }
}
#endif 


