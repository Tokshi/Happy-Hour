using UnityEngine;
using XboxCtrlrInput;

namespace Project
{
    public class BartenderController : MonoBehaviour
    {
        #region ---------------------dependencies
        [SerializeField] private Transform _center;
        [SerializeField] private int _sections;
        [SerializeField] private GameObject _barrelPrefab;
        [SerializeField] private float _barrelSpeed;
        [SerializeField] private float _barRadius;
        #endregion

        #region ---------------------interface
        public void SpawnBarrel()
        {
            CalculateOffset();
            int section = Random.Range(0, _sections);
            float unitCircle = Mathf.Deg2Rad * _offset * section;
            Debug.Log(section);

            Vector3 direction = new Vector3(Mathf.Cos(unitCircle), 0f, Mathf.Sin(unitCircle));
            Vector3 spawnPosition = _center.position + direction * _barRadius;
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.right);

            if (section == 0 || section == 4)
            { rotation = Quaternion.LookRotation(direction, Vector3.forward); }

            GameObject go = Instantiate(_barrelPrefab, spawnPosition, rotation, transform);
            Rigidbody rb = go.GetComponent<Rigidbody>();
            rb.velocity = direction * 2.5f;
        }
        #endregion

        #region ---------------------Unity Messages
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) || XCI.GetButtonDown(XboxButton.A))
            {
                SpawnBarrel();
            }
        }
        #endregion

        #region ---------------------details
        private float _offset;

        private void CalculateOffset()
        {
            _offset = 360f / _sections;
        }
        #endregion
    }
}