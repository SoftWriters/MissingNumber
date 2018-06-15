#BDUNAR Missing Number Problem
import csv
#Probably not the best way to do this, but here's what I came up with!

def missingNum(file):
  allnums = []
  with open(file, 'rb') as f:
    reader = csv.reader(f)
    allnums = list(reader)
    
  for nums in allnums:
    nums = map(int, nums)
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


missingNum("nums.csv")
