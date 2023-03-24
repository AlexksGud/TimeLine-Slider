using UnityEngine;

public class HeaderPoint_ITL : ContentInTimeLine
{
    [SerializeField] private HeaderFollow _header;

    private HeaderFollowController _controller;
    private bool _follow;

    public HeaderFollow Header => _header;
    private void Awake()
    {
        _controller = GameObject.FindGameObjectWithTag("HeaderControll")
                                .GetComponent<HeaderFollowController>();
    }
    private void Update()
    {
        if (IsFar() || _follow)
            return;

        if (InShowRange())
            Show();
    }
    protected override void Show()
    {
        _follow = true;
        _controller.GetHeader(this);
    }
    public void StopFollow()
    {
        _follow = false;
        _header.StopFollow();
    }

   
}
