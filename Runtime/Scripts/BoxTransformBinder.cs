using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

[VFXBinder("Custom/BoxTransform")]
public class BoxTransformBinder : VFXBinderBase
{
    public Transform transform;

    //[VFXPropertyBinding("System.Single")]
    public ExposedProperty vfxTransformProperty = "PropertyName";

    public override bool IsValid(VisualEffect component)
    {
        return (transform != null
        && component.HasVector3(vfxTransformProperty + "_position")
        && component.HasVector3(vfxTransformProperty + "_angles")
        && component.HasVector3(vfxTransformProperty + "_scale"));
    }
    public override void UpdateBinding(VisualEffect component)
    {
        component.SetVector3(vfxTransformProperty + "_position", transform.position);
        component.SetVector3(vfxTransformProperty + "_angles", transform.eulerAngles);
        component.SetVector3(vfxTransformProperty + "_scale", transform.lossyScale);
    }
}
