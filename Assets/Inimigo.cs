using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public Transform dectectaChao;
    public float distancia = 3;
    public bool olhandoParaDireita;
    public float velocidade = 4;

    // Start is called before the first frame update
    private void Start()
    {
        olhandoParaDireita = true;
    }

    // Update is called once per frame
    private void Update()
    {
        Patrulha();
    }

    public void Patrulha()
    {
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(dectectaChao.position, Vector2.down, distancia);
        if (groundInfo.collider == false)
        {
            if (olhandoParaDireita == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                olhandoParaDireita = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                olhandoParaDireita = true;
            }
        }
    }
}