using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightStageManager : MonoBehaviour
{
    [SerializeField]
    Transform[] spawnPos = new Transform[2];


    [SerializeField]
    List<GameObject> fighters = new List<GameObject>();//root toot shoot

    [SerializeField]
    List<Fighters> fighterEnum = new List<Fighters>();

    [SerializeField]
    Dictionary<Fighters, GameObject> fighterList = new Dictionary<Fighters, GameObject>();
    // Start is called before the first frame update
    void OnEnable()
    {
        if (CharSelectToMatchTransition.Instance != null)
            CharSelectToMatchTransition.Instance.EnterFightAnimation();


        for (int i = 0; i < fighters.Count; i++)
        {
            fighterList.Add(fighterEnum[i], fighters[i]);
        }


        if (PersistentInputHolder.Instance != null && PersistentInputHolder.Instance.MenuFighters.Count >= 2)
        {
            for (int i = 0; i < PersistentInputHolder.Instance.GetInputs().Length; i++)
            {
                GameObject newfigther = Instantiate(fighterList[PersistentInputHolder.Instance.GetInputs()[i]], spawnPos[i].position, Quaternion.identity);
                newfigther.GetComponent<FighterCore>().SetPlayerNum(i + 1);

                foreach (MenuFighterActions menuFighter in PersistentInputHolder.Instance.MenuFighters)
                {
                    if (menuFighter.GetFighterNum() == i + 1)
                    {
                        menuFighter.transform.position = spawnPos[i].position;
                        menuFighter.GetAttachedActions().SwitchCurrentActionMap("Base");
                        Debug.Log(menuFighter.GetAttachedActions().currentActionMap.name);
                    }
                }

            }
        }       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
