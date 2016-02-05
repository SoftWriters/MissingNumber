'use strict'

const process = require ('process');

function isArrayFinite (nums) {
  return nums.every (num => !Number.isNaN (num));
}

function InvalidInput () {};
module.exports.InvalidInput = InvalidInput;

// Process a single line of input.
// Throws InvalidInput on error.
module.exports.parseLine = function (line) {
  if (!line.trim ().length)
    return;
  var nums = line.split (',').map (v => parseInt (v)).sort ((a, b) => a - b);
  if (!isArrayFinite (nums))
    throw new InvalidInput ();

  for (let i = 1, len = nums.length; i < len; ++i) {
    const expected = nums[i-1] + 1;
    if (nums[i] !== expected)
      return expected;
  }

  return; // undefined
}
