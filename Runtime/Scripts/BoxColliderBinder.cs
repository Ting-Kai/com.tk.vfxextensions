using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

[VFXBinder("Custom/BoxCollider")]
public class BoxColliderBinder : VFXBinderBase
{
    public Collider collider;

    //[VFXPropertyBinding("System.Single")]
    public ExposedProperty vfxBoxProperty = "Box";

    public override bool IsValid(VisualEffect component)
    {
        return (collider != null
        && component.HasVector3(vfxBoxProperty + "_center")
        && component.HasVector3(vfxBoxProperty + "_size"));
    }
    public override void UpdateBinding(VisualEffect component)
    {
        component.SetVector3(vfxBoxProperty + "_center", collider.bounds.center);
        component.SetVector3(vfxBoxProperty + "_size", collider.bounds.size);
    }
}
