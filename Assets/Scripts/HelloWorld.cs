using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    [SerializeField] private string _message;
    // Start is called before the first frame update
    void Start()
    {
        print($"{_message}");
    }
    private void Update()
    {
        print($"{_message}");
    }
}
