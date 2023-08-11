/*using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Inimigo : MonoBehaviour
{
    public Transform DetectaChao;
    public float distancia = 3;
    public bool olhandoParaDireita;
    public float velocidade = 4;

    //
    public Vector3 targetPosition;

    public Transform positionA;
    public Transform positionB;

    private SpriteRenderer m_SpriteRenderer;

    private void Start()
    {
        olhandoParaDireita = true;
        targetPosition = positionB.position;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //Patrulha();
        AtoB();
    }

    // Update is called once per frame
    public void Patrulha()
    {
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(DetectaChao.position, Vector2.down, distancia);

        Debug.DrawRay(DetectaChao.position, Vector2.down * distancia, Color.red);

        if (groundInfo.collider == false)
        {
            Debug.Log("HIT");

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

    //Other Option

    public void AtoB()
    {
        float step = Time.deltaTime * velocidade;

        if (this.transform.position == positionA.position)
        {
            targetPosition = positionB.position;
            m_SpriteRenderer.flipX = false;
        }

        if (this.transform.position == positionB.position)
        {
            targetPosition = positionA.position;
            m_SpriteRenderer.flipX = true;
        }

        this.transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }
}