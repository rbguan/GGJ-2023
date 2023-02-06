using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class FightStageManager : MonoBehaviour
{
    public static FightStageManager Instance { get; private set; }

    [SerializeField]
    Transform[] spawnPos = new Transform[2];

    [SerializeField]
    Image[] characterUIImages;

    [SerializeField]
    List<Image> p1StockItems;

    [SerializeField]
    List<Image> p2StockItems;

    [SerializeField]
    TextMeshProUGUI[] characterNames;

    [SerializeField]
    Slider[] characterHealthBar;

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
                characterNames[i].text = PersistentInputHolder.Instance.GetInputs()[i].ToString();
                if (i == 0)
                    newfigther.GetComponent<FighterCore>().SetPlayerStockBar(p1StockItems);
                if (i == 1)
                    newfigther.GetComponent<FighterCore>().SetPlayerStockBar(p2StockItems);
                newfigther.GetComponent<FighterCore>().SetPlayerHealthBar(characterHealthBar[i]);

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

    private void Awake()
    {
        Instance = this;
    }

    public void GoToVictoryScreen(FighterCore losingPlayer)
    {
        PersistentInputHolder.Instance.SetLoser(losingPlayer.GetPlayerNum());
        SceneManager.LoadScene("VictoryScene");
    }

    public void ResetPositionToSpawnPoint(FighterCore core)
    {
        Debug.Log("CALLED THE SPAWN FUN");
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
