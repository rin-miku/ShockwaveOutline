using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.RenderGraphModule.Util;
using UnityEngine.Rendering.Universal;
using static UnityEngine.Rendering.RenderGraphModule.Util.RenderGraphUtils;

public class ShockwaveOutlineRenderPass : ScriptableRenderPass
{
    private Material shockwaveOutlineMaterial;

    public ShockwaveOutlineRenderPass(Material shockwaveOutlineMat)
    {
        shockwaveOutlineMaterial = shockwaveOutlineMat;
    }

    public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
    {
        UniversalCameraData cameraData = frameData.Get<UniversalCameraData>();
        UniversalResourceData resourceData = frameData.Get<UniversalResourceData>();

        var desc = cameraData.cameraTargetDescriptor;
        desc.depthStencilFormat = GraphicsFormat.None;
        desc.msaaSamples = 1;
        desc.graphicsFormat = GraphicsFormat.R16G16B16A16_SFloat;

        TextureHandle cameraColor = resourceData.activeColorTexture;
        TextureHandle tempColor = UniversalRenderer.CreateRenderGraphTexture(renderGraph, desc, "_ShockwaveOutline", true);

        BlitMaterialParameters blitParams = new BlitMaterialParameters(cameraColor, tempColor, shockwaveOutlineMaterial, 0);
        renderGraph.AddBlitPass(blitParams, "Shockwave Outline");
        resourceData.cameraColor = tempColor;
    }
}
