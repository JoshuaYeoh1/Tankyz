using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraCinemachine : MonoBehaviour
{
    [HideInInspector] public CinemachineVirtualCamera cm;
    [HideInInspector] public Transform follow;
    [HideInInspector] public float defaultSize, currentSize;
    CinemachineBasicMultiChannelPerlin cbmcp;
    float defaultAmplitude, defaultFrequency;
    public float shakeAmplitude=2, shakeFrequency=2;

    void Awake()
    {
        cm=GetComponent<CinemachineVirtualCamera>();
        follow = new GameObject().transform;
        follow.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        cm.Follow = follow;

        cbmcp = cm.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        defaultAmplitude = cbmcp.m_AmplitudeGain;
        defaultFrequency = cbmcp.m_FrequencyGain;

        defaultSize=currentSize=cm.m_Lens.OrthographicSize;
    }

    void FixedUpdate()
    {
        if(Singleton.instance.cameraFollow) follow.position = Singleton.instance.playerPos;

        if(currentSize!=cm.m_Lens.OrthographicSize) currentSize=cm.m_Lens.OrthographicSize;
    }

    int camMoveLt=0;
    public void moveCam(Vector3 newPos, float time)
    {
        cancelMoveCam();
        camMoveLt = follow.LeanMove(newPos, time).setEaseInOutSine().id;
    }
    public void cancelMoveCam()
    {
        LeanTween.cancel(camMoveLt);
    }

    int camSizeLt=0;
    public void changeCamSize(float newCamSize, float time)
    {
        cancelCamSize();
        camSizeLt = LeanTween.value(cm.m_Lens.OrthographicSize, newCamSize, time).setEaseInOutSine().setOnUpdate(TweenUpdate).id;

        //Singleton.instance.playSFX(Singleton.instance.sfxCamPan, transform, false);
    }
    void TweenUpdate(float value)
    {
        cm.m_Lens.OrthographicSize = value;
    }
    public void cancelCamSize()
    {
        LeanTween.cancel(camSizeLt);
    }

    public void doShake(bool toggle=true)
    {
        if(toggle)
        {
            cbmcp.m_AmplitudeGain = shakeAmplitude;
            cbmcp.m_FrequencyGain = shakeFrequency;
        }
        else
        {
            cbmcp.m_AmplitudeGain = defaultAmplitude;
            cbmcp.m_FrequencyGain = defaultFrequency;
        }
    }
    
    Coroutine shakeRt;
    public void shake(float time)
    {
        if(shakeRt!=null) StopCoroutine(shakeRt);
        shakeRt=StartCoroutine(shaking(time));
    }
    IEnumerator shaking(float time)
    {
        doShake(true);
        yield return new WaitForSecondsRealtime(time);
        doShake(false);
    }
}
