using UnityEngine;

public class EndOfLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            // go to next level
            LevelSceneController.instance.NextLevel();
        }
    }
}
