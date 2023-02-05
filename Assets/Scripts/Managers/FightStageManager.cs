using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FightStageManager : MonoBehaviour
{
    [SerializeField]
    Transform[] spawnPos = new Transform[2];

    [SerializeField]
    Image[] characterUIImages;

    [SerializeField]
    List<GameObject> fighters = new List<GameObject>();//root toot shoot

    [SerializeField]
    List<Fighters> fighterEnum = new List<Fighters>();


    [Tooltip("Order is Root Toot Shoot")] [SerializeField]
    Sprite[] characterSprites;

    [SerializeField]
    Dictionary<Fighters, GameObject> fighterList = new Dictionary<Fighters, GameObject>();

    [SerializeField] CameraScreenShake ScreenShake;

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
                characterUIImages[i].sprite = characterSprites[(int)PersistentInputHolder.Instance.GetInputs()[i]];

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

    public void ResetPositionToSpawnPoint(FighterCore core)
    {
        core.transform.position = spawnPos[core.GetPlayerNum() - 1].position;
    }

    public void ScreenShakeSmall()
    {
        ScreenShake.ScreenShakeSmall();
    }

    public void ScreenShakeBig()
    {
        ScreenShake.ScreenShakeBig();
    }
}
