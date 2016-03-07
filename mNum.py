#BDUNAR Missing Number Problem

#Probably not the best way to do this, but here's what I came up with!

def missingNum(nums):
  #First let's sort the list of numbers in case the numbers aren't in order
  nums.sort()
  #Then we will take the lowest value
  lower = nums[0]
  
  #if the lowest value = 1 then we don't need to the following as the list of numbers already starts with 1
  rest = 0
  if(lower != 1):
    #this finds the sum of the numbers from 1 -> lower for use later
  	rest = ((lower-1) * (lower))/2
    
  #this algorithm essentially just gets the sum of the list of numbers assuming the missing number is there
  #and then subtracts the sum of the of what is actually in the list plus the "rest" to give us our answer
  answer = (nums[-1] * (nums[-1] + 1))/2 - (sum(nums) + rest)
  print answer
        
nums1 = [1,2,3,4,5,6,7,8,9,10,12]
nums2 = [24,26,27,29,28]
nums3 = [1,2,4,5]
nums4 = [99,100,101,102,103,104,105,107]
nums5 = [109,105,107,108,106,110,112,111,118,116,115,114,117]

missingNum(nums1)
missingNum(nums2)
missingNum(nums3)
missingNum(nums4)
missingNum(nums5)
