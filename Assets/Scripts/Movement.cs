using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private VariableJoystick variableJoystick;
    [SerializeField] private float ileriGitmeHizi;
    [SerializeField] private float sagaSolaGitmeHizi;
    private bool canMove;

    public float IleriGitmeHizi { get => ileriGitmeHizi; set => ileriGitmeHizi = value; }
    public float SagaSolaGitmeHizi { get => sagaSolaGitmeHizi; set => sagaSolaGitmeHizi = value; }

    private void Start()
    {
        canMove = true;
        GameEvents.Instance.OnGameFinished += Instance_OnGameFinished;
    }

    private void Instance_OnGameFinished(bool obj)
    {
        canMove = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (canMove)
        {
            float yatayEksen = variableJoystick.Horizontal * SagaSolaGitmeHizi * Time.deltaTime;
            transform.Translate(yatayEksen, 0, IleriGitmeHizi * Time.deltaTime);
            if (transform.position.z > 2)
                transform.position = new Vector3(transform.position.x, transform.position.y, 2);
            if (transform.position.z < -2)
                transform.position = new Vector3(transform.position.x, transform.position.y, -2);
        }
    }
}