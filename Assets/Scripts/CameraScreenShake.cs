using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraScreenShake : MonoBehaviour
{
    Camera _camera;

    [Header("Small Shake Params")]
    [SerializeField] float SmallTime;
    [SerializeField] float SmallStrength;
    [SerializeField] int SmallVibrato;
    [SerializeField] float SmallRandom;

    [Header("Big Shake Params")]
    [SerializeField] float BigTime;
    [SerializeField] float BigStrength;
    [SerializeField] int BigVibrato;
    [SerializeField] float BigRandom;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScreenShakeSmall()
    {
        _camera.DOShakePosition(SmallTime, SmallStrength, SmallVibrato, SmallRandom, true);
    }

    public void ScreenShakeBig()
    {
        _camera.DOShakePosition(BigTime, BigStrength, BigVibrato, BigRandom, true);
    }
}
