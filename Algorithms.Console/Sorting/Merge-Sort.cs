namespace Algorithms.Problems
{
    public static class Merge
    {
        public static int[] Sort(int[] array)
        {
            if(array.Length <= 1)
                return array;
            int[] clone = (int[])array.Clone();
            Divide(0, array.Length - 1, array, clone);
            return array;
        }

        private static void Divide(int sIndex, int eIndex, int[] array, int[] clone)
        {
            if(sIndex == eIndex)
                return;
            int mIndex = (sIndex + eIndex) / 2;
            Divide(sIndex, mIndex, clone, array);
            Divide(mIndex + 1, eIndex, clone, array);
            Concur(sIndex, mIndex, eIndex, array, clone);
        }

        private static void Concur(int sIndex, int mIndex, int eIndex, int[] array, int[] clone)
        {
            int i = sIndex, j = mIndex + 1, k = sIndex;
            while(i <= mIndex && j <= eIndex)
            {
                if(clone[i] > clone[j])
                {
                    array[k] = clone[j];
                    k++;
                    j++;
                }
                else
                {
                    array[k] = clone[i];
                    k++;
                    i++;
                }
            }
            while(i <= mIndex)
            {
                array[k] = clone[i];
                k++;
                i++;
            }
            while(j <= eIndex)
            {
                array[k] = clone[j];
                k++;
                j++;
            }
        }
    }
}