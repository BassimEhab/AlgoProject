namespace HeapSortAlgo
{
    internal class Program
    {
        static List<int> list = new List<int>() { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 };
        static List<int> listsort = new List<int>();

        static void Main(string[] args)
        {

            HeapSort(list);

            foreach (int i in listsort)
            {
                Console.WriteLine(i);
            }


        }

        public static void Swap(int index, int largest)
        {
            int x = list[index];
            list[index] = list[largest];
            list[largest] = x;


        }


        public static void MaxHeapify(List<int> list, int index)
        {
            int left = 2 * index;
            int right = (2 * index) + 1;
            int largest = 0;


            if (left <= list.Count() && list[left - 1] > list[index - 1])
                largest = left;
            else
                largest = index;

            if (right <= list.Count() && list[right - 1] > list[largest - 1])
                largest = right;
            if (largest != index)
            {
                Swap(index - 1, largest - 1);

                MaxHeapify(list, largest);

            }



        }

        public static void BuildMaxHeap(List<int> list)
        {
            var HeapSize = list.Count / 2;

            for (int i = HeapSize; i >= 1; i--)
            {
                MaxHeapify(list, i);
            }

        }


        public static void HeapSort(List<int> list)
        {
            BuildMaxHeap(list);
            for (int i = list.Count; i >= 2; i--)
            {
                listsort.Add(list[0]);
                Swap(0, i - 1);
                list.RemoveAt(i - 1);
                MaxHeapify(list, 1);
            }
            listsort.Add(list[0]);

        }


    }


}
