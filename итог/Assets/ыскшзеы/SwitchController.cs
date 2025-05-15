using UnityEngine;

public class SwitchController : MonoBehaviour
{
    // ������������ ��� �������� ������� ����� ����������
    public enum ControlScheme { WASD, Arrows }
    private static ControlScheme currentScheme = ControlScheme.WASD; // �� ��������� WASD3

    private void Awake()
    {
        // ���������, ��� ������ UI_Manager �� ������������ ��� �������� ����� �����
        DontDestroyOnLoad(gameObject);

        // ���� ��� ���� ������ ������ � ���� ��������, ���������� ���
        if (FindObjectsOfType<SwitchController>().Length > 1)
        {
            Destroy(gameObject);
        }
    }

    // ����� ��� ��������� ���������� �� WASD
    public void SetWASDControl()
    {
        currentScheme = ControlScheme.WASD;
        Debug.Log("���������� ����������� �� WASD");
    }

    // ����� ��� ��������� ���������� �� ���������
    public void SetArrowsControl()
    {
        currentScheme = ControlScheme.Arrows;
        Debug.Log("���������� ����������� �� ���������");
    }

    // ����������� ����� ��� ��������� ������� ����� ����������
    public static ControlScheme GetCurrentControlScheme()
    {
        return currentScheme;
    }
}
