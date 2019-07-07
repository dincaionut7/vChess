using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess : MonoBehaviour
{

    public GameObject selected;
    public Collider[] colliderBuffer = new Collider[20];

    private Chess currentMove;
    private Chess lastMove;

    private GameObject[] highlights = new GameObject[4];

    public Material m_highlighted;

    public float speed = 3f;
    public string color;

    private enum Type { Pawn, Bishop, Horse, King, Queen, Tower };
    private Type _type;

    public string GetType()
    {
        return _type.ToString();
    }

    private GameObject lastSpawn;

    [Tooltip("Bishop =1 ,Horse,King,Pawn,Queen,Tower")]
    public int chesstype;
    private void getType()
    {
        switch (chesstype)
        {
            case 1:
                _type = Type.Bishop;
                break;
            case 2:
                _type = Type.Horse;
                break;
            case 3:
                _type = Type.King;
                break;
            case 4:
                _type = Type.Pawn;              
                break;
            case 5:
                _type = Type.Queen;
                break;
            case 6:
                _type = Type.Tower;
                break;
            default:
                break;

        }
    }

    public Vector3 pos;
    private Vector3 lastPos;
    public bool moving = false;
    private void Awake()
    {
        getType();
        lastPos = transform.position;
        Debug.Log(_type);
    }

    public void checkHorse(int x, int z)
    {
        Vector3 posToCheck;
        posToCheck = transform.position;
        posToCheck.z += z;
        posToCheck.x += x;
        posToCheck.y -= 0.3f;

        Collider[] colliders = Physics.OverlapSphere(posToCheck, 0.4f);
        foreach (Collider collider in colliders)
        {
            if (collider.transform.tag == "ChessPiece")
            {
                if (collider.GetComponent<Chess>().color != color)
                {
                    foreach (Collider colr in colliders)
                    {
                        if (colr.gameObject.tag == "floor")
                            colr.GetComponent<Renderer>().material = m_highlighted;
                    }
                }
                return;
            }
        }
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.tag == "floor")
            {
                collider.GetComponent<Renderer>().material = m_highlighted;
            }
        }

    }

    private void hintKing(int x, int z)
    {
        Vector3 posToCheck;
        posToCheck = transform.position;
        posToCheck.z += z;
        posToCheck.x += x;
        posToCheck.y -= 0.3f;

        Collider[] colliders = Physics.OverlapSphere(posToCheck, 0.4f);
        foreach (Collider collider in colliders)
        {
            if (collider.transform.tag == "ChessPiece")
            {
                if (collider.GetComponent<Chess>().color != color)
                {
                    foreach (Collider colr in colliders)
                    {
                        if (colr.gameObject.tag == "floor")
                            colr.GetComponent<Renderer>().material = m_highlighted;
                    }
                }
                return;
            }
        }
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.tag == "floor")
            {
                collider.GetComponent<Renderer>().material = m_highlighted;
            }
        }
    }
       
    public void showMove()
    {
        if (_type == Type.Pawn)
        {
            Vector3 posToCheck;
            posToCheck = transform.position + new Vector3(0f, 0f, 1f);
            if (color == "black")
            {
                posToCheck = transform.position + new Vector3(0f, 0f, -1f);
            }
            Collider[] colliders = Physics.OverlapSphere(posToCheck, 0.3f);
            foreach (Collider col in colliders)
            {
                if (col.gameObject.tag == "ChessPiece")
                {

                    if (col.GetComponent<Chess>().color != color)
                    {
                        foreach (Collider colr in colliders)
                        {
                            if (colr.gameObject.tag == "floor")
                                colr.GetComponent<Renderer>().material = m_highlighted;
                        }
                    }

                    return;
                }
            }

            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.tag == "floor")
                {
                    collider.GetComponent<Renderer>().material = m_highlighted;

                }
            }

        }

        if (_type == Type.Tower)
        {
            for (int i = 1; i <= 8; i++)
            {
                Vector3 posToCheck;
                posToCheck = transform.position;
                posToCheck.z -= i;
                posToCheck.y -= 0.5f;
                Collider[] colliders = Physics.OverlapSphere(posToCheck, 0.3f);

                foreach (Collider col in colliders)
                {
                    if (col.gameObject.tag == "ChessPiece")
                    {
                        if (col.GetComponent<Chess>().color != color)
                        {
                            foreach (Collider colr in colliders)
                            {
                                if (colr.gameObject.tag == "floor")
                                    colr.GetComponent<Renderer>().material = m_highlighted;
                            }
                        }
                        goto tag1;
                    }
                }
                foreach (Collider col in colliders)
                {
                    if (col.gameObject.tag == "floor")
                    {
                        col.GetComponent<Renderer>().material = m_highlighted;
                    }
                }
            }
            tag1:
            for (int i = 1; i <= 8; i++)
            {
                Vector3 posToCheck;
                posToCheck = transform.position;
                posToCheck.x -= i;
                posToCheck.y -= 0.5f;
                Collider[] colliders = Physics.OverlapSphere(posToCheck, 0.3f);

                foreach (Collider col in colliders)
                {
                    if (col.gameObject.tag == "ChessPiece")
                    {
                        if (col.GetComponent<Chess>().color != color)
                        {
                            foreach (Collider colr in colliders)
                            {
                                if (colr.gameObject.tag == "floor")
                                    colr.GetComponent<Renderer>().material = m_highlighted;
                            }
                        }
                        goto tag2;
                    }
                }
                foreach (Collider col in colliders)
                {
                    if (col.gameObject.tag == "floor")
                    {
                        col.GetComponent<Renderer>().material = m_highlighted;
                    }
                }
            }
            tag2:
            for (int i = 1; i <= 8; i++)
            {
                Vector3 posToCheck;
                posToCheck = transform.position;
                posToCheck.x += i;
                posToCheck.y -= 0.5f;
                Collider[] colliders = Physics.OverlapSphere(posToCheck, 0.3f);

                foreach (Collider col in colliders)
                {
                    if (col.gameObject.tag == "ChessPiece")
                    {
                        if (col.GetComponent<Chess>().color != color)
                        {
                            foreach (Collider colr in colliders)
                            {
                                if (colr.gameObject.tag == "floor")
                                    colr.GetComponent<Renderer>().material = m_highlighted;
                            }
                        }
                        goto tag3;
                    }
                }
                foreach (Collider col in colliders)
                {
                    if (col.gameObject.tag == "floor")
                    {
                        col.GetComponent<Renderer>().material = m_highlighted;
                    }
                }
            }
            tag3:
            for (int i = 1; i <= 8; i++)
            {
                Vector3 posToCheck;
                posToCheck = transform.position;
                posToCheck.z += i;
                posToCheck.y -= 0.5f;
                Collider[] colliders = Physics.OverlapSphere(posToCheck, 0.3f);

                foreach (Collider col in colliders)
                {
                    if (col.gameObject.tag == "ChessPiece")
                    {
                        if (col.GetComponent<Chess>().color != color)
                        {
                            foreach (Collider colr in colliders)
                            {
                                if (colr.gameObject.tag == "floor")
                                    colr.GetComponent<Renderer>().material = m_highlighted;
                            }
                        }
                        return;
                    }
                }
                foreach (Collider col in colliders)

                    if (col.gameObject.tag == "floor")
                    {
                        col.GetComponent<Renderer>().material = m_highlighted;
                    }
            }
        }

        if (_type == Type.Bishop)
        {
            for (int i = 1; i <= 8; i++)
            {
                Vector3 posToCheck;
                posToCheck = transform.position;
                posToCheck.z += i;
                posToCheck.x += i;
                posToCheck.y -= 0.5f;
                Collider[] colliders = Physics.OverlapSphere(posToCheck, 0.3f);

                foreach (Collider col in colliders)
                {
                    if (col.gameObject.tag == "ChessPiece")
                    {
                        if (col.GetComponent<Chess>().color != color)
                        {
                            foreach (Collider colr in colliders)
                            {
                                if (colr.gameObject.tag == "floor")
                                    colr.GetComponent<Renderer>().material = m_highlighted;
                            }
                        }
                        goto tag1;
                    }
                }

                foreach (Collider col in colliders)
                {
                    if (col.gameObject.tag == "floor")
                    {

                        col.GetComponent<Renderer>().material = m_highlighted;
                    }
                }
            }
            tag1:
            for (int i = 1; i <= 8; i++)
            {
                Vector3 posToCheck;
                posToCheck = transform.position;
                posToCheck.z += i;
                posToCheck.x -= i;
                posToCheck.y -= 0.5f;
                Collider[] colliders = Physics.OverlapSphere(posToCheck, 0.3f);

                foreach (Collider col in colliders)
                {
                    if (col.gameObject.tag == "ChessPiece")
                    {
                        if (col.GetComponent<Chess>().color != color)
                        {
                            foreach (Collider colr in colliders)
                            {
                                if (colr.gameObject.tag == "floor")
                                    colr.GetComponent<Renderer>().material = m_highlighted;
                            }
                        }
                        goto tag2;
                    }
                }

                foreach (Collider col in colliders)
                {
                    if (col.gameObject.tag == "floor")
                    {
                        col.GetComponent<Renderer>().material = m_highlighted;
                    }
                }
            }
            tag2:
            for (int i = 1; i <= 8; i++)
            {
                Vector3 posToCheck;
                posToCheck = transform.position;
                posToCheck.z -= i;
                posToCheck.x -= i;
                posToCheck.y -= 0.5f;
                Collider[] colliders = Physics.OverlapSphere(posToCheck, 0.3f);

                foreach (Collider col in colliders)
                {
                    if (col.gameObject.tag == "ChessPiece")
                    {
                        if (col.GetComponent<Chess>().color != color)
                        {
                            foreach (Collider colr in colliders)
                            {
                                if (colr.gameObject.tag == "floor")
                                    colr.GetComponent<Renderer>().material = m_highlighted;
                            }
                        }
                        goto tag3;
                    }
                }

                foreach (Collider col in colliders)
                {
                    if (col.gameObject.tag == "floor")
                    {
                        col.GetComponent<Renderer>().material = m_highlighted;
                    }
                }
            }
            tag3:
            for (int i = 1; i <= 8; i++)
            {
                Vector3 posToCheck;
                posToCheck = transform.position;
                posToCheck.z -= i;
                posToCheck.x += i;
                posToCheck.y -= 0.5f;
                Collider[] colliders = Physics.OverlapSphere(posToCheck, 0.3f);

                foreach (Collider col in colliders)
                {
                    if (col.gameObject.tag == "ChessPiece")
                    {
                        if (col.GetComponent<Chess>().color != color)
                        {
                            foreach (Collider colr in colliders)
                            {
                                if (colr.gameObject.tag == "floor")
                                    colr.GetComponent<Renderer>().material = m_highlighted;
                            }
                        }
                        return;
                    }
                }

                foreach (Collider col in colliders)
                {
                    if (col.gameObject.tag == "floor")
                    {
                        col.GetComponent<Renderer>().material = m_highlighted;
                    }
                }
            }
        }

        if (_type == Type.Horse)
        {
          

            for (int i = 0; i < 8; i++)
            {
                switch (i)
                {
                    case 0:
                        checkHorse(1, 2);
                        break;
                    case 1:
                        checkHorse(-1, 2);
                        break;
                    case 2:
                        checkHorse(1, -2);
                        break;
                    case 3:
                        checkHorse(-1, -2);
                        break;
                    case 4:
                        checkHorse(2, 1);
                        break;
                    case 5:
                        checkHorse(-2, 1);
                        break;
                    case 6:
                        checkHorse(2, -1);
                        break;
                    case 7:
                        checkHorse(-2, -1);
                        break;
                }
            }
        }

        if (_type == Type.King)
        {
            for (int i = 0; i < 8; i++)
            {
                switch (i)
                {
                    case 0:
                        hintKing(1, 0);
                        break;
                    case 1:
                        hintKing(-1, 0);
                        break;
                    case 2:
                        hintKing(1, 1);
                        break;
                    case 3:
                        hintKing(1, -1);
                        break;
                    case 4:
                        hintKing(-1, 1);
                        break;
                    case 5:
                        hintKing(-1, -1);
                        break;
                    case 6:
                        hintKing(0, 1);
                        break;
                    case 7:
                        hintKing(0, -1);
                        break;

                }
            }
        }

        if (_type == Type.Queen)
        {
            for (int i = 1; i <= 8; i++)
            {
                Vector3 posToCheck;
                posToCheck = transform.position;
                posToCheck.z += i;
                posToCheck.x += i;
                posToCheck.y -= 0.5f;
                Collider[] colliders = Physics.OverlapSphere(posToCheck, 0.3f);

                foreach (Collider col in colliders)
                {
                    if (col.gameObject.tag == "ChessPiece")
                    {
                        if (col.GetComponent<Chess>().color != color)
                        {
                            foreach (Collider colr in colliders)
                            {
                                if (colr.gameObject.tag == "floor")
                                    colr.GetComponent<Renderer>().material = m_highlighted;
                            }
                        }
                        goto tag1;
                    }
                }

                foreach (Collider col in colliders)
                {
                    if (col.gameObject.tag == "floor")
                    {
                        col.GetComponent<Renderer>().material = m_highlighted;
                    }
                }
            }
            tag1:
            for (int i = 1; i <= 8; i++)
            {
                Vector3 posToCheck;
                posToCheck = transform.position;
                posToCheck.z += i;
                posToCheck.x -= i;
                posToCheck.y -= 0.5f;
                Collider[] colliders = Physics.OverlapSphere(posToCheck, 0.3f);

                foreach (Collider col in colliders)
                {
                    if (col.gameObject.tag == "ChessPiece")
                    {
                        if (col.GetComponent<Chess>().color != color)
                        {
                            foreach (Collider colr in colliders)
                            {
                                if (colr.gameObject.tag == "floor")
                                    colr.GetComponent<Renderer>().material = m_highlighted;
                            }
                        }
                        goto tag2;
                    }
                }

                foreach (Collider col in colliders)
                {
                    if (col.gameObject.tag == "floor")
                    {
                        col.GetComponent<Renderer>().material = m_highlighted;
                    }
                }
            }
            tag2:
            for (int i = 1; i <= 8; i++)
            {
                Vector3 posToCheck;
                posToCheck = transform.position;
                posToCheck.z -= i;
                posToCheck.x -= i;
                posToCheck.y -= 0.5f;
                Collider[] colliders = Physics.OverlapSphere(posToCheck, 0.3f);

                foreach (Collider col in colliders)
                {
                    if (col.gameObject.tag == "ChessPiece")
                    {
                        if (col.GetComponent<Chess>().color != color)
                        {
                            foreach (Collider colr in colliders)
                            {
                                if (colr.gameObject.tag == "floor")
                                    colr.GetComponent<Renderer>().material = m_highlighted;
                            }
                        }
                        goto tag3;
                    }
                }

                foreach (Collider col in colliders)
                {
                    if (col.gameObject.tag == "floor")
                    {
                        col.GetComponent<Renderer>().material = m_highlighted;
                    }
                }
            }
            tag3:
            for (int i = 1; i <= 8; i++)
            {
                Vector3 posToCheck;
                posToCheck = transform.position;
                posToCheck.z -= i;
                posToCheck.x += i;
                posToCheck.y -= 0.5f;
                Collider[] colliders = Physics.OverlapSphere(posToCheck, 0.3f);

                foreach (Collider col in colliders)
                {
                    if (col.gameObject.tag == "ChessPiece")
                    {
                        if (col.GetComponent<Chess>().color != color)
                        {
                            foreach (Collider colr in colliders)
                            {
                                if (colr.gameObject.tag == "floor")
                                    colr.GetComponent<Renderer>().material = m_highlighted;
                            }
                        }
                        goto tag4;
                    }
                }

                foreach (Collider col in colliders)
                {
                    if (col.gameObject.tag == "floor")
                    {
                        col.GetComponent<Renderer>().material = m_highlighted;
                    }
                }


            }
            tag4:
            for (int i = 1; i <= 8; i++)
            {
                Vector3 posToCheck;
                posToCheck = transform.position;
                posToCheck.z -= i;
                posToCheck.y -= 0.5f;
                Collider[] colliders = Physics.OverlapSphere(posToCheck, 0.3f);

                foreach (Collider col in colliders)
                {
                    if (col.gameObject.tag == "ChessPiece")
                    {
                        if (col.GetComponent<Chess>().color != color)
                        {
                            foreach (Collider colr in colliders)
                            {
                                if (colr.gameObject.tag == "floor")
                                    colr.GetComponent<Renderer>().material = m_highlighted;
                            }
                        }
                        goto tag5;
                    }
                }
                foreach (Collider col in colliders)
                {
                    if (col.gameObject.tag == "floor")
                    {
                        col.GetComponent<Renderer>().material = m_highlighted;
                    }
                }
            }
            tag5:
            for (int i = 1; i <= 8; i++)
            {
                Vector3 posToCheck;
                posToCheck = transform.position;
                posToCheck.x -= i;
                posToCheck.y -= 0.5f;
                Collider[] colliders = Physics.OverlapSphere(posToCheck, 0.3f);

                foreach (Collider col in colliders)
                {
                    if (col.gameObject.tag == "ChessPiece")
                    {
                        if (col.GetComponent<Chess>().color != color)
                        {
                            foreach (Collider colr in colliders)
                            {
                                if (colr.gameObject.tag == "floor")
                                    colr.GetComponent<Renderer>().material = m_highlighted;
                            }
                        }
                        goto tag6;
                    }
                }
                foreach (Collider col in colliders)
                {
                    if (col.gameObject.tag == "floor")
                    {
                        col.GetComponent<Renderer>().material = m_highlighted;
                    }
                }
            }
            tag6:
            for (int i = 1; i <= 8; i++)
            {
                Vector3 posToCheck;
                posToCheck = transform.position;
                posToCheck.x += i;
                posToCheck.y -= 0.5f;
                Collider[] colliders = Physics.OverlapSphere(posToCheck, 0.3f);

                foreach (Collider col in colliders)
                {
                    if (col.gameObject.tag == "ChessPiece")
                    {
                        if (col.GetComponent<Chess>().color != color)
                        {
                            foreach (Collider colr in colliders)
                            {
                                if (colr.gameObject.tag == "floor")
                                    colr.GetComponent<Renderer>().material = m_highlighted;
                            }
                        }
                        goto tag7;
                    }
                }
                foreach (Collider col in colliders)
                {
                    if (col.gameObject.tag == "floor")
                    {
                        col.GetComponent<Renderer>().material = m_highlighted;
                    }
                }
            }
            tag7:
            for (int i = 1; i <= 8; i++)
            {
                Vector3 posToCheck;
                posToCheck = transform.position;
                posToCheck.z += i;
                posToCheck.y -= 0.5f;
                Collider[] colliders = Physics.OverlapSphere(posToCheck, 0.3f);

                foreach (Collider col in colliders)
                {
                    if (col.gameObject.tag == "ChessPiece")
                    {
                        if (col.GetComponent<Chess>().color != color)
                        {
                            foreach (Collider colr in colliders)
                            {
                                if (colr.gameObject.tag == "floor")
                                    colr.GetComponent<Renderer>().material = m_highlighted;
                            }
                        }
                        return;
                    }
                }
                foreach (Collider col in colliders)

                    if (col.gameObject.tag == "floor")
                    {
                        col.GetComponent<Renderer>().material = m_highlighted;
                    }
            }
        }
    }

    private void Update()
    {
        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
        }

        if (pos != null)
        { 
            if (Vector3.Distance(lastPos, pos) < 0.2f)
            {
                moving = false;
            }
        }
    }

    public void setMoveFlag(bool set)
    {
        moving = set;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GameManager.currentMove)
        {
            if (collision.gameObject.GetComponent<Chess>())
            {
                if (collision.gameObject.GetComponent<Chess>().color != color && collision.gameObject.GetComponent<Chess>() == GameManager.currentMove)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}

        
   


