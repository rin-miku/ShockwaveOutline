using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ShockwaveOutlineRendererFeature : ScriptableRendererFeature
{
    public ShockwaveOutlineRenderPass shockwaveOutlineRenderPass;

    public bool activeEffect = false;
    public Material shockwaveOutlineMaterial;

    public override void Create()
    {
        shockwaveOutlineRenderPass = new ShockwaveOutlineRenderPass(shockwaveOutlineMaterial);
        shockwaveOutlineRenderPass.renderPassEvent = RenderPassEvent.AfterRenderingTransparents;
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        if (activeEffect)
        {
            renderer.EnqueuePass(shockwaveOutlineRenderPass);
        }
    }
}
