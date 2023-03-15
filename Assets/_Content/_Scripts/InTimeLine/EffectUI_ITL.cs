using Coffee.UIExtensions;
using UnityEngine;

[RequireComponent(typeof(UITransitionEffect))]
public class EffectUI_ITL : ContentInTimeLine
{
    private UITransitionEffect _effectController;
    private void Awake()
    {
        Init();
        _effectController = GetComponent<UITransitionEffect>();

    }
    private void Update()
    {

        if (IsFar())
            return;

        if (InShowRange())
            Show();

        if (InHideRange())
            Hide();
    }
    protected override void Show()
    {
       if(_effectController.effectFactor==0f)
            _effectController.Show(false);  

    }
    protected override void Hide()
    {
        if (_effectController.effectFactor == 1f)
            _effectController.Hide(false);
    }

}

