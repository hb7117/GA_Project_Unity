using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

public class QuickSortTest : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        int[] data = GenerateRandomArray(100);
        StartQuickSort(data, 0, data.Length - 1);
        foreach (var item  in data)
        {
            Debug.Log(item);
        }
    }

    int[] GenerateRandomArray(int size)
    {
        int[] arr = new int[size];
        System.Random rand = new System.Random();
        for (int i = 0; i < size; i++)
        {
            arr[i] = rand.Next(0, 1000);
        }
        return arr;
    }

    public static void StartQuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(arr, low, high);

            StartQuickSort(arr, low, pivotIndex - 1);   // �ǹ� ���� ����
            StartQuickSort(arr, pivotIndex + 1, high);  // �ǹ� ������ ����
        }
    }

    private static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = (low - 1);

        for (int j = low + 1; j < high; j++)
        {
            if (arr[j] <= pivot)
            {
                i++;
                // swap
                int temp = arr[j];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
        // pivot �ڸ� ��ȯ
        int temp2 = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = temp2;

        return i + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
