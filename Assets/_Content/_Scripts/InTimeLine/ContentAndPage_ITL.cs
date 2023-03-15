using UnityEngine;
using UnityEngine.UI;

public class ContentAndPage_ITL : Animation_ITL
{
    [SerializeField] private Page _page;
    [SerializeField] private Button _butt;
    private void Start()
    {
        _butt.onClick.AddListener(() => 
        {
            _page.Show();
        });
    }
}

