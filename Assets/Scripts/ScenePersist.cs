using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    void Awake()
    {
        // create our singleton
        int numberScenePersists = FindObjectsByType<ScenePersist>().Length;
        if (numberScenePersists > 1)
        {
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void resetScenePersists()
    {
        Destroy(gameObject);
    }

}
