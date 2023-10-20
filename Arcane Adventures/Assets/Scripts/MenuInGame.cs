using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInGame : MonoBehaviour
{
    public GameObject menuCanvas; // ������ �� ��� ��������� ����

    private void Start()
    {
        // �� ��������� �������� ����
        menuCanvas.SetActive(false);
    }

    private void Update()
    {
        // ��� ������� ������� "Esc" ����������/�������� ����
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuCanvas.activeSelf)
            {
                // ���� ��� ������������, �������� ���
                menuCanvas.SetActive(false);
            }
            else
            {
                // ���� �� ������������, ��������� ���
                menuCanvas.SetActive(true);
            }
        }
    }
}
