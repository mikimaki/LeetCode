public class RemoveElement {
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        if(n == 0){
            return;
        }

        var j = 0;

        for(int i = m; i < m + n; i++){
            nums1[i] = nums2[j];

            var val = nums1[i];
            var adjacentVal = int.MinValue; //; //Handle the case where the adjacent value doesn't exist
            if (i > 0)
            {
                adjacentVal = nums1[i - 1];
            }
            var tempI = i;
            var adjacentI = tempI - 1;
            while (val < adjacentVal)
            {
                var tempVal = nums1[adjacentI];
                nums1[adjacentI] = nums1[tempI];
                nums1[tempI] = tempVal;

                if (adjacentI == 0)
                {
                    break;
                }
                tempI = tempI - 1;
                adjacentI = adjacentI - 1;
                val = nums1[tempI];
                adjacentVal = nums1[adjacentI];
            }

            j = j + 1;
        }
    }
}