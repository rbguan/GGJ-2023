using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockOutProjectileScript : MonoBehaviour
{

    [SerializeField]
    float timeTillKill;
    [SerializeField]
    float speed;
    Vector3 dir;
    private void Awake()
    {
        StartCoroutine(DestoryGame());
    }


    private IEnumerator DestoryGame()
    {
        yield return new WaitForSeconds(timeTillKill);
        Destroy(this.gameObject);
    }

    public void InitKillObj(Vector3 side)
    {
        dir = side;
    }

    private void Update()
    {
        transform.position += (dir * speed) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
                //Vector2 hitBoxPos = UtilityFunctionLibrary.GetVec3AsVec2(hitBox.transform.position);              
                other.gameObject.GetComponent<FighterCore>().KnockOut();
            Destroy(this.gameObject);
                Debug.Log("kill");
            }
        }
}

