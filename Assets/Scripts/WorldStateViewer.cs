using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HTN;

public class WorldStateViewer : MonoBehaviour
{
    [SerializeField] WorldStateHolder m_WorldStateHolder;
    
    [SerializeField] SpriteRenderer m_HungrySprite;
    [SerializeField] SpriteRenderer m_MealSprite;
    [SerializeField] SpriteRenderer m_MoneySprite;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var worldState = m_WorldStateHolder.WorldState;

        m_HungrySprite.gameObject.SetActive(worldState.Get(WorldState.TYPE.IsHungry));
        m_MealSprite.gameObject.SetActive(worldState.Get(WorldState.TYPE.HaveMeal));
        m_MoneySprite.gameObject.SetActive(worldState.Get(WorldState.TYPE.HaveMoney));
    }
}
