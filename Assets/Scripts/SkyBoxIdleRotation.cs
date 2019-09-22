using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxIdleRotation : MonoBehaviour
{
    //This class rotates skybox on Update
    [SerializeField] private float _rotSpeed;
    private bool _paused = false;

    // Update is called once per frame
    void Update()
    {
        if (!_paused)
        {
            RenderSettings.skybox.SetFloat("_Rotation", Time.time * _rotSpeed);
        }
    }

    public void Pause()
    {
        _paused = true;
    }

    public void Unpause()
    {
        _paused = false;
    }
}
