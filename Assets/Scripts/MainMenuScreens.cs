using UnityEngine;
using UnityEngine.Events;

public class MainMenuScreens : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onStarGame;

    private void Start()
    {
        onStarGame?.Invoke();
    }
    //Activa una pantalla
    public void ShowScreen(GameObject screen)
    {
        screen.SetActive(true);
    }

   //Desactiva una pantalla
    public void HideScreen(GameObject screen)
    {
        screen.SetActive(false);
    } 
}
