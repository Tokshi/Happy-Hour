using UnityEngine;

namespace Project
{
    public class Barrel : MonoBehaviour
    {
        #region -------------------------dependencies
        #endregion

        #region -------------------------interfaces
        #endregion

        #region -------------------------Unity Messages
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Wall") || other.CompareTag("Player") || other.CompareTag("Solid"))
            {
                Destroy(this.gameObject);
            }
        }
        #endregion

        #region -------------------------details
        #endregion
    }
}