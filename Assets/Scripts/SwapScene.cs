using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScene : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int a;

    public void SwapTo()
    {
        SceneManager.LoadScene(a);
    } 

    //public void SwapNext() { SceneManager.LoadScene()}
}
