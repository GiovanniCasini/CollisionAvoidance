using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class PostProcessingManager : MonoBehaviour
{
    public Volume volume;
    private float vignetteValue;
    private float cAberrValue;
    private float lensDValue;
    private float motBValue;
    private float cAdjValue;

    // Start is called before the first frame update
    void Start()
    {
        if (volume.profile.TryGet<Vignette>(out Vignette vignette))
        {
            vignetteValue = vignette.intensity.value;
        }
        if (volume.profile.TryGet<ChromaticAberration>(out ChromaticAberration cAberr))
        {
            cAberrValue = cAberr.intensity.value;
        }
        if (volume.profile.TryGet<LensDistortion>(out LensDistortion lensD))
        {
            lensDValue = lensD.intensity.value;
        }
        if (volume.profile.TryGet<MotionBlur>(out MotionBlur motB))
        {
            motBValue = motB.intensity.value;
        }
        if (volume.profile.TryGet<ColorAdjustments>(out ColorAdjustments cAdj))
        {
            cAdjValue = cAdj.hueShift.value;
        }
    }
    
    public void GodMode(float duration)
    {
        //StopAllCoroutines();
        //StartCoroutine(GodModeCountdown(duration));
       if(volume.profile.TryGet<Vignette>(out Vignette vignette))
       {
            vignette.intensity.value = 0.48f;
       }
       if (volume.profile.TryGet<ChromaticAberration>(out ChromaticAberration cAberr))
       {
            cAberr.intensity.value = 1f;
       }
       if (volume.profile.TryGet<LensDistortion>(out LensDistortion lensD))
       {
            lensD.intensity.value = -0.25f;
       }
       if (volume.profile.TryGet<MotionBlur>(out MotionBlur motB))
       {
            motB.intensity.value = 0.4f;
       }
       if (volume.profile.TryGet<ColorAdjustments>(out ColorAdjustments cAdj))
       {
            cAdj.hueShift.value = 30f;
       }
    }

    /*IEnumerator GodModeCountdown(float duration)
    {
        float timePassed = 0.0f;
        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;
            yield return null;
        }
        ResetValues();
    }
    */

    public void ResetValues()
    {
        if (volume.profile.TryGet<Vignette>(out Vignette vignette))
        {
            vignette.intensity.value = vignetteValue;
        }
        if (volume.profile.TryGet<ChromaticAberration>(out ChromaticAberration cAberr))
        {
            cAberr.intensity.value = cAberrValue;
        }
        if (volume.profile.TryGet<LensDistortion>(out LensDistortion lensD))
        {
            lensD.intensity.value = lensDValue;
        }
        if (volume.profile.TryGet<MotionBlur>(out MotionBlur motB))
        {
            motB.intensity.value = motBValue;
        }
        if (volume.profile.TryGet<ColorAdjustments>(out ColorAdjustments cAdj))
        {
            cAdj.hueShift.value = cAdjValue;
        }
    }
}
