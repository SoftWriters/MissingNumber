var mn = require ('../');

module.exports.empty = function (test) {
  test.strictEqual (mn.parseLine (''), undefined);
  test.done ();
};
module.exports.whitespaceOnly = function (test) {
  test.strictEqual (mn.parseLine ('  	'), undefined);
  test.done ();
};
module.exports.singleNumber = function (test) {
  test.strictEqual (mn.parseLine ('10'), undefined);
  test.done ();
};
module.exports.withSpacesUndef = function (test) {
  test.strictEqual (mn.parseLine (' 1,  2 '), undefined);
  test.done ();
};
module.exports.withSpaces = function (test) {
  test.strictEqual (mn.parseLine (' 3,  1 '), 2);
  test.done ();
};
module.exports.aroundZero = function (test) {
  test.strictEqual (mn.parseLine (' 3,  2, -1, 1 '), 0);
  test.done ();
};
module.exports.moreThanOneMissing = function (test) {
  test.strictEqual (mn.parseLine ('6,4,1,3'), 2);
  test.done ();
};
module.exports.largerNumbers = function (test) {
  test.strictEqual (mn.parseLine ('811032401,811032399,811032402'), 811032400);
  test.done ();
};
module.exports.negativeNumbers = function (test) {
  test.strictEqual (mn.parseLine ('-6,-4,-1,-3'), -5);
  test.done ();
};
module.exports.arbitrary1 = function (test) {
  test.strictEqual (mn.parseLine ('98,99,101,100,103'), 102);
  test.done ();
};
module.exports.arbitrary2 = function (test) {
  test.strictEqual (mn.parseLine ('1,2,3,4,5,6,7,8,9,10,12'), 11);
  test.done ();
};
module.exports.arbitrary3 = function (test) {
  test.strictEqual (mn.parseLine ('24,26,27,29,28'), 25);
  test.done ();
};
module.exports.arbitrary4 = function (test) {
  test.strictEqual (mn.parseLine ('1,2,4,5'), 3);
  test.done ();
};
module.exports.arbitrary5 = function (test) {
  test.strictEqual (mn.parseLine ('99,100,101,102,103,104,105,107'), 106);
  test.done ();
};
module.exports.arbitrary6 = function (test) {
  test.strictEqual (
    mn.parseLine ('109,105,107,108,106,110,112,111,118,116,115,114,117'), 113
  );
  test.done ();
};
module.exports.invalidString = function (test) {
  test.throws (function () { mn.parseLine ('hello') });
  test.done ();
};
module.exports.invalidList1 = function (test) {
  test.throws (function () { mn.parseLine ('1,2,') });
  test.done ();
};
module.exports.invalidList2 = function (test) {
  test.throws (function () { mn.parseLine (' ,1') });
  test.done ();
};
module.exports.decimalsTruncate = function (test) {
  test.strictEqual (mn.parseLine ('1.01,2.02,4.02'), 3);
  test.done ();
};
module.exports.suffixOK = function (test) {
  test.strictEqual (mn.parseLine ('1ab,2cd,4ef'), 3);
  test.done ();
};
module.exports.prefixNotOK = function (test) {
  test.throws (function () { mn.parseLine ('ab1,cd2,ef4') });
  test.done ();
};
module.exports.notUnique = function (test) {
  test.strictEqual (mn.parseLine ('4,2,2'), 3);
  test.done ();
};
