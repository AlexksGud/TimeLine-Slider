using UnityEngine;

public abstract class Content : MonoBehaviour
{
    [Header("Sector of appereance")]
    [SerializeField]
    protected float minShowSector;

    [SerializeField]
    protected float maxShowSector;

    [SerializeField, Tooltip("Value when hiding starts")]
    protected float minHideSector; 

    [SerializeField, Tooltip("Value when hiding ends")]
    protected float maxHideSector;

    protected HorizontalTimeline _slider;
    protected float _sliderValue;


    /// <summary>
    /// Call in awake
    /// </summary>
    protected abstract void Init();
    protected abstract void Show();
    protected abstract void Hide();
    protected virtual bool IsFar()
    {
        var x = transform.position.x;
        return x > 100 || x < -100;
    }

    protected virtual bool InShowRange()
    {
        var x = transform.position.x;
        return (x <= minShowSector&& x>0) || (x < 0 && x>maxShowSector);
    }
    protected virtual bool InHideRange()
    {
        var x = transform.position.x;
        return (x > minHideSector && x > 0) || (x < 0 && x < maxHideSector);
    }


}
