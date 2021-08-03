﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    public GameObject gameObjectBetween;
    private EdgeCollider2D edgCollider2D;
    Vector3 pointA = new Vector3();
    Vector3 pointB = new Vector3();
    private void CreatingShapeBetweenPoints(Vector3 pA, Vector3 pB)
    {
        if (gameObjectBetween == null)
            return;
        GameObject cloneBetween = Instantiate(gameObjectBetween);
        Vector3 between = pB - pA;
        float distance = between.magnitude;
        cloneBetween.transform.localPosition = pA + (between / 2.0f);
        cloneBetween.transform.localScale = new Vector3(distance+0.1f, cloneBetween.transform.localScale.y, cloneBetween.transform.localScale.z);

        //Переворот
        Quaternion tempRotation = cloneBetween.transform.localRotation;
        cloneBetween.transform.LookAt(pA);
        float tempX = cloneBetween.transform.eulerAngles.x;
        cloneBetween.transform.localRotation = tempRotation;
        if (pA.x < pB.x)
            cloneBetween.transform.Rotate(0, 0, tempX);
        else
            cloneBetween.transform.Rotate(0, 0, -tempX);
    }
    private void Awake()
    {
        edgCollider2D = GetComponent<EdgeCollider2D>();
    }
    void Start()
    {
        for (int i = 0; i < edgCollider2D.pointCount-1; i++)
        {
            pointA = edgCollider2D.points[i];
            pointB = edgCollider2D.points[i+1] ;
            CreatingShapeBetweenPoints(pointA, pointB);
        }
    }
}