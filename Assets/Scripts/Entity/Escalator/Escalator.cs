using UnityEngine;

namespace Entity.Escalator
{
    public class Escalator : MonoBehaviour
    {
        public void Use(Transform player, Transform newFinish)
        {
            player.position = newFinish.position;
        }
    }
}