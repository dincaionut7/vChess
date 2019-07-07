using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static Chess currentSelection;
    private static Chess lastSel;

    public static Chess currentMove;
    public static Chess lastMove;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "ChessPiece")
                {
                    if (currentSelection)
                    {
                        lastSel = currentSelection;
                    }

                    currentSelection = hit.transform.gameObject.GetComponent<Chess>();

                    if (!lastSel)
                    {
                        lastSel = currentSelection;
                    }

                    if (currentSelection != lastSel)
                    {
                        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("floor"))
                        {
                            if (obj.GetComponent<Renderer>().material != obj.GetComponent<highlightMaterial>().m_default)
                            {
                                obj.GetComponent<Renderer>().material = obj.GetComponent<highlightMaterial>().m_default;
                            }
                        }
                    }

                    hit.transform.gameObject.GetComponent<Chess>().showMove();

                    Debug.Log(string.Format("current: {0} / last: {1}", currentSelection.GetType(), lastSel.GetType()));
                }

                if (hit.transform.tag == "floor")
                {
                    if (currentSelection)
                    {
                        if (hit.transform.gameObject.GetComponent<Renderer>().material != hit.transform.gameObject.GetComponent<highlightMaterial>().m_default)
                        {
                            currentSelection.pos = hit.transform.position;
                            currentSelection.pos.y = currentSelection.transform.position.y;
                            currentSelection.moving = true;
                            if (lastMove)
                            {
                                lastMove = currentMove;
                            }

                            currentMove = currentSelection;

                            if (!lastMove)
                            {
                                lastMove = currentMove;
                            }
                            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("floor"))
                            {
                                if (obj.GetComponent<Renderer>().material != obj.GetComponent<highlightMaterial>().m_default)
                                {
                                    obj.GetComponent<Renderer>().material = obj.GetComponent<highlightMaterial>().m_default;
                                }
                            }
                        }

                    }

                }
            }
        }
    }
}
