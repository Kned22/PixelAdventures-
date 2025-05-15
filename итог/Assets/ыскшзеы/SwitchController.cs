using UnityEngine;

public class SwitchController : MonoBehaviour
{
    // Перечисление для хранения текущей схемы управления
    public enum ControlScheme { WASD, Arrows }
    private static ControlScheme currentScheme = ControlScheme.WASD; // По умолчанию WASD3

    private void Awake()
    {
        // Убедитесь, что объект UI_Manager не уничтожается при загрузке новой сцены
        DontDestroyOnLoad(gameObject);

        // Если уже есть другой объект с этим скриптом, уничтожьте его
        if (FindObjectsOfType<SwitchController>().Length > 1)
        {
            Destroy(gameObject);
        }
    }

    // Метод для установки управления на WASD
    public void SetWASDControl()
    {
        currentScheme = ControlScheme.WASD;
        Debug.Log("Управление переключено на WASD");
    }

    // Метод для установки управления на стрелочки
    public void SetArrowsControl()
    {
        currentScheme = ControlScheme.Arrows;
        Debug.Log("Управление переключено на стрелочки");
    }

    // Статический метод для получения текущей схемы управления
    public static ControlScheme GetCurrentControlScheme()
    {
        return currentScheme;
    }
}
