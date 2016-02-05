Missing Number
==============

The Problem
-----------
Please write a program which finds the missing number in a sequential series of numbers. The program should: 

1. Accept a flat file as input.
	1. Each new line will contain a set of sequential numbers with one number missing. 
	2. Each series will be comma delimited and in a random order
2. Output the missing number for each series

Sample Input
------------
1,2,3,4,5,6,7,8,9,10,12

24,26,27,29,28

1,2,4,5

99,100,101,102,103,104,105,107

109,105,107,108,106,110,112,111,118,116,115,114,117

Sample Output
-------------
11

25

3

106

113

The Solution
--------------
The solution is implemented as a NodeJS module. Each line is split into an
array and each element is converted to an integer. The array is then sorted,
and sequentially searched for a missing number.

### Run the solution

```
node bin/missing-numbers INPUT_FILE
```

The ``node`` portion of the command can be omitted on unix like platforms.

### Test the solution

To run the automated tests:

```
npm install
npm test
```

There is also a script, ``t/gen.js`` that can be used to generate larger
datasets for testing. The script has been smoke tested with up to 10 million
elements per line which is probably approaching the upper limit for this
particular implementation.
