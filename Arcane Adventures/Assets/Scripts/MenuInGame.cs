using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInGame : MonoBehaviour
{
    public GameObject menuCanvas; // Ссылка на ваш интерфейс меню

    private void Start()
    {
        // По умолчанию скрываем меню
        menuCanvas.SetActive(false);
    }

    private void Update()
    {
        // При нажатии клавиши "Esc" отображаем/скрываем меню
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuCanvas.activeSelf)
            {
                // Меню уже отображается, скрываем его
                menuCanvas.SetActive(false);
            }
            else
            {
                // Меню не отображается, открываем его
                menuCanvas.SetActive(true);
            }
        }
    }
}
