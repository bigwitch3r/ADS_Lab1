using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS_Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand1 = new Random();

            int[] sizes = { 100, 200, 300, 400, 500, 600, 700, 800, 900,
            1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000,
            10000, 20000, 30000, 40000, 50000, 60000, 70000, 80000, 90000,
            100000, 200000, 300000, 400000, 500000, 600000, 700000, 800000, 900000};


            Console.WriteLine("Please, choose the algorithm:");
            Console.WriteLine("0) Selection sort.");
            Console.WriteLine("1) Insertion sort.");
            Console.WriteLine("2) Merge sort.");
            Console.WriteLine("3) Heap sort.");
            Console.WriteLine("4) Quick sort.");
            Console.WriteLine("5) Bucket sort.");

            int choice = Int32.Parse(Console.ReadLine());

            Console.WriteLine($"\nYour choise is {choice}.\n");

            switch (choice)
            {
                case 0: 
                    for (int i = 0; i < sizes.Length; i++)
                    {
                        int[] array = new int[sizes[i]];

                        for (int j = 0; j < sizes[i]; j++)
                        {
                            array[j] = rand1.Next(0, sizes[i]);
                        }

                        selection_sort(array);
                    }
                    break;

                case 1:
                    for (int i = 0; i < sizes.Length; i++)
                    {
                        int[] array = new int[sizes[i]];

                        for (int j = 0; j < sizes[i]; j++)
                        {
                            array[j] = rand1.Next(0, sizes[i]);
                        }

                        insertion_sort(array);
                    }
                    break;

                case 2:

                    for (int i = 0; i < sizes.Length; i++)
                    {
                        int[] array = new int[sizes[i]];

                        for (int j = 0; j < sizes[i]; j++)
                        {
                            array[j] = rand1.Next(0, sizes[i]);
                        }

                        Stopwatch sW = new Stopwatch();

                        sW.Start();
                        sort(array, 0, array.Length - 1);
                        sW.Stop();

                        Console.WriteLine($"{array.Length} items in array - {sW.ElapsedMilliseconds}");
                    }
                    break;

                case 3:
                    for (int i = 0; i < sizes.Length; i++)
                    {
                        int[] array = new int[sizes[i]];

                        for (int j = 0; j < sizes[i]; j++)
                        {
                            array[j] = rand1.Next(0, sizes[i]);
                        }

                        Stopwatch sW = new Stopwatch();

                        sW.Start();
                        heap_sort(array);
                        sW.Stop();

                        Console.WriteLine($"{array.Length} items in array - {sW.ElapsedMilliseconds}");
                    }
                    break;

                case 4:
                    for (int i = 0; i < sizes.Length; i++)
                    {
                        int[] array1 = new int[sizes[i]];

                        for (int j = 0; j < sizes[i]; j++)
                        {
                            array1[j] = rand1.Next(0, sizes[i]);
                        }

                        Stopwatch sW = new Stopwatch();

                        sW.Start();
                        quick_sort(array1, 0, array1.Length - 1);
                        sW.Stop();

                        Console.WriteLine($"{array1.Length} items in array - {sW.ElapsedMilliseconds}");
                    }
                    break;

                case 5:
                    for (int i = 0; i < sizes.Length; i++)
                    {
                        int[] array1 = new int[sizes[i]];

                        for (int j = 0; j < sizes[i]; j++)
                        {
                            array1[j] = rand1.Next(0, sizes[i]);
                        }

                        Stopwatch sW = new Stopwatch();

                        sW.Start();
                        BucketSort(array1);
                        sW.Stop();

                        Console.WriteLine($"{array1.Length} items in array - {sW.ElapsedMilliseconds}");
                    }
                    break;

                default:
                    break;
            }
        }

        static void selection_sort(int[] arr)
        {
            Stopwatch stopWatch = new Stopwatch();
            int min, temp;
            int length = arr.Length;

            stopWatch.Start();

            for (int i = 0; i < length - 1; i++)
            {
                min = i;

                for (int j = i + 1; j < length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    temp = arr[i];
                    arr[i] = arr[min];
                    arr[min] = temp;
                }
            }

            stopWatch.Stop();
            Console.WriteLine($"{length} items in array - {stopWatch.ElapsedMilliseconds}");
        }

        static void insertion_sort(int[] arr)
        {
            Stopwatch stopWatch = new Stopwatch();

            int n = arr.Length;

            stopWatch.Start();

            for (int i = 1; i < n; ++i)
            {
                int key = arr[i];
                int j = i - 1;

                // Move elements of arr[0..i-1],
                // that are greater than key,
                // to one position ahead of
                // their current position
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }

            stopWatch.Stop();
            Console.WriteLine($"{arr.Length} items in array - {stopWatch.ElapsedMilliseconds}");
        }

        static void merge_sort(int[] arr, int l, int m, int r)
        {
            // Find sizes of two
            // subarrays to be merged
            int n1 = m - l + 1;
            int n2 = r - m;

            // Create temp arrays
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            // Copy data to temp arrays
            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];

            // Merge the temp arrays

            // Initial indexes of first
            // and second subarrays
            i = 0;
            j = 0;

            // Initial index of merged
            // subarray array
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements
            // of L[] if any
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            // Copy remaining elements
            // of R[] if any
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        // Main function that
        // sorts arr[l..r] using
        // merge()
        static void sort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                // Find the middle
                // point
                int m = l + (r - l) / 2;

                // Sort first and
                // second halves
                sort(arr, l, m);
                sort(arr, m + 1, r);

                // Merge the sorted halves
                merge_sort(arr, l, m, r);
            }
        }

        static void heap_sort(int[] arr)
        {
            int n = arr.Length;

            // Построение кучи (перегруппируем массив)
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(arr, n, i);

            // Один за другим извлекаем элементы из кучи
            for (int i = n - 1; i >= 0; i--)
            {
                // Перемещаем текущий корень в конец
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                // вызываем процедуру heapify на уменьшенной куче
                heapify(arr, i, 0);
            }
        }

        // Процедура для преобразования в двоичную кучу поддерева с корневым узлом i, что является
        // индексом в arr[]. n - размер кучи

        static void heapify(int[] arr, int n, int i)
        {
            int largest = i;
            // Инициализируем наибольший элемент как корень
            int l = 2 * i + 1; // left = 2*i + 1
            int r = 2 * i + 2; // right = 2*i + 2

            // Если левый дочерний элемент больше корня
            if (l < n && arr[l] > arr[largest])
                largest = l;

            // Если правый дочерний элемент больше, чем самый большой элемент на данный момент
            if (r < n && arr[r] > arr[largest])
                largest = r;

            // Если самый большой элемент не корень
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                // Рекурсивно преобразуем в двоичную кучу затронутое поддерево
                heapify(arr, n, largest);
            }
        }

        static int Partition(int[] array, int low,
                                    int high)
        {
            //1. Select a pivot point.
            int pivot = array[high];

            int lowIndex = (low - 1);

            //2. Reorder the collection.
            for (int j = low; j < high; j++)
            {
                if (array[j] <= pivot)
                {
                    lowIndex++;

                    int temp = array[lowIndex];
                    array[lowIndex] = array[j];
                    array[j] = temp;
                }
            }

            int temp1 = array[lowIndex + 1];
            array[lowIndex + 1] = array[high];
            array[high] = temp1;

            return lowIndex + 1;
        }

        static void quick_sort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = Partition(array, low, high);

                //3. Recursively continue sorting the array
                quick_sort(array, low, partitionIndex - 1);
                quick_sort(array, partitionIndex + 1, high);
            }
        }

        static void BucketSort(int[] items)
        {
            // Предварительная проверка элементов исходного массива
            //

            if (items == null || items.Length < 2)
                return;

            // Поиск элементов с максимальным и минимальным значениями
            //

            int maxValue = items[0];
            int minValue = items[0];

            for (int i = 1; i < items.Length; i++)
            {
                if (items[i] > maxValue)
                    maxValue = items[i];

                if (items[i] < minValue)
                    minValue = items[i];
            }

            // Создание временного массива "карманов" в количестве,
            // достаточном для хранения всех возможных элементов,
            // чьи значения лежат в диапазоне между minValue и maxValue.
            // Т.е. для каждого элемента массива выделяется "карман" List<int>.
            // При заполнении данных "карманов" элементы исходного не отсортированного массива
            // будут размещаться в порядке возрастания собственных значений "слева направо".
            //

            List<int>[] bucket = new List<int>[maxValue - minValue + 1];

            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }

            // Занесение значений в пакеты
            //

            for (int i = 0; i < items.Length; i++)
            {
                bucket[items[i] - minValue].Add(items[i]);
            }

            // Восстановление элементов в исходный массив
            // из карманов в порядке возрастания значений
            //

            int position = 0;
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i].Count > 0)
                {
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        items[position] = bucket[i][j];
                        position++;
                    }
                }
            }
        }
    }
}
