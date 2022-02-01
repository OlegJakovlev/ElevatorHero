using UnityEngine;

namespace UI
{
    public class ScorePopUp : MonoBehaviour
    {
        public void Deactivate()
        {
            Destroy(gameObject);
        }
    }
}
