using UnityEngine;

public class HeaderFollowController : MonoBehaviour
{
    [SerializeField] private HeaderPoint_ITL _currentPoint;

    public void GetHeader(HeaderPoint_ITL header)
    {
         _currentPoint?.StopFollow();
         header.Header.StartFollow();

        _currentPoint = header;

    }   

}
