using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackComponent : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    private bool _isInKnockback;
    public bool IsInKnockback
    {
        get
        {
            return _isInKnockback;
        }
        set { }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyKnockback(Vector2 force, float time)
    {
        rb.AddForce(force);
        KnockbackTimer(time);
    }

    private IEnumerator KnockbackTimer(float time)
    {
        _isInKnockback = true;
        yield return new WaitForSeconds(time);
        _isInKnockback = false;
    }
}
