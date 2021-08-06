using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockWorldGenerator : MonoBehaviour
{
    public GameObject Voxel;
    public Vector3 StartPosition;
    // Определяем размер мира
    public float SizeX;
    public float SizeZ;
    public float SizeY;

    void Start()
    {
        // Стартуем поток генерации мира
        StartCoroutine(SimpleGenerator());
    }

    public static void CloneAndPlace(Vector3 newPosition,GameObject originalGameobject)
    {
        // Клон
        GameObject clone = (GameObject)Instantiate(originalGameobject,  newPosition, Quaternion.identity);
        // Позиция
        clone.transform.position = newPosition;
        clone.name = "HillCube@" + clone.transform.position;
    }

    IEnumerator SimpleGenerator()
    {
        // В этом потоке мы будем создавать 50 кубов за один фрейм
        uint numberOfInstances = 0;
        uint instancesPerFrame = 50;

        for (float x = 0.5f; x <= SizeX; x+=0.5f)
        {
            for (float z = 0.5f; z <= SizeZ; z += 0.5f)
            {
                // Получаем случайную высоту
                float height = Random.Range(0, SizeY);
                for (float y = 0f; y <= height; y += 0.5f)
                {
                    // Расчитываем позицию для каждого блока
                    Vector3 newPosition = new Vector3(x, y, z);
                    // Вызываем метод, передавая ему новую позицию и экземпляр куба
                    CloneAndPlace(newPosition, Voxel);
                    // Инкрементируем numberOfInstances
                    numberOfInstances++;

                    // Если было достигнуто предельное количество экземпляров за фрейм
                    if (numberOfInstances == instancesPerFrame)
                    {
                        // Сбрасываем numberOfInstances
                        numberOfInstances = 0;
                        // И ждем следующего фрейма
                        yield return new WaitForEndOfFrame();
                    }
                }
            }
        }
    }
}
