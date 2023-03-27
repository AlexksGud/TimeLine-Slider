using UnityEngine;

public class HeaderFollowController : MonoBehaviour
{
    [SerializeField] private HeaderPoint_ITL _currentPoint;

    // этот метод тебе будет нужен при создании нижней навигации 
    public void GetHeader(HeaderPoint_ITL header)
    {
         _currentPoint?.StopFollow();
         header.Header.StartFollow();

        _currentPoint = header;

    }   

    

}
