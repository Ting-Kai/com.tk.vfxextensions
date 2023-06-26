using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

[VFXBinder("Custum/DepthBinder")]
public class DepthBinder : VFXBinderBase
{
    public CalaculBound calaculBound;

    [SerializeField, VFXPropertyBinding("System.Single")]
    ExposedProperty depthName = "depth";

    [SerializeField, VFXPropertyBinding("UnityEngine.Vector2")]
    ExposedProperty rezName = "rez";

    public override bool IsValid(VisualEffect component)
    {
        return (calaculBound != null
        && component.HasFloat(depthName)
        && component.HasVector2(rezName));
    }
    public override void UpdateBinding(VisualEffect component)
    {
        component.SetFloat(depthName, calaculBound.depth);
        component.SetVector2(rezName, calaculBound.rez);
    }
}
