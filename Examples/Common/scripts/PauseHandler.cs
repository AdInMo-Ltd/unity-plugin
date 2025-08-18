using UnityEngine;
/// <summary>
/// An example of a class that can handle the automatic pausing of the game when the Magnifier is showing
/// </summary>
/// 
namespace Adinmo
{
    public class PauseHandler : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            AdinmoManager.SetPauseGameCallback(gamePaused);
            AdinmoManager.SetResumeGameCallback(gameResumed);
        }


        public void gamePaused()
        {
            //Add game specific code for handling pausing the game
            Time.timeScale = 0;
        }

        public void gameResumed()
        {
            //Add game specific code for handling resuming the game
            Time.timeScale = 1;
        }
    }
}