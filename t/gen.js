#!/usr/bin/env node

// This script generates a shuffled, comma separated list of consecutive
// integers with a randomly selected missing number. The script requires two
// arguments, COUNT and START, where COUNT is the number of numbers to generate,
// and START is the first number in the sequence.

'use strict'

const path = require ('path');
const process = require ('process');
const _ = require ('underscore');

main ();

function parseArgs () {
  if (4 === process.argv.length) {
    return {
      count: parseInt (process.argv[2]),
      start: parseInt (process.argv[3])
    };
  }

  var appname = path.basename (process.argv[1]);
  console.log (`Usage: ${appname} COUNT START`);
  process.exit (2);
}

function main () {
  var args = parseArgs ();

  var out = [];
  out.length = args.count;

  const rogue = args.start + args.count;
  const rogue_index = Math.floor (Math.random () * args.count);
  var n = args.start;
  _.each (out, function (element, index, list) {
    if (index === rogue_index)
      list[index] = rogue;
    else
      list[index] = n;
    ++n;
  });

  out = _.shuffle (out);

  console.log (out.join (','));
}
