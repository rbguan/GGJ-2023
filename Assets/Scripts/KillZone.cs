using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField] FightStageManager _stageManager;
    [SerializeField] BoxCollider2D _collider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FighterCore fighterCore = collision.gameObject.GetComponent<FighterCore>();
            fighterCore.OnKill();
            _stageManager.ResetPositionToSpawnPoint(fighterCore);
        }
    }
}
