using DG.Tweening;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    public ShockwaveOutlineRendererFeature shockwave;
    public Material mat;
    public Transform mainCamera;

    private bool isActive = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayEffect();
        }
    }

    private void PlayEffect()
    {
        if (isActive) return;

        isActive = true;
        shockwave.activeEffect = true;

        Vector3 cameraPos = mainCamera.position;
        mat.SetFloat("_ShockWaveRadius", 0f);
        mat.SetVector("_StartPosition", cameraPos);

        DOVirtual.Float(0f, 100f, 7f, (value) => { mat.SetFloat("_ShockWaveRadius", value); })
            .OnComplete(() => { shockwave.activeEffect = false; isActive = false; });
    }
}
