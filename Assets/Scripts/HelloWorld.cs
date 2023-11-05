using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    [SerializeField] private string message;
    // Start is called before the first frame update
    void Start()
    {
        print($"{message}");
    }
    private void Update()
    {
        print($"{message}");
    }
}
